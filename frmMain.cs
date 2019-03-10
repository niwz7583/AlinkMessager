//#define USE_AHEAD_VOIP  //是否为使用VOIP控件模式的消息 //add by niwz 2015.12.08

using AheadTec;
using AheadTec.AilinkServer;
using ICSU.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#if USE_AHEAD_VOIP
using AxALINKVOIPOCXLib;
#endif

namespace AlinkMessager
{
    public partial class frmMain : UIForm
    {
#if USE_AHEAD_VOIP
        AxAlinkVoipOCX ocx = null;

        const int DevConnectErr = -12;
        const int DevAudioErr = -21;
        const int DevOK = 0;                  //0: 成功
        const int DevErr = -1;                 //-1: 失败
        const int DevActiveErr = 2;          //2: 呼叫没有激活
        const int DevActiveORHoldErr = 3;     //3: 呼叫没有激活或保持
        const int DevHoldErr = 4;				 //4: 呼叫没有保持
        const int DevUnKnowErr = -2;           //-2: 未知错误
        const int DevLengthErr = -3;           //-3: 长度错误
        const int DevRecordErr = -4;           //-4: 没有匹配的记录
        const int DevFullErr = -5;             //-5: 已经满了
        const int DevLogOut = -6;             //-6: 用户已经签出
        const int DevLogin = -7;               //-7: 用户已经签入
        const int DevIdle = -8;                //-8: 用户已经空闲
        const int DevNoRing = -9;             //-9: 没有振铃
        const int DevRing = -10;               //-10: 正在振铃
        const int DevTalking = -11;            //-11: 正在通话
#else
        LXTcpConnection m_connection = null;
#endif
        bool m_isRunning = false;
        string m_agent = string.Empty;  //座席号
        string m_employee = string.Empty;   //员工号
        string m_firstCode = null;
        DateTime beginTime = DateTime.MinValue;
        string _actionPageUrl = string.Empty;
        bool m_isTalking = false;
        string m_talking_guid = string.Empty;

        string m_current_caller = string.Empty;  //当前号码  //add by niwz 2018.03.13

        int m_callId = 10000;

        readonly LXHttpServer _server;

        int m_queuecount = Properties.Settings.Default.QueueCount;

