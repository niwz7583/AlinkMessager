namespace AlinkMessager
{
    partial class frmTransfer
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
            this.gbtnSave = new Glass.GlassButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_firstcode = new System.Windows.Forms.ComboBox();
            this.tb_caller = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gbtnSave
            // 
            this.gbtnSave.Location = new System.Drawing.Point(201, 124);
            this.gbtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.Size = new System.Drawing.Size(127, 38);
            this.gbtnSave.TabIndex = 3;
            this.gbtnSave.Text = "转接(&T.)";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(32, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "转接号码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(116, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "支持多个出局外显号";
            // 
            // cbb_firstcode
            // 
            this.cbb_firstcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_firstcode.FormattingEnabled = true;
            this.cbb_firstcode.Items.AddRange(new object[] {
            "9"});
            this.cbb_firstcode.Location = new System.Drawing.Point(113, 61);
            this.cbb_firstcode.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_firstcode.Name = "cbb_firstcode";
            this.cbb_firstcode.Size = new System.Drawing.Size(49, 23);
            this.cbb_firstcode.TabIndex = 7;
            this.cbb_firstcode.Text = "9";
            // 
            // tb_caller
            // 
            this.tb_caller.Location = new System.Drawing.Point(166, 61);
            this.tb_caller.Name = "tb_caller";
            this.tb_caller.Size = new System.Drawing.Size(158, 25);
            this.tb_caller.TabIndex = 8;
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 180);
            this.Controls.Add(this.tb_caller);
            this.Controls.Add(this.cbb_firstcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbtnSave);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTransfer";
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Text = "转接通话";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            this.Controls.SetChildIndex(this.gbtnSave, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbb_firstcode, 0);
            this.Controls.SetChildIndex(this.tb_caller, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton gbtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_firstcode;
        private System.Windows.Forms.TextBox tb_caller;
    }
}