namespace AlinkMessager
{
    partial class frmDialup
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
            this.tb_phoneno = new System.Windows.Forms.TextBox();
            this.pb_dialup = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dialup)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_phoneno
            // 
            this.tb_phoneno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(139)))), ((int)(((byte)(170)))));
            this.tb_phoneno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_phoneno.Font = new System.Drawing.Font("新宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_phoneno.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_phoneno.Location = new System.Drawing.Point(8, 37);
            this.tb_phoneno.Name = "tb_phoneno";
            this.tb_phoneno.Size = new System.Drawing.Size(311, 55);
            this.tb_phoneno.TabIndex = 3;
            this.tb_phoneno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_phoneno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_phoneno_KeyPress);
            // 
            // pb_dialup
            // 
            this.pb_dialup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_dialup.Image = global::AlinkMessager.Properties.Resources.DialPan;
            this.pb_dialup.Location = new System.Drawing.Point(5, 25);
            this.pb_dialup.Name = "pb_dialup";
            this.pb_dialup.Size = new System.Drawing.Size(318, 407);
            this.pb_dialup.TabIndex = 4;
            this.pb_dialup.TabStop = false;
            this.pb_dialup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_dialup_MouseClick);
            // 
            // frmDialup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 438);
            this.Controls.Add(this.tb_phoneno);
            this.Controls.Add(this.pb_dialup);
            this.Name = "frmDialup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "软外拨";
            this.Controls.SetChildIndex(this.pb_dialup, 0);
            this.Controls.SetChildIndex(this.tb_phoneno, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pb_dialup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_phoneno;
        private System.Windows.Forms.PictureBox pb_dialup;
    }
}