namespace AlinkMessager
{
    partial class frmThreeWay
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbb_firstcode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbtnSave = new Glass.GlassButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_caller = new System.Windows.Forms.Label();
            this.lbl_joincaller = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_mute_caller = new System.Windows.Forms.CheckBox();
            this.cbx_mute_joincaller = new System.Windows.Forms.CheckBox();
            this.tb_caller = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbb_firstcode
            // 
            this.cbb_firstcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_firstcode.FormattingEnabled = true;
            this.cbb_firstcode.Items.AddRange(new object[] {
            "9"});
            this.cbb_firstcode.Location = new System.Drawing.Point(117, 58);
            this.cbb_firstcode.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_firstcode.Name = "cbb_firstcode";
            this.cbb_firstcode.Size = new System.Drawing.Size(49, 23);
            this.cbb_firstcode.TabIndex = 10;
            this.cbb_firstcode.Text = "9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(36, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "添加号码:";
            // 
            // gbtnSave
            // 
            this.gbtnSave.Location = new System.Drawing.Point(217, 96);
            this.gbtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.Size = new System.Drawing.Size(127, 38);
            this.gbtnSave.TabIndex = 11;
            this.gbtnSave.Text = "确定(&E.)";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Ivory;
            this.label2.Location = new System.Drawing.Point(36, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "对方号码:";
            // 
            // lbl_caller
            // 
            this.lbl_caller.AutoSize = true;
            this.lbl_caller.BackColor = System.Drawing.Color.Transparent;
            this.lbl_caller.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_caller.ForeColor = System.Drawing.Color.Ivory;
            this.lbl_caller.Location = new System.Drawing.Point(123, 174);
            this.lbl_caller.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_caller.Name = "lbl_caller";
            this.lbl_caller.Size = new System.Drawing.Size(119, 19);
            this.lbl_caller.TabIndex = 13;
            this.lbl_caller.Text = "13958077789";
            // 
            // lbl_joincaller
            // 
            this.lbl_joincaller.AutoSize = true;
            this.lbl_joincaller.BackColor = System.Drawing.Color.Transparent;
            this.lbl_joincaller.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_joincaller.ForeColor = System.Drawing.Color.Ivory;
            this.lbl_joincaller.Location = new System.Drawing.Point(123, 210);
            this.lbl_joincaller.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_joincaller.Name = "lbl_joincaller";
            this.lbl_joincaller.Size = new System.Drawing.Size(0, 19);
            this.lbl_joincaller.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Ivory;
            this.label4.Location = new System.Drawing.Point(36, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "三方号码:";
            // 
            // cbx_mute_caller
            // 
            this.cbx_mute_caller.AutoSize = true;
            this.cbx_mute_caller.BackColor = System.Drawing.Color.Transparent;
            this.cbx_mute_caller.ForeColor = System.Drawing.Color.White;
            this.cbx_mute_caller.Location = new System.Drawing.Point(276, 178);
            this.cbx_mute_caller.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_mute_caller.Name = "cbx_mute_caller";
            this.cbx_mute_caller.Size = new System.Drawing.Size(59, 19);
            this.cbx_mute_caller.TabIndex = 16;
            this.cbx_mute_caller.Text = "静音";
            this.cbx_mute_caller.UseVisualStyleBackColor = false;
            this.cbx_mute_caller.CheckedChanged += new System.EventHandler(this.cbx_mute_caller_CheckedChanged);
            // 
            // cbx_mute_joincaller
            // 
            this.cbx_mute_joincaller.AutoSize = true;
            this.cbx_mute_joincaller.BackColor = System.Drawing.Color.Transparent;
            this.cbx_mute_joincaller.ForeColor = System.Drawing.Color.White;
            this.cbx_mute_joincaller.Location = new System.Drawing.Point(276, 209);
            this.cbx_mute_joincaller.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_mute_joincaller.Name = "cbx_mute_joincaller";
            this.cbx_mute_joincaller.Size = new System.Drawing.Size(59, 19);
            this.cbx_mute_joincaller.TabIndex = 17;
            this.cbx_mute_joincaller.Text = "静音";
            this.cbx_mute_joincaller.UseVisualStyleBackColor = false;
            this.cbx_mute_joincaller.CheckedChanged += new System.EventHandler(this.cbx_mute_joincaller_CheckedChanged);
            // 
            // tb_caller
            // 
            this.tb_caller.Location = new System.Drawing.Point(173, 58);
            this.tb_caller.Name = "tb_caller";
            this.tb_caller.Size = new System.Drawing.Size(171, 25);
            this.tb_caller.TabIndex = 18;
            this.tb_caller.TextChanged += new System.EventHandler(this.tb_caller_TextChanged);
            // 
            // frmThreeWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(379, 272);
            this.Controls.Add(this.tb_caller);
            this.Controls.Add(this.cbx_mute_joincaller);
            this.Controls.Add(this.cbx_mute_caller);
            this.Controls.Add(this.lbl_joincaller);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_caller);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbtnSave);
            this.Controls.Add(this.cbb_firstcode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmThreeWay";
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Text = "三方通话";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmThreeWay_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbb_firstcode, 0);
            this.Controls.SetChildIndex(this.gbtnSave, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbl_caller, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lbl_joincaller, 0);
            this.Controls.SetChildIndex(this.cbx_mute_caller, 0);
            this.Controls.SetChildIndex(this.cbx_mute_joincaller, 0);
            this.Controls.SetChildIndex(this.tb_caller, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_firstcode;
        private System.Windows.Forms.Label label1;
        private Glass.GlassButton gbtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_caller;
        private System.Windows.Forms.Label lbl_joincaller;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbx_mute_caller;
        private System.Windows.Forms.CheckBox cbx_mute_joincaller;
        private System.Windows.Forms.TextBox tb_caller;
    }
}
