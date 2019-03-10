using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AheadTec.AilinkServer
{
    /// <summary>
    /// 发送器接口类。
    /// </summary>
    public interface ILXNetSender
    {
        string Id { get; }
        /// <summary>
        /// 开始发送器。。
        /// </summary>
        /// <param name="args"></param>
        void Open(string[] args);
        /// <summary>
        /// 关闭发送器。。
        /// </summary>
        void Close();
        /// <summary>
        /// 发送数据包。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Send(string format, params object[] args);
    }
    /// <summary>
    /// 网络连接事件委托。
    /// </summary>
    /// <param name="conn"></param>
    public delegate void LXConnectionEventHandler(ILXConnection conn);
    /// <summary>
    /// 网络连接接收到数据时的事件委托。
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="packet"></param>
    public delegate void LXConnectionReceivedEventHandler(ILXConnection conn, string packet);
    /// <summary>
    /// LX网络连接接口类。
    /// </summary>
    public interface ILXConnection : ILXNetSender, IDisposable
    {
        /// <summary>
        /// 接收到数据时触发的事件。
        /// </summary>
        event LXConnectionReceivedEventHandler OnReceived;
        /// <summary>
        /// 网络连接打开时触发的事件。
        /// </summary>
        event LXConnectionEventHandler OnOpened;
        /// <summary>
        /// 网络连接关闭时触发的事件。
        /// </summary>
        event LXConnectionEventHandler OnClosed;
        /// <summary>
        /// 远端终结点。
        /// </summary>
        IPEndPoint RemoteEndpoint { get; }

    }    
}
