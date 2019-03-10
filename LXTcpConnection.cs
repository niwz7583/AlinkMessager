using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AheadTec.AilinkServer
{
    /// <summary>
    /// TCP连接控制类。
    /// </summary>
    public class LXTcpConnection : ILXConnection, IDisposable
    {
        private readonly TcpClient _client;
        public TcpClient Client { get { return _client; } }

        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;

        private readonly string _id;
        /// <summary>
        /// 客户端连接唯一编号。
        /// </summary>
        public string Id { get { return _id; } }
        /// <summary>
        /// 连接的远端终结点。
        /// </summary>
        public IPEndPoint RemoteEndpoint { get { return !_disposing && _client != null ? (IPEndPoint)_client.Client.RemoteEndPoint : null; } }

        private bool _disposing;
        private bool _isRunning;

        /// <summary>
        /// 接收到数据时触发的事件。
        /// </summary>
        public event LXConnectionReceivedEventHandler OnReceived;
        /// <summary>
        /// 网络连接打开时触发的事件。
        /// </summary>
        public event LXConnectionEventHandler OnOpened;
        /// <summary>
        /// 网络连接关闭时触发的事件。
        /// </summary>
        public event LXConnectionEventHandler OnClosed;


        public LXTcpConnection(TcpClient client)
        {
            try
            {
                _client = client;
                _id = Guid.NewGuid().ToString("N");
                _reader = new StreamReader(_client.GetStream());
                _writer = new StreamWriter(_client.GetStream()) { AutoFlush = true };
            }
            catch (Exception ex)
            {
                LogHelper.Write("LXTcpConnection", ex);
            }
        }
        /// <summary>
        /// 开始发送器。。
        /// </summary>
        /// <param name="args"></param>
        public void Open(string[] args)
        {
            if (_isRunning)
                return;

            _isRunning = true;
            //启动接收线程
            ThreadPool.QueueUserWorkItem((o) => { StartReceive(); }, null);
            OnOpened?.Invoke(this);
            LogHelper.Write("LXTcpConnection", "客户端[{0}-{1}]启动接收数据...", _id, this.RemoteEndpoint);
        }
        /// <summary>
        /// 关闭发送器。。
        /// </summary>
        public void Close()
        {
            if (!_isRunning)
                return;

            _isRunning = false;
            if (_reader != null)
                _reader.Dispose();
            try
            {
                if (_writer != null)
                    _writer.Dispose();
            }
            catch { }
            try
            {
                if (_client != null)
                    _client.Close();
            }
            catch { }
            //
            FireClosed();
        }

        void StartReceive()
        {
            try
            {
                int bufLen = 1024;
                byte[] buffer = new byte[bufLen];
                NetworkStream stream = _client.GetStream();
                while (_isRunning && !_disposing)
                {
                    //while (stream.DataAvailable)
                    //{
                    int readBytes = stream.Read(buffer, 0, bufLen);
                    if (readBytes > 0)
                    {
                        //string msg = Encoding.UTF8.GetString(buffer, 0, readBytes);
                        string msg = Encoding.GetEncoding("gbk").GetString(buffer, 0, readBytes);
                        OnReceived?.Invoke(this, msg);
                    }
                    else
                    {
                        FireClosed();
                    }
                    //}
                    Thread.Sleep(5);
                }
            }
            catch (IOException) { FireClosed(); }
            catch (ArgumentOutOfRangeException)
            {
                if (!_disposing)
                    LogHelper.Write("LXTcpConnection", "ArgumentOutOfRangeException");
            }
            catch (ObjectDisposedException)
            {
                if (!_disposing)
                    LogHelper.Write("LXTcpConnection", "ObjectDisposedException");
                FireClosed();
            }
            catch (InvalidOperationException)
            {
                if (!_disposing)
                    LogHelper.Write("LXTcpConnection", "InvalidOperationException");
                FireClosed();
            }
            catch (Exception ex)
            {
                LogHelper.Write("LXTcpConnection", ex);
            }
        }

        protected void FireClosed()
        {
            OnClosed?.Invoke(this);
        }

        public void Send(string format, params object[] args)
        {
            if (args != null && args.Length > 0)
                Send(string.Format(format, args));
            else
                Send(format);
        }
        public void Send(string message)
        {
            try
            {
                if (String.IsNullOrEmpty(message)) return;
                if (_disposing) return;

                if (_writer == null) return;

                _writer.WriteLine(message);

                //定时发送的命令不输出日志
                if (!message.StartsWith("122"))
                    LogHelper.Write("LXConnectionSend", "向[{0}-{1}]发送消息[{2}]。", this.Id, this.RemoteEndpoint, message);
            }
            catch (IOException) { FireClosed(); }
            catch (ObjectDisposedException) { FireClosed(); }
            catch (Exception ex)
            {
                LogHelper.Write("LocalClientSend", ex);
            }
        }

        public void Dispose()
        {
            _disposing = true;
            this.Close();
        }
    }
}