        public frmMain()
        {
            InitializeComponent();
#if USE_AHEAD_VOIP
            gb_ailink.Height = 70;
            gb_agents.Top = 107;

            ocx = new AxALINKVOIPOCXLib.AxAlinkVoipOCX();
            ((System.ComponentModel.ISupportInitialize)(ocx)).BeginInit();
            ocx.Enabled = true;
            ocx.Location = new System.Drawing.Point(-10, -10);
            ocx.Name = "axAlinkVoipOCX1";
            //ocx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAlinkVoipOCX1.OcxState")));
            ocx.Size = new System.Drawing.Size(5, 5);
            ocx.TabIndex = 13;
            this.Controls.Add(ocx);
            ((System.ComponentModel.ISupportInitialize)(ocx)).EndInit();
#else
            gb_ailink.Height = 100;
            gb_agents.Top = 136;
            this.Controls.Remove(ivAnswer);
            this.Controls.Remove(ivHangup);
            gb_agents.BringToFront();
#endif
            _server = new LXHttpServer(httpActionHandler, Properties.Settings.Default.HttpActionPort);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*this.Hide();
            notifyIcon1.Visible = true;
            e.Cancel = true;*/
            if ((e.CloseReason == CloseReason.ApplicationExitCall) || (e.CloseReason == CloseReason.WindowsShutDown))
            {
                e.Cancel = false;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int height = Screen.GetBounds(this).Height - Screen.GetWorkingArea(this).Height;
            this.Top = Screen.GetBounds(this).Height - this.Height - height - 5;
            this.Left = Screen.GetBounds(this).Width - this.Width - 5;
            //座席队列信息定时，默认为3秒；
            tmr_queue.Interval = Properties.Settings.Default.QueueInterval * 1000;

#if DEBUG
            tb_ipaddress.Text = "192.168.1.221";
            tb_agent.Text = "8032";
#endif
            toolTip1.SetToolTip(this.iv_start, "开始接听电话");
            //自动登录
            if (cbx_login.Checked)
                iv_start_Click(null, EventArgs.Empty);
            else
                TuneControl(false);

            this.BeginInvoke(new MethodInvoker(() => { this.Hide(); }));
        }

        void Logout()
        {
            try
            {
#if USE_AHEAD_VOIP
                if (ocx != null)
                {
                    ocx.LXSipUnregister();
                    ocx = null;
                }
#else
                if (m_connection != null)
                {
                    m_connection.Send("103/{0}/|", m_agent); //退出登录
                    m_connection.Dispose();
                    m_connection = null;
                    //清理现场  //add by niwz 2018.03.13
                    if (frmDialup != null)
                    {
                        frmDialup.Dispose();
                        frmDialup = null;
                    }
                    //
                    if (frmWay != null)
                    {
                        frmWay.Dispose();
                        frmWay = null;
                    }
                    m_cur_joincaller = string.Empty;
                    m_caller_muted = false;
                    m_joincaller_muted = false;
                }
#endif
                //
                TuneControl(false);
            }
            catch { }
        }

        void Login()
        {
#if USE_AHEAD_VOIP
            //if (ocx != null)
            //    return;
#else
            if (m_connection != null)
            {
                m_connection.Close();
                m_connection = null;
            }
#endif
            try
            {
                ShowStatus("正在登录");
                string serverIp = tb_ipaddress.Text;
                int port = int.Parse(tb_port.Text);
                string passwd = tb_password.Text;
#if USE_AHEAD_VOIP
                int iRet = ocx.LXSipRegister(0, serverIp, serverIp, port, m_agent, m_agent, passwd);
                ocx.OnLXVoipMsg += Ocx_OnLXVoipMsg;
                if (iRet == DevOK)
                {
                    //启动Http监听服务，供页面调用软外拨功能
                    _server.Open(null);
                    ShowStatus("空闲");
                }
                else
                {
                    if (iRet == -12)
                        ShowStatus("连接失败");
                    //登录失败
                    TuneControl(false);
                }
#else
                TcpClient clnt = new TcpClient();
                clnt.Connect(serverIp, port);
                m_connection = new LXTcpConnection(clnt);
                m_connection.OnReceived += OnReceivedData;
                m_connection.OnOpened += (c) =>
                {
                    ShowStatus("已连接");
                    //发送登录信息
                    c.Send("102/{0}/{1}/{2}////|", m_agent, m_employee, passwd);
                    //启动Http监听服务，供页面调用软外拨功能
                    _server.Open(null);
                };
                m_connection.OnClosed += (c) =>
                {
                    ShowStatus("连接断开");
                    _server.Close();
                    TuneControl(false);
                    TuneQueueInfo(false);
                };
                m_connection.Open(null);
#endif
            }
            catch (Exception ex)
            {
                LogHelper.Write("ConnectHost", ex);
                ShowStatus("连接失败");
                if (this.InvokeRequired)
                    this.BeginInvoke(new MethodInvoker(Show));
                else
                    this.Show();
                TuneControl(false);
            }
        }
#if USE_AHEAD_VOIP
        private void Ocx_OnLXVoipMsg(object sender, _DAlinkVoipOCXEvents_OnLXVoipMsgEvent e)
        {
            //来电信息
            if (string.Compare(e.status, "Ring") == 0)
            {
                ShowStatus("来电");
                ShowPhoneTools(true);
                ShowPopup(e.trunkCaller, m_agent, e.calling);
            }
            else if (string.Compare(e.status, "Disconnect") == 0)
            {
                ShowStatus("连接断开");
            }
            else if (string.Compare(e.status, "Dialing") == 0)
            {
                ShowStatus("正在拨号");
            }
            else if (string.Compare(e.status, "Talking") == 0)
            {
                ShowStatus("通话中");
                ShowPhoneTools(true);
            }
            else if (string.Compare(e.status, "Idle") == 0)
            {
                ShowStatus("空闲");
                ShowPhoneTools();
            }
            else
            {
                LogHelper.Write("OnLXVoipMsg", "e.status:{0}, e.calling:{1}, e.trunkCaller:{2}, e.filePath:{3}", e.status, e.calling, e.trunkCaller, e.filePath);
            }
        }
#endif

        void SaveSetting()
        {
            Properties.Settings.Default.Save();
        }

        private void tsmi_exit_Click(object sender, EventArgs e)
        {
            string tips = m_isRunning ? "退出系统后将无法实现电话接入及弹屏等操作！\r\n\r\n确认要退出本系统吗？" : "确认要退出本系统吗？";
            if (MessageBox.Show(tips, "Ailink提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            //断开连接       
            Logout();
#if USE_AHEAD_VOIP
            try
            {
                if (ocx != null)
                {
                    var iRet = ocx.LXSipUnregister();
                    ocx.OnLXVoipMsg -= Ocx_OnLXVoipMsg;
                    this.Controls.Remove(ocx);
                    ocx.Dispose();
                    ocx = null;
                }
                //
                foreach (var f in Directory.GetFiles(Environment.CurrentDirectory, "SipLog*.txt"))
                    File.Delete(f);
            }
            catch (Exception ex)
            {
                LogHelper.Write("EnvironmentExit", ex.Message);
            }
#endif
            //清理图标内容
            notifyIcon1.Dispose();
            try
            {
                int hwnd = NativeMethods.FindWindow("Shell_TrayWnd", null);
                NativeMethods.UpdateWindow(hwnd);
                hwnd = NativeMethods.FindWindowEx(hwnd, 0, "TrayNotifyWnd", null);
                NativeMethods.UpdateWindow(hwnd);
            }
            catch { }
            //终止程序
            try
            {
                this.Close();
                Application.Exit();
                // Environment.Exit(0);
            }
            catch { }
        }

        private void iv_start_Click(object sender, EventArgs e)
        {
            if (m_isRunning)
            {
                if (MessageBox.Show("停止接入电话将无法实现电话弹屏等操作！\r\n\r\n确认要停止吗？", "Ailink提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
                //
                Logout();
                return;
            }

            if (string.IsNullOrEmpty(tb_ipaddress.Text))
            {
                Toast.Show("请输入Ailink的地址。");
                return;
            }
            int _port = 0;
            if (!int.TryParse(tb_port.Text, out _port) || _port < 100 || _port > 65534)
            {
                Toast.Show("请输入正确的端口号。");
                return;
            }

            if (string.IsNullOrEmpty(tb_agent.Text))
            {
                Toast.Show("请输入当前的座席号。");
                return;
            }

            if (string.IsNullOrEmpty(tb_employee.Text))
            {
                Toast.Show("请输入当前的员工号。");
                return;
            }

            if (string.IsNullOrEmpty(tb_password.Text))
            {
                Toast.Show("请输入座席登录密码。");
                return;
            }
            SaveSetting();
            m_agent = tb_agent.Text;
            m_employee = tb_employee.Text;
            m_firstCode = tb_firstcode.Text;
            //调整控件
            TuneControl(true);
            //启动连接内容
#if USE_AHEAD_VOIP
            Thread loginThread = new Thread(Login);
            loginThread.SetApartmentState(ApartmentState.STA);
            loginThread.IsBackground = true;
            loginThread.Start();
#else
            MethodInvoker mi = () =>
            {
                Login();
            };
            mi.BeginInvoke(null, null);
#endif
        }

        string formatUrl(string originUrl, string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return originUrl;

            string result = originUrl;
            if (originUrl.IndexOf("?") < 0)
                result += "?";

            if (!result.EndsWith("?"))
                result += "&";
            result += string.Format("{0}={1}", key, value);
            return result;
        }

        void ShowPopup(string caller, string called, string trunknum, string sguid)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { ShowPopup(caller, called, trunknum, sguid); };
                this.BeginInvoke(mi);
                return;
            }
            var setting = Properties.Settings.Default;
            _actionPageUrl = setting.ActionPageUrl;
#if DEBUG
            _actionPageUrl = "http://www.aheadtec.com/";
#endif
            if (string.IsNullOrEmpty(_actionPageUrl))
            {
                //打开来电窗口
                Toast.Popup(caller, trunknum);
            }
            else
            {
                //调用页面内容
                //添加参数
                /*if (_actionPageUrl.IndexOf("?") < 0)
                    _actionPageUrl += "?";
                if (!string.IsNullOrEmpty(setting.ActionFieldCaller))
                    _actionPageUrl += string.Format("&{0}={1}", setting.ActionFieldCaller, caller);
                if (!string.IsNullOrEmpty(setting.ActionFieldCalled))
                    _actionPageUrl += string.Format("&{0}={1}", setting.ActionFieldCalled, called);
                if (!string.IsNullOrEmpty(setting.ActionFieldTrunk))
                    _actionPageUrl += string.Format("&{0}={1}", setting.ActionFieldTrunk, trunknum);
                if (!string.IsNullOrEmpty(setting.ActionFieldGuid))
                    _actionPageUrl += string.Format("&{0}={1}", setting.ActionFieldGuid, sguid);*/
                //_actionPageUrl += "&called=" + called;
                //_actionPageUrl += "&trunknum=" + trunknum;
                //_actionPageUrl += "&data=" + paras[4];
                //格式化URL路径
                _actionPageUrl = formatUrl(_actionPageUrl, setting.ActionFieldCaller, caller);
                _actionPageUrl = formatUrl(_actionPageUrl, setting.ActionFieldCalled, called);
                _actionPageUrl = formatUrl(_actionPageUrl, setting.ActionFieldTrunk, trunknum);
                _actionPageUrl = formatUrl(_actionPageUrl, setting.ActionFieldGuid, sguid);
                _actionPageUrl = formatUrl(_actionPageUrl, setting.ActionFieldEmployee, m_employee);
                try
                {
                    Process.Start(_actionPageUrl);
                }
                catch (Exception ex)
                {
                    LogHelper.Write("ShowPopup", ex);
                    Toast.Popup(caller, trunknum); //启动浏览器失败
                }
            }
        }

        void ShowSummaryForm(string callguid)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { ShowSummaryForm(callguid); };
                this.BeginInvoke(mi);
                return;
            }

            new frmSummary { CallGuid = callguid }.ShowDialog(this);
        }

        /// <summary>
        /// 显示登录成功内容。
        /// </summary>
        void FireOnLogined()
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = FireOnLogined;
                this.BeginInvoke(mi);
                return;
            }
            //
            var setting = Properties.Settings.Default;
            var url = setting.LoginPageUrl;
            if (!string.IsNullOrEmpty(url))
            {
                url = formatUrl(url, setting.LoginFieldAgent, m_agent);
                url = formatUrl(url, setting.LoginFieldEmployee, m_employee);
                try
                {
                    Process.Start(url);
                }
                catch (Exception ex)
                {
                    LogHelper.Write("FireOnLogined", ex);
                }
            }
        }


