using AheadTec;
using ICSU.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AlinkMessager
{
    public partial class frmThreeWay : ICSU.Controls.UIForm
    {
        /// <summary>
        /// 对端号码。
        /// </summary>
        public string Caller
        {
            get { return lbl_caller.Text; }
            set
            {
                lbl_caller.Text = value;
                cbx_mute_caller.Visible = !string.IsNullOrEmpty(this.Caller);
            }
        }
        /// <summary>
        /// 加入的号码。
        /// </summary>
        public string JoinCaller
        {
            get
            {
                if (string.IsNullOrEmpty(tb_caller.Text))
                    return lbl_joincaller.Text;
                //添加出局号
                return cbb_firstcode.Text + tb_caller.Text;
            }
            set
            {
                lbl_joincaller.Text = value;
                cbx_mute_joincaller.Visible = !string.IsNullOrEmpty(this.JoinCaller);
                gbtnSave.Visible = !string.IsNullOrEmpty(this.JoinCaller);
                tb_caller.Text = value;
            }
        }

        bool m_isSetMuted = false;
        /// <summary>
        /// 设置号码的静音状态。
        /// </summary>
        /// <param name="callerMuted"></param>
        /// <param name="joinCallerMuted"></param>
        public void SetMuted(bool callerMuted, bool joinCallerMuted)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker mi = delegate { SetMuted(callerMuted, joinCallerMuted); };
                this.BeginInvoke(mi);
                return;
            }

            m_isSetMuted = true;
            cbx_mute_caller.Checked = callerMuted;
            cbx_mute_joincaller.Checked = joinCallerMuted;
            m_isSetMuted = false;
            //已经静音的，说明已在会议中
            if (callerMuted || joinCallerMuted || !string.IsNullOrEmpty(this.JoinCaller))
                gbtnSave.Visible = false;
        }

        /// <summary>
        /// 静音操作变化事件。
        /// </summary>
        public event lxkj_threeway_mute_changed OnMuteChanged;
        /// <summary>
        /// 正在加入三方通话事件。
        /// </summary>
        public event lxkj_threeway_caller_arrived OnJoining;

        public frmThreeWay()
        {
            InitializeComponent();
            //绑定缓存数据源  //add by niwz 2018.03.16
            Utils.BindCompleteSource(tb_caller);
        }

        private void frmThreeWay_Load(object sender, EventArgs e)
        {
            var firstcodes = Properties.Settings.Default.FirstCodeList;
            cbb_firstcode.Items.Clear();
            foreach (var code in firstcodes)
                cbb_firstcode.Items.Add(code);
            //
            if (firstcodes.Count > 0)
                cbb_firstcode.Text = firstcodes[0];
        }

        private void gbtnSave_Click(object sender, EventArgs e)
        {
            if (tb_caller.Text.Length < 4)
            {
                Toast.Show("请输入要转接的号码！");
                return;
            }

            for (int idx = 0; idx < tb_caller.Text.Length; idx++)
            {
                if (!Char.IsNumber(tb_caller.Text[idx]))
                {
                    Toast.Show("请输入正确的转接号码！");
                    return;
                }
            }
            //缓存拨号号码 //add by niwz 2018.03.15
            Utils.UpdateCachedSource(this.JoinCaller);
            //触发事件
            OnJoining?.Invoke(this.Caller, this.JoinCaller);
            //
            gbtnSave.Visible = false;
        }

        private void cbx_mute_caller_CheckedChanged(object sender, EventArgs e)
        {
            if (m_isSetMuted)
                return;
            //处理目标号码的静音操作
            OnMuteChanged?.Invoke(this.Caller, lbl_caller.Text, cbx_mute_caller.Checked);
        }

        private void cbx_mute_joincaller_CheckedChanged(object sender, EventArgs e)
        {
            if (m_isSetMuted)
                return;
            //处理三方号码的静音操作
            OnMuteChanged?.Invoke(this.Caller, lbl_joincaller.Text, cbx_mute_joincaller.Checked);
        }

        private void tb_caller_TextChanged(object sender, EventArgs e)
        {
            this.JoinCaller = tb_caller.Text;
        }
    }

    /// <summary>
    /// 三方通话静音触发委托。
    /// </summary>
    /// <param name="confName"></param>
    /// <param name="caller"></param>
    /// <param name="bMute"></param>
    public delegate void lxkj_threeway_mute_changed(string confName, string caller, bool bMute);

    /// <summary>
    /// 三方通话设置成功触发事件。
    /// </summary>
    /// <param name="confName"></param>
    /// <param name="caller"></param>
    public delegate void lxkj_threeway_caller_arrived(string confName, string caller);
}
