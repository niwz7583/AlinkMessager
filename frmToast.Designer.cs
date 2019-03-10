namespace AheadTec
{
    partial class frmToast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.l_ticks = new System.Windows.Forms.Label();
            this.tmr_close = new System.Windows.Forms.Timer(this.components);
            this.ll_enter = new System.Windows.Forms.LinkLabel();
            this.ll_cancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 163);
            this.label1.TabIndex = 0;
            this.label1.Text = "确认是否要退出当前系统？";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_ticks
            // 
            this.l_ticks.AutoSize = true;
            this.l_ticks.Location = new System.Drawing.Point(10, 183);
            this.l_ticks.Name = "l_ticks";
            this.l_ticks.Size = new System.Drawing.Size(17, 12);
            this.l_ticks.TabIndex = 2;
            this.l_ticks.Text = "10";
            // 
            // tmr_close
            // 
            this.tmr_close.Enabled = true;
            this.tmr_close.Interval = 1000;
            this.tmr_close.Tick += new System.EventHandler(this.tmr_close_Tick);
            // 
            // ll_enter
            // 
            this.ll_enter.AutoSize = true;
            this.ll_enter.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_enter.LinkColor = System.Drawing.Color.White;
            this.ll_enter.Location = new System.Drawing.Point(298, 183);
            this.ll_enter.Name = "ll_enter";
            this.ll_enter.Size = new System.Drawing.Size(40, 16);
            this.ll_enter.TabIndex = 3;
            this.ll_enter.TabStop = true;
            this.ll_enter.Text = "确定";
            this.ll_enter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_enter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_enter_LinkClicked);
            // 
            // ll_cancel
            // 
            this.ll_cancel.AutoSize = true;
            this.ll_cancel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_cancel.LinkColor = System.Drawing.Color.White;
            this.ll_cancel.Location = new System.Drawing.Point(350, 183);
            this.ll_cancel.Name = "ll_cancel";
            this.ll_cancel.Size = new System.Drawing.Size(40, 16);
            this.ll_cancel.TabIndex = 3;
            this.ll_cancel.TabStop = true;
            this.ll_cancel.Text = "取消";
            this.ll_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll_cancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_cancel_LinkClicked);
            // 
            // frmToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(411, 212);
            this.Controls.Add(this.ll_cancel);
            this.Controls.Add(this.ll_enter);
            this.Controls.Add(this.l_ticks);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmToast";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmToast";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmToast_FormClosing);
            this.Load += new System.EventHandler(this.frmToast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_ticks;
        private System.Windows.Forms.Timer tmr_close;
        private System.Windows.Forms.LinkLabel ll_enter;
        private System.Windows.Forms.LinkLabel ll_cancel;
    }
}