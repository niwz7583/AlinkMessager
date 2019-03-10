using AheadTec;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace AlinkMessager
{
    /// <summary>
    /// 操作委托句柄。
    /// </summary>
    /// <param name="action"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public delegate int ActionHandler(string action, params string[] parameters);

    /// <summary>
    /// 基于Http协议的服务端。
    /// </summary>
    public class LXHttpServer : IDisposable
    {
        /// <summary>
        /// 侦听端口号。
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 是否正在运行。
        /// </summary>
        public bool IsRunning { get; private set; }

        public bool IsDisposing { get; private set; }

        protected HttpListener m_listener = null;

        readonly ActionHandler _actionHandler;

        protected List<string> m_supportActions = new List<string>(new string[] { "login", "logout", "setdnd", "setundnd", "dialup", "query" });

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="port"></param>
        public LXHttpServer(ActionHandler handler, int port = 8008)
        {
            this.Port = port;
            _actionHandler = handler;
        }
        /// <summary>
        /// 打开Web服务器。
        /// </summary>
        /// <param name="args"></param>
        public void Open(string[] args)
        {
            if (!HttpListener.IsSupported)
            {
                LogHelper.Write("LXHttpServer", "LXHttpServer必须在Windows XP SP2 或者 Server 2003以上版本的操作系统才能运行。");
                return;
            }
            if (IsRunning)
                return;

            IsRunning = true;
            ThreadPool.QueueUserWorkItem(HttpServerBody);
        }

        protected virtual void HttpServerBody(object state)
        {
            try
            {
                m_listener = new HttpListener();
                m_listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                m_listener.Prefixes.Add(string.Format("http://*:{0}/", this.Port));
                m_listener.Start();
            }
            catch (Exception ex)
            {
                LogHelper.Write("LXHttpServerBody", ex.Message);
                return;
            }

            //开始接受访问
            while (IsRunning && !IsDisposing)
            {
                try
                {
                    var req = m_listener.GetContext();
                    ThreadPool.QueueUserWorkItem(ProcessHttpListenerContext, req);
                }
                catch { }
                Thread.Sleep(10);
            }
        }

        protected virtual void ProcessHttpListenerContext(object state)
        {
            HttpListenerContext cxt = state as HttpListenerContext;
            var res = cxt.Response;
            var req = cxt.Request;
            try
            {
                var flag = req.QueryString["flag"];
                if (string.Compare(flag, "lxkj123-=", true) != 0)
                {
                    WriteString(res, 300, "非法的页面调用。");
                    return;
                }
                var page = req.Url.LocalPath;

                var act = req.QueryString["action"];
                if (!m_supportActions.Contains(act))
                {
                    WriteString(res, 302, "不支持的操作类型。");
                    return;
                }
                if (_actionHandler == null)
                {
                    WriteString(res, 301, "接口当前不可用！");
                    return;
                }
                //处理操作
                if (act == "dialup")
                {
                    var phoneno = req.QueryString["phoneno"];
                    var autodial = req.QueryString["autodial"];
                    if (string.IsNullOrEmpty(act))
                    {
                        WriteString(res, 303, "提交的参数不正确！");
                        return;
                    }
                    int ret = _actionHandler(act, phoneno, autodial);
                    //当前软外拨操作的状态
                    WriteString(res, 200, ret.ToString());
                }
                else if (act == "query") //查询状态
                {
                    var callid = req.QueryString["callid"]; //查询通话ID状态
                    var extn = req.QueryString["extnstate"]; //查询当前分机状态
                    if (string.IsNullOrEmpty(callid) && string.IsNullOrEmpty(extn))
                    {
                        WriteString(res, 303, "提交的参数不正确！");
                        return;
                    }
                    int ret = _actionHandler(act, callid, extn);
                    //当前拨号的状态记录
                    WriteString(res, 200, ret.ToString());
                }
                else //其他操作
                {
                    int ret = _actionHandler(act);
                    //当前拨号的状态记录
                    WriteString(res, 200, ret.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteString(res, 305, ex.Message);
            }
            finally
            {
                try
                {
                    if (cxt != null)
                        cxt.Response.OutputStream.Close();
                }
                catch { }
            }
        }

        protected virtual void WriteString(HttpListenerResponse response, int statusCode, string info)
        {
            try
            {
                string retStr = string.Format("{{\"statusCode\":{0} ,\"message\": \"{1}\"}}", statusCode, info);
                byte[] buffer = Encoding.UTF8.GetBytes(retStr);
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Flush();
            }
            catch (Exception ex)
            {
                LogHelper.Write("LXHttpServerWriteString", ex.Message);
            }
        }

        /// <summary>
        /// 关闭Web服务器。
        /// </summary>
        public void Close()
        {
            this.IsRunning = false;
            Thread.Sleep(100);
            if (m_listener != null)
                m_listener.Stop();
        }
        /// <summary>
        /// 销毁当前对象。
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
