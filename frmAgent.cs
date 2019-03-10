using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AlinkMessager
{
    public partial class frmAgent : Form
    {
        public frmAgent()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_agentno.Text))
            {
                MessageBox.Show("请输入当前的分机号！", "系统提示");
                return;
            }

            try
            {
                string filepath = Assembly.GetExecutingAssembly().Location;
                string runName = Path.GetFileNameWithoutExtension(filepath);
                RegistryKey hkml = Registry.LocalMachine;
                string keypath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                if (Environment.OSVersion.Version.Major > 5 && Environment.OSVersion.Version.Minor > 0) //Windows 7
                {
                    if (IntPtr.Size == 8) //64bit
                        keypath = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run";
                    else
                        hkml = Registry.CurrentUser;
                }                
                RegistryKey runKey = hkml.OpenSubKey(keypath, true);
                runKey.SetValue(runName, filepath);
                runKey.Close();
            }
            catch //(Exception ex)
            {
                /*Toast.Show("设置系统自动运行失败，原因为：" + ex.Message);*/
            }

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //applicationSettings
                XmlDocument doc = new XmlDocument();
                doc.Load(config.FilePath);
                var parentNode = doc.SelectSingleNode("/configuration/applicationSettings/AlinkMessager.Properties.Settings");
                foreach (XmlNode node in parentNode.ChildNodes)
                {
                    if (node.Attributes["name"] != null && (node.Attributes["name"].Value == "AgentNo" || node.Attributes["name"].Value == "AgentPwd"))
                    {
                        node.InnerXml = string.Format("<value>{0}</value>", tb_agentno.Text);
                    }
                }

                doc.Save(config.FilePath);
                //
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存分机号时出错，原因为：\r\n" + ex.Message + "\r\n请登录系统后手工设置！", "系统提示");
                return;
            }
        }
    }
}
