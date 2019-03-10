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
    public partial class frmTransfer : UIForm
    {

        public string TransferCaller { get { return string.Format("{0}{1}", cbb_firstcode.Text, tb_caller.Text); } }

        public frmTransfer()
        {
            InitializeComponent();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.TransferHistorySupport)
                {
                    var connStr = Properties.Settings.Default.CTIConnectString;
                    if (!string.IsNullOrEmpty(connStr))
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();
                            SqlCommand comm = conn.CreateCommand();
                            comm.CommandText = @"SELECT Caller,MAX(IvrTimeStart) LastTime FROM Thing_CallPhone 
WHERE DATEDIFF(DAY,IvrTimeStart,GETDATE()) <= 30 AND LEN(Caller) > 7
GROUP BY Caller
ORDER BY LastTime DESC";
                            DataTable src = new DataTable();
                            SqlDataAdapter sda = new SqlDataAdapter(comm);
                            sda.Fill(src);

                            //cbb_caller.DisplayMember = "Caller";
                            //cbb_caller.ValueMember = "Caller";
                            //cbb_caller.DataSource = src;
                            var source = new AutoCompleteStringCollection();
                            foreach (DataRow row in src.Rows)
                                source.Add(row["Caller"].ToString());
                            //
                            tb_caller.AutoCompleteCustomSource = source;
                            tb_caller.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            tb_caller.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        }
                    }
                }
                else//默认绑定内容  //modify by niwz 2018.03.22
                {
                    Utils.BindCompleteSource(tb_caller);
                }
            }
            catch
            {

            }
            var firstcodes = Properties.Settings.Default.FirstCodeList;
            cbb_firstcode.Items.Clear();
            foreach (var code in firstcodes)
                cbb_firstcode.Items.Add(code);
            //
            if (firstcodes.Count > 0)
                cbb_firstcode.Text = firstcodes[0];

        }

        private void gbtnSave_Click(object sender, EventArgs e)
        {
            if (tb_caller.Text.Length < 4)
            {
                Toast.Show("请输入要转接的号码！");
                return;
            }

            for (int idx = 0; idx < tb_caller.Text.Length; idx++)
            {
                if (!Char.IsNumber(tb_caller.Text[idx]))
                {
                    Toast.Show("请输入正确的转接号码！");
                    return;
                }
            }
            //更新呼叫历史
            if (!Properties.Settings.Default.TransferHistorySupport)
                Utils.UpdateCachedSource(tb_caller.Text);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
