using ICSU.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AlinkMessager
{
    public partial class MsnForm : UIForm
    {
        /// <summary>
        /// 来电号码。
        /// </summary>
        public string Caller { get { return l_caller.Text; } set { l_caller.Text = value; } }
        /// <summary>
        /// 被叫号码。
        /// </summary>
        public string Called { get { return l_called.Text; } set { l_called.Text = value; } }

        int _interval = 45;
        Timer tmr_close;

        public MsnForm()
        {
            InitializeComponent();
            tmr_close = new Timer();
            tmr_close.Interval = 1000;
            tmr_close.Tick += (s, e) =>
            {
                _interval--;
                l_ticks.Text = _interval.ToString();
                if (_interval == 0)
                {
                    this.Close();
                }
            };
        }

        private void MsnForm_Load(object sender, EventArgs e)
        {
            int height = Screen.GetBounds(this).Height - Screen.GetWorkingArea(this).Height;
            this.Top = Screen.GetBounds(this).Height - this.Height - height - 5;
            this.Left = Screen.GetBounds(this).Width - this.Width - 5;
            NativeMethods.AnimateWindow(this.Handle, 500, NativeMethods.AW_VER_NEGATIVE);

            tmr_close.Enabled = true;
        }

        private void MsnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.AnimateWindow(this.Handle, 2000, NativeMethods.AW_SLIDE | NativeMethods.AW_VER_POSITIVE | NativeMethods.AW_BLEND);
        }

        private void ll_copy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(this.Caller);
        }
    }
}
