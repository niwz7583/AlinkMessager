using AheadTec;
using ICSU.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AlinkMessager
{

    public delegate void DialupActionHandler();

    public partial class frmDialup : UIForm
    {
        public DialupActionHandler DialupSuccessed;

        Rectangle[] rectangles = new Rectangle[] { new Rectangle(106,274,106,67),new Rectangle(0,72,106,67), new Rectangle(106,72,106,67), new Rectangle(212,72,106,67),
            new Rectangle(0,139,106,67), new Rectangle(106,139,106,67), new Rectangle(212,139,106,67),
            new Rectangle(0,206,106,67), new Rectangle(106,206,106,67), new Rectangle(212,206,106,67),
            //new Rectangle(0,274,106,67), new Rectangle(212,274,106,67), //*#
            new Rectangle(106,341,106,67),new Rectangle(212,341,106,67) };

        public string PhoneNo { get { return tb_phoneno.Text; } set { tb_phoneno.Text = value; tb_phoneno.SelectionStart = tb_phoneno.Text.Length; } }

        public frmDialup()
        {
            InitializeComponent();
            //绑定缓存数据源  //add by niwz 2018.03.16
            Utils.BindCompleteSource(tb_phoneno);
        }

        private void pb_dialup_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rectangles.Length; i++)
            {
                if (rectangles[i].Contains(e.Location))
                {
                    if (i < 10)
                    {
                        tb_phoneno.Text += i.ToString();
                        tb_phoneno.SelectionStart = tb_phoneno.Text.Length;
                    }
                    else if (i == 10) //拨号
                    {
                        if (string.IsNullOrEmpty(tb_phoneno.Text))
                        {
                            Toast.Show("请输入要外拨的号码！");
                            return;
                        }

                        //缓存拨号号码 //add by niwz 2018.03.15
                        Utils.UpdateCachedSource(this.PhoneNo);
                        //触发拨号事件
                        this.DialupSuccessed?.Invoke();
                    }
                    else if (i == 11)
                    {
                        tb_phoneno.Text = tb_phoneno.Text.Substring(0, tb_phoneno.Text.Length - 1);
                        tb_phoneno.SelectionStart = tb_phoneno.Text.Length;
                    }
                }
            }
        }

        private void tb_phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
