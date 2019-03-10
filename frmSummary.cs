using AheadTec;
using ICSU.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlinkMessager
{
    public partial class frmSummary : UIForm
    {
        public string CallGuid { get; set; }
        public frmSummary()
        {
            InitializeComponent();
        }

        private void gbtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_descript.Text))
            {
                Toast.Show("请输入通话过程小结内容！");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.CTIConnectString))
                {
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Format("UPDATE Thing_CallPhone SET cIsFirstSolve = {2},cSolveDescription = '{1}' WHERE sGUID = '{0}'", 
                        CallGuid, tb_descript.Text, rb_checked.Checked ? 1 : 0);
                    comm.ExecuteNonQuery();
                    Toast.Show("数据保存成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Toast.Show(string.Format("数据保存失败，原因为：\r\n {0}", ex.Message));
            }
        }
    }
}