        /// <summary>
        /// 调整座席队列信息控件。
        /// </summary>
        /// <param name="bStart"></param>
        void TuneQueueInfo(bool bStart)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = delegate { TuneQueueInfo(bStart); };
                this.BeginInvoke(mi);
                return;
            }
            if (bStart)
                tmr_queue.Start();
            else
                tmr_queue.Stop();
            //
            rlv_agents.ScrollEnabled = bStart;
            rlv_agents.Visible = bStart;
            rlv_agents.Text = "";
        }
        /// <summary>
        /// 调整通话时的菜单选项。
        /// </summary>
        /// <param name="bEnabled"></param>
        void TuneTalkingMenuItem(bool bEnabled)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = delegate { TuneTalkingMenuItem(bEnabled); };
                this.BeginInvoke(mi);
                return;
            }
            //
            tsmi_transfer.Enabled = bEnabled;
            tsmi_Conference.Enabled = bEnabled;
            //软外拨菜单
            tsmi_dialup.Enabled = !bEnabled;

            if (!bEnabled)  //销毁窗口实例
            {
                if (frmWay != null)
                {
                    frmWay.Close();
                    frmWay = null;
                }
            }
        }

        /// <summary>
        /// 可以输出行号的日志输出。
        /// </summary>
        /// <param name="msg">输出消息</param>
        /// <param name="lineId">调用的行号</param>
        void ShowResponse(string msg, int lineId)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = delegate { ShowResponse(msg, lineId); };
                this.BeginInvoke(mi);
                return;
            }

            LogHelper.Write("ShowResponse", "Line:{0} Msg:{1}", lineId, msg);
            Toast.Show(msg, 5);
        }

        /// <summary>
        /// 显示操作返回结果信息。
        /// </summary>
        /// <param name="msg"></param>
        void ShowResponse(string msg)
        {
            int lineId = 0;
            try { lineId = new System.Diagnostics.StackTrace(new StackFrame(1, true)).GetFrame(0).GetFileLineNumber(); }
            catch { }
            //输出
            ShowResponse(msg, lineId);
        }
        /// <summary>
        /// 拆分uuid信息。
        /// </summary>
        /// <param name="paraUuid"></param>
        /// <returns></returns>
        string ParseUuid(string paraUuid)
        {
            if (paraUuid.Contains("_"))
            {
                int pos = paraUuid.IndexOf("_");
                return paraUuid.Substring(0, pos);
            }
            return paraUuid;
        }

#if !USE_AHEAD_VOIP
        void ParseCommand(string cmd)
        {
            var paras = cmd.Split(new string[] { "/" }, StringSplitOptions.None);
            if (paras.Length > 1)
            {
                int _head = int.Parse(paras[0]);
                bool bSucess = paras[1] == "0";
                switch (_head)
                {
                    case 100: //状态变化
                        {
                            int _oldState = int.Parse(paras[1]);
                            int _newState = int.Parse(paras[2]);
                            switch (_newState)
                            {
                                case 0:
                                    ShowStatus("不可用");
                                    //停止刷新后续接听的座席清单 //add by niwz 2018.03.13
                                    TuneQueueInfo(false);
                                    //
                                    m_current_caller = "";
                                    m_talking_guid = "";
                                    m_cur_joincaller = "";
                                    break;
                                case 1:
                                    ShowStatus("空闲");
                                    //填写通话小结
                                    if (Properties.Settings.Default.SummarySupport)
                                    {
                                        if (m_isTalking && !string.IsNullOrEmpty(m_talking_guid))
                                            ShowSummaryForm(m_talking_guid);
                                    }
                                    //
                                    m_isTalking = false;
                                    m_talking_guid = "";
                                    m_current_caller = "";
                                    m_cur_joincaller = "";
                                    m_caller_muted = false;
                                    m_joincaller_muted = false;
                                    //
                                    TuneTalkingMenuItem(false);
                                    break;
                                case 2: ShowStatus("摘机"); break;
                                case 3: ShowStatus("拨号"); break;
                                case 4: ShowStatus("接收DTMF"); break;
                                case 5: ShowStatus("振铃"); break;
                                case 6:
                                    ShowStatus("通话");
                                    m_isTalking = true;
                                    //
                                    TuneTalkingMenuItem(true);
                                    break;
                                case 7: ShowStatus("催挂"); break;
                                case 13:
                                    {
                                        ShowStatus("免打扰");
                                        tsmi_dnd.Text = "置闲(&I)";
                                    }
                                    break;
                                default: ShowStatus("空闲"); break;
                            }
                        }
                        break;
                    case 101: //来电
                        {
                            //LPCTSTR Caller, LPCTSTR Called, LPCTSTR TrunkNum, LPCTSTR sData
                            beginTime = DateTime.Now;
                            m_talking_guid = ParseUuid(paras[4]);
                            m_current_caller = paras[1];
                            ShowPopup(paras[1], paras[2], paras[3], m_talking_guid);
                        }
                        break;
                    case 102: //签入成功
                        ShowResponse(bSucess ? "签入成功" : "签入失败");
                        TuneControl(bSucess);
                        //增加定时刷新后续接听的座席清单，默认为3个  //add by niwz 2018.03.13
                        if (bSucess)
                        {
                            TuneQueueInfo(true);
                            //增加签入成功时调用url地址  //add by niwz 2018.04.03
                            FireOnLogined();
                        }
                        break;
                    case 106: //转接成功
                        ShowResponse(bSucess ? "转接成功" : "转接失败");
                        break;
                    case 107: //软外拨成功
                        ShowResponse(bSucess ? "软外拨成功" : "软外拨失败");
                        break;
                    case 108: //置闲
                        ShowResponse(bSucess ? "置闲成功" : "置闲失败");
                        if (bSucess)
                            tsmi_dnd.Text = "置忙(&N)";
                        break;
                    case 109: //置忙
                        ShowResponse(bSucess ? "设置免打扰成功" : "设置免打扰失败");
                        if (paras[1] == "0")
                            tsmi_dnd.Text = "置闲(&I)";
                        break;
                    case 122:  //获取到座席队列信息
                        //122/0/分机号_员工号;分机号_员工号;分机号_员工号;/
                        var text = Properties.Settings.Default.QueueTitle;
                        var mode = Properties.Settings.Default.QueueMode;
                        if (mode == 1)
                        {
                            text += paras[2];
                            rlv_agents.Text = text;
                            break;
                        }
                        //分机号模式或员工号模式
                        var emps = paras[2].Split(new string[] { ";", "_" }, StringSplitOptions.RemoveEmptyEntries);
                        var pos = mode == 2 ? 0 : 1;
                        List<string> texts = new List<string>();
                        for (int idx = pos; idx < emps.Length; idx += 2)
                        {
                            if (!texts.Contains(emps[idx]))
                                texts.Add(emps[idx]);
                        }
                        //
                        rlv_agents.Text = text + string.Join(";", texts.ToArray());
                        break;
                    case 130:  //三方通话返回事件    //add by niwz 2018.03.13
                        if (!bSucess) m_cur_joincaller = "";
                        ShowResponse(bSucess ? "开始三方通话" : "添加三方通话失败");
                        break;
                    case 136:  //三方通话静音事件  //add by niwz 2018.03.13
                        //136/0/目标号码/Muted/|
                        bool bMuted = paras[3].ToLower() == "true";  //是否为静音操作
                        if (paras[2] == m_current_caller)
                            m_caller_muted = bMuted && bSucess;
                        else
                            m_joincaller_muted = bMuted && bSucess;
                        //
                        ShowResponse("号码:" + paras[2] + "静音操作" + (bSucess ? "成功" : "失败"));

                        break;
                }
            }
        }

        void OnReceivedData(ILXConnection c, string p)
        {
            if (!p.StartsWith("122"))
                LogHelper.Write("OnReceived", p);
            try
            {
                var args = p.Split(new string[] { "|", "  " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var s in args)
                {
                    ParseCommand(s);
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Write("OnReceivedError", ex);
            }
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled">启用/停用</param>
        void TuneControl(bool enabled)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { TuneControl(enabled); };
                this.BeginInvoke(mi);
                return;
            }
            m_isRunning = enabled;
            toolTip1.SetToolTip(this.iv_start, enabled ? "停止接入电话" : "开始接入电话");
            this.iv_start.Normal = enabled ? Properties.Resources.btn_stop : Properties.Resources.btn_start;
            tsmi_start.Text = enabled ? "停止接入(&S)" : "开始接入(&L)";
            tsmi_start.Image = enabled ? Properties.Resources.btn_stop : Properties.Resources.btn_start;
            tsmi_dialup.Enabled = tsmi_dnd.Enabled = enabled;
            gb_agents.Enabled = gb_ailink.Enabled = !enabled;
            //转接按钮
            //tsmi_transfer.Enabled = enabled;
        }

        void ShowStatus(string format, params object[] args)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { ShowStatus(format, args); };
                this.BeginInvoke(mi);
                return;
            }

            string text = format;
            if (args != null && args.Length > 0)
                text = string.Format(format, args);

            tsl_statu.Text = text;
        }
