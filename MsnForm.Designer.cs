namespace AlinkMessager
{
    partial class MsnForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.l_called = new System.Windows.Forms.Label();
            this.l_caller = new System.Windows.Forms.Label();
            this.l_ticks = new System.Windows.Forms.Label();
            this.ll_copy = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "来电号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "被叫号码：";
            // 
            // l_called
            // 
            this.l_called.AutoSize = true;
            this.l_called.BackColor = System.Drawing.Color.Transparent;
            this.l_called.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_called.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_called.Location = new System.Drawing.Point(100, 76);
            this.l_called.Name = "l_called";
            this.l_called.Size = new System.Drawing.Size(88, 16);
            this.l_called.TabIndex = 4;
            this.l_called.Text = "4001234567";
            // 
            // l_caller
            // 
            this.l_caller.AutoSize = true;
            this.l_caller.BackColor = System.Drawing.Color.Transparent;
            this.l_caller.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_caller.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_caller.Location = new System.Drawing.Point(99, 48);
            this.l_caller.Name = "l_caller";
            this.l_caller.Size = new System.Drawing.Size(96, 16);
            this.l_caller.TabIndex = 3;
            this.l_caller.Text = "13888888888";
            // 
            // l_ticks
            // 
            this.l_ticks.AutoSize = true;
            this.l_ticks.BackColor = System.Drawing.Color.Transparent;
            this.l_ticks.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ticks.ForeColor = System.Drawing.Color.DarkOrange;
            this.l_ticks.Location = new System.Drawing.Point(192, 117);
            this.l_ticks.Name = "l_ticks";
            this.l_ticks.Size = new System.Drawing.Size(24, 16);
            this.l_ticks.TabIndex = 5;
            this.l_ticks.Text = "45";
            // 
            // ll_copy
            // 
            this.ll_copy.ActiveLinkColor = System.Drawing.Color.White;
            this.ll_copy.AutoSize = true;
            this.ll_copy.BackColor = System.Drawing.Color.Transparent;
            this.ll_copy.LinkColor = System.Drawing.Color.White;
            this.ll_copy.Location = new System.Drawing.Point(13, 113);
            this.ll_copy.Name = "ll_copy";
            this.ll_copy.Size = new System.Drawing.Size(53, 12);
            this.ll_copy.TabIndex = 6;
            this.ll_copy.TabStop = true;
            this.ll_copy.Text = "复制号码";
            this.ll_copy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_copy_LinkClicked);
            // 
            // MsnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(222, 140);
            this.Controls.Add(this.ll_copy);
            this.Controls.Add(this.l_ticks);
            this.Controls.Add(this.l_called);
            this.Controls.Add(this.l_caller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "MsnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "新来电";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MsnForm_FormClosing);
            this.Load += new System.EventHandler(this.MsnForm_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.l_caller, 0);
            this.Controls.SetChildIndex(this.l_called, 0);
            this.Controls.SetChildIndex(this.l_ticks, 0);
            this.Controls.SetChildIndex(this.ll_copy, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_called;
        private System.Windows.Forms.Label l_caller;
        private System.Windows.Forms.Label l_ticks;
        private System.Windows.Forms.LinkLabel ll_copy;
    }
}