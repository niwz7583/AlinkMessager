using AlinkMessager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AheadTec
{

    public partial class frmToast : Form
    {
        int _interval = 10;

        /// <summary>
        /// 提示内容。
        /// </summary>
        public string Title { get { return label1.Text; } set { label1.Text = value; } }

        /// <summary>
        /// 显示的时长，默认为10秒。
        /// </summary>
        public int Interval { get { return _interval; } set { _interval = value; } }

        /// <summary>
        /// 是否显示“取消”按钮。
        /// </summary>
        public bool ShowCancelButton { get; set; }

        public Action OnDialogYes { get; set; }

        public frmToast()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //GraphicsPath Myformpath = new GraphicsPath();
            //Myformpath.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            //this.Region = new Region(Myformpath);
            base.OnPaint(e);
        }

        private void tmr_close_Tick(object sender, EventArgs e)
        {
            _interval--;
            l_ticks.Text = _interval.ToString();
            if (_interval == 0)
            {
                this.Close();
            }
        }

        private void frmToast_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = (Screen.GetBounds(this).Width - this.Width) / 2;
            NativeMethods.AnimateWindow(this.Handle, 500, NativeMethods.AW_VER_POSITIVE);

            tmr_close.Enabled = true;
        }

        private void frmToast_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.AnimateWindow(this.Handle, 2000, NativeMethods.AW_SLIDE | NativeMethods.AW_VER_NEGATIVE | NativeMethods.AW_BLEND);
        }

        private void ll_enter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            OnDialogYes?.Invoke();
            this.Close();
        }

        private void ll_cancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
    public delegate void Action();
    /// <summary>
    /// 动态显示消息窗体。
    /// </summary>
    public class Toast
    {
        public static void Show(string title = "", int itvl = 10, bool cancelButton = true, Action okHandler = null)
        {
            //单件？？
            new frmToast()
            {
                OnDialogYes = okHandler,
                Title = title,
                Interval = itvl,
                ShowCancelButton = cancelButton
            }.Show();
        }

        public static void Popup(string caller, string called)
        {
            new MsnForm() { Caller = caller, Called = called }.Show();
        }
    }
}