#if USE_AHEAD_VOIP
        void ShowPhoneTools(bool visibled = false)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { ShowPhoneTools(visibled); };
                this.BeginInvoke(mi);
                return;
            }

            ivHangup.Visible = visibled;
            ivAnswer.Visible = visibled;
        }
#endif

        #region 系统自动运行
        private void cbx_autorun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_autorun.Checked)
            {
                try
                {
                    string filepath = Assembly.GetExecutingAssembly().Location;
                    string runName = Path.GetFileNameWithoutExtension(filepath);
                    RegistryKey hkml = Registry.LocalMachine;
                    string keypath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                    if (Environment.OSVersion.Version.Major > 5 && Environment.OSVersion.Version.Minor > 0) //Windows 7
                    {
                        if (IntPtr.Size == 8) //64bit
                            keypath = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run";
                        else
                            hkml = Registry.CurrentUser;
                    }
                    RegistryKey runKey = hkml.OpenSubKey(keypath, true);
                    runKey.SetValue(runName, filepath);
                    runKey.Close();
                }
                catch (Exception ex)
                {
                    Toast.Show("设置系统自动运行失败，原因为：" + ex.Message);
                }
            }
            else
            {
                try
                {
                    string filepath = Assembly.GetExecutingAssembly().Location;
                    string runName = Path.GetFileNameWithoutExtension(filepath);
                    RegistryKey hkml = Registry.LocalMachine;
                    string keypath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                    if (Environment.OSVersion.Version.Major > 5 && Environment.OSVersion.Version.Minor > 0) //Windows 7
                    {
                        if (IntPtr.Size == 8) //64bit
                            keypath = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run";
                        else
                            hkml = Registry.CurrentUser;
                    }
                    RegistryKey runKey = hkml.OpenSubKey(keypath, true);
                    runKey.DeleteValue(runName);
                    runKey.Close();
                }
                catch (Exception ex)
                {
                    Toast.Show("取消系统自动运行失败，原因为：" + ex.Message);
                }
            }

            SaveSetting();
        }
        #endregion

        private void tsmi_dnd_Click(object sender, EventArgs e)
        {
            if (!m_isRunning)
                return;

            if (tsmi_dnd.Text == "置忙(&N)")
            {
#if USE_AHEAD_VOIP
                switch (ocx.LXSipSetDND())
                {
                    case DevOK: ShowStatus("免打扰"); break;
                    default: ShowStatus("置忙失败"); break;
                }
#else
                m_connection.Send("109/{0}/|", m_agent);
#endif
                tsmi_dnd.Text = "置闲(&I)";
            }
            else
            {
#if USE_AHEAD_VOIP
                switch (ocx.LXSipSetUnDND())
                {
                    case DevOK: ShowStatus("空闲"); break;
                    default: ShowStatus("置闲失败"); break;
                }
#else
                m_connection.Send("108/{0}/|", m_agent);
#endif
                tsmi_dnd.Text = "置忙(&N)";
            }
        }

        private void tsmi_showmain_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        bool m_IsHide = false;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE)
                {
                    this.Hide();
                    notifyIcon1.Visible = true;
                    m_IsHide = true;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            /*TimeSpan ts = DateTime.Now - beginTime;
            if (ts.Hours > 0)
                tsl_times.Text = string.Format("时长：{0}时{1}分{2}秒{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            else
                tsl_times.Text = string.Format("时长：{1}分{2}秒{3}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);*/
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (m_IsHide)
            {
                this.Show();
                m_IsHide = false;
            }
            else
            {
                this.Hide();
                m_IsHide = true;
            }
        }

        private void tsmi_about_Click(object sender, EventArgs e)
        {
            Toast.Show("杭州领先科技有限公司版权所有");
        }

        private void cbx_login_CheckedChanged(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void tsmi_dialup_Click(object sender, EventArgs e)
        {
            if (!m_isRunning)
                return;

            ShowDialupForm();
        }

        static frmDialup frmDialup = null;

        void ShowDialupForm(string phoneno = "")
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = () => { ShowDialupForm(phoneno); };
                this.BeginInvoke(mi);
                return;
            }
            if (frmDialup != null)
            {
                if (!frmDialup.IsDisposed)
                    frmDialup.Close();

                frmDialup = null;
            }

            frmDialup = new frmDialup();
            frmDialup.DialupSuccessed = () =>
            {
                if (m_isRunning)
                {
#if USE_AHEAD_VOIP
                    string phoneNo = frmDialup.PhoneNo;
                    int iFlag = phoneno.Length == m_agent.Length ? 0 : 1;
                    int iRet = ocx.LXSipDialCall(frmDialup.PhoneNo, iFlag);
                    switch (iRet)
                    {
                        case DevOK: ShowStatus("拨号成功"); break;
                        case DevAudioErr: ShowStatus("音频失败"); break;
                        default: ShowStatus("拨号失败"); break;
                    }
#else
                    m_current_caller = this.m_firstCode + frmDialup.PhoneNo;
                    m_connection.Send("107/{0}/{1}{2}/|", this.m_agent, this.m_firstCode, frmDialup.PhoneNo);
#endif
                    frmDialup.Close();
                    Interlocked.Increment(ref m_callId);
                }
                else
                    Toast.Show("未登录");
            };
            frmDialup.TopMost = true;
            frmDialup.PhoneNo = phoneno;
            int height = Screen.GetBounds(this).Height - Screen.GetWorkingArea(this).Height;
            frmDialup.Top = Screen.GetBounds(this).Height - frmDialup.Height - height - 5;
            frmDialup.Left = Screen.GetBounds(this).Width - frmDialup.Width - 5;
            frmDialup.Show(this);
        }

        int httpActionHandler(string action, params string[] parameters)
        {
            //当前拨号ID号
            if (action == "dialup")
            {
                var phoneno = parameters[0];
                var autodial = string.Compare(parameters[1], "true", true) == 0;
                if (autodial && m_isRunning)
                {
#if USE_AHEAD_VOIP
                    string phoneNo = frmDialup.PhoneNo;
                    int iFlag = phoneno.Length == m_agent.Length ? 0 : 1;
                    int iRet = ocx.LXSipDialCall(frmDialup.PhoneNo, iFlag);
                    switch (iRet)
                    {
                        case DevOK:
                            {
                                ShowStatus("拨号成功");
                                ShowPhoneTools(true);
                            }
                            break;
                        case DevAudioErr: ShowStatus("音频失败"); break;
                        default: ShowStatus("拨号失败"); break;
                    }
#else
                    //发送拨号指令 //107/8001/913958077789/
                    m_connection.Send("107/{0}/{1}{2}/|", this.m_agent, this.m_firstCode, phoneno);
#endif
                    Interlocked.Increment(ref m_callId);
                    return m_callId; //返回当前ID？？
                }
                else
                {
                    //显示拨号窗口
                    ShowDialupForm(phoneno);
                    Interlocked.Increment(ref m_callId);
                    return m_callId;
                }
            }
            else if (action == "query") //查询软外拨状态
            {
                int callId = -1;
                int.TryParse(parameters[0], out callId);
                if (callId < 1)
                {
                    //返回当前坐席的状态
                }
                else
                {
                    //返回当前通话的状态
                }
            }
            else if (action == "login") //签入
            {
                Login();
                return 0;
            }
            else if (action == "logout") //签出
            {
                Logout();
                return 0;
            }
            else if (action == "setdnd") //置忙
            {
                if (m_isRunning)
                {
#if USE_AHEAD_VOIP
                    switch (ocx.LXSipSetDND())
                    {
                        case DevOK: ShowStatus("免打扰"); break;
                        default: ShowStatus("置忙失败"); break;
                    }
#else
                    m_connection.Send("109/{0}/|", m_agent);
#endif
                    tsmi_dnd.Text = "置闲(&I)";
                    return 0;
                }
                return -1;
            }
            else if (action == "setundnd") //置闲
            {
                if (m_isRunning)
                {
#if USE_AHEAD_VOIP
                    switch (ocx.LXSipSetUnDND())
                    {
                        case DevOK: ShowStatus("空闲"); break;
                        default: ShowStatus("置闲失败"); break;
                    }
#else
                    m_connection.Send("108/{0}/|", m_agent);
#endif
                    tsmi_dnd.Text = "置忙(&N)";
                    return 0;
                }
                return -1;
            }
            return -1;
        }

        private void ivAnswer_Click(object sender, EventArgs e)
        {
#if USE_AHEAD_VOIP
            if (ocx != null)
                ocx.LXSipAnswer();
#endif
        }

        private void ivHangup_Click(object sender, EventArgs e)
        {
#if USE_AHEAD_VOIP
            if (ocx != null)
            {
                int iRet = ocx.LXSipHangup();
                LogHelper.Write("LXSipHangup", "Return Code:{0}", iRet);
            }
#endif
        }

        private void tsmi_transfer_Click(object sender, EventArgs e)
        {
            if (m_connection == null)
                return;
            //
            using (frmTransfer trans = new frmTransfer())
            {
                if (trans.ShowDialog(this) == DialogResult.Yes)
                {
                    m_connection.Send("106/{0}/{1}/|", this.m_agent, trans.TransferCaller);
                }
            }
        }

        private void tmr_queue_Tick(object sender, EventArgs e)
        {
            if (m_connection != null)  //122/分机号/查询数量/
                m_connection.Send("122/{0}/{1}/|", this.m_agent, m_queuecount);
        }


        frmThreeWay frmWay = null;                  //单件模式的通话状态
        string m_cur_joincaller = string.Empty;  //当前加入的第三方号码
        bool m_caller_muted = false;                 //目标号码是否静音
        bool m_joincaller_muted = false;           //三方号码是否静音

        private void tsmi_Conference_Click(object sender, EventArgs e)
        {
            if (m_connection == null)
                return;
            //
            if (frmWay == null || frmWay.IsDisposed || frmWay.Disposing)
            {
                frmWay = new frmThreeWay();
                frmWay.OnJoining += (n, c) =>
                {
                    //SendPacket("130/" + _agentId + "/" + ConfName +  "/" + Remark  +"/|");
                    m_connection.Send("130/{0}/{1}/{2}/|", m_agent, n, c);
                    m_current_caller = c;
                };
                frmWay.OnMuteChanged += (n, c, m) =>
                {
                    //SendPacket("136/" + _agentId +  "/"+ ConfName + "/"+ Caller + "/"+ bMute + "/|");
                    m_connection.Send("136/{0}/{1}/{2}/{3}/|", m_agent, n, c, m);
                };
            }
            //
            frmWay.Caller = m_current_caller;
            frmWay.JoinCaller = m_cur_joincaller;
            frmWay.SetMuted(m_caller_muted, m_joincaller_muted);
            frmWay.TopMost = true;
            //显示窗口
            frmWay.Show(this);
        }

        private void cms_main_Opened(object sender, EventArgs e)
        {
            tsmi_showmain.Enabled = !this.Visible;
        }
    }
}
