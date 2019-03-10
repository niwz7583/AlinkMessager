namespace AlinkMessager
{
    partial class frmSummary
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
            this.rb_checked = new System.Windows.Forms.RadioButton();
            this.rb_uncheck = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_descript = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gbtnSave
            // 
            this.gbtnSave.Location = new System.Drawing.Point(183, 229);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.Size = new System.Drawing.Size(95, 32);
            this.gbtnSave.TabIndex = 2;
            this.gbtnSave.Text = "保存(&S.)";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "是否首次解决:";
            // 
            // rb_checked
            // 
            this.rb_checked.AutoSize = true;
            this.rb_checked.BackColor = System.Drawing.Color.Transparent;
            this.rb_checked.ForeColor = System.Drawing.Color.White;
            this.rb_checked.Location = new System.Drawing.Point(107, 38);
            this.rb_checked.Name = "rb_checked";
            this.rb_checked.Size = new System.Drawing.Size(35, 16);
            this.rb_checked.TabIndex = 4;
            this.rb_checked.TabStop = true;
            this.rb_checked.Text = "是";
            this.rb_checked.UseVisualStyleBackColor = false;
            // 
            // rb_uncheck
            // 
            this.rb_uncheck.AutoSize = true;
            this.rb_uncheck.BackColor = System.Drawing.Color.Transparent;
            this.rb_uncheck.ForeColor = System.Drawing.Color.White;
            this.rb_uncheck.Location = new System.Drawing.Point(173, 38);
            this.rb_uncheck.Name = "rb_uncheck";
            this.rb_uncheck.Size = new System.Drawing.Size(35, 16);
            this.rb_uncheck.TabIndex = 5;
            this.rb_uncheck.TabStop = true;
            this.rb_uncheck.Text = "否";
            this.rb_uncheck.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "通话过程小结:";
            // 
            // tb_descript
            // 
            this.tb_descript.Location = new System.Drawing.Point(19, 87);
            this.tb_descript.Multiline = true;
            this.tb_descript.Name = "tb_descript";
            this.tb_descript.Size = new System.Drawing.Size(259, 122);
            this.tb_descript.TabIndex = 7;
            // 
            // frmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 276);
            this.Controls.Add(this.tb_descript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rb_uncheck);
            this.Controls.Add(this.rb_checked);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbtnSave);
            this.Name = "frmSummary";
            this.Text = "通话过程小结";
            this.Controls.SetChildIndex(this.gbtnSave, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rb_checked, 0);
            this.Controls.SetChildIndex(this.rb_uncheck, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tb_descript, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton gbtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_checked;
        private System.Windows.Forms.RadioButton rb_uncheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_descript;
    }
}