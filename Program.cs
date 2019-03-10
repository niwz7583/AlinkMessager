using AheadTec;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AlinkMessager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //获得当前登录的Windows用户标示
            /*System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                startInfo.Arguments = String.Join(" ", args);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
                System.Windows.Forms.Application.Exit();
                return;
            }*/

            if (HaveOtherInstance())
            {
                //MessageBox.Show("请不要重复运行本系统！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form frmMain = null;

            if (args != null && args.Length > 0)
            {
                frmMain = new frmAgent();
            }
            else
            {
                frmMain = new frmMain();
            }
            try
            {
                Application.Run(frmMain);
            }
            catch (Exception)
            { }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Write("CurrentDomain_UnhandledException", (Exception)e.ExceptionObject);
        }

        static bool HaveOtherInstance()
        {
            try
            {
                EventWaitHandle globalHandler = EventWaitHandle.OpenExisting("AilinkMessagerApp");
                globalHandler.Set();
                return true;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                EventWaitHandle globalHandler = new EventWaitHandle(true, EventResetMode.AutoReset, "AilinkMessagerApp");
                Thread monitor = new Thread(new ThreadStart(delegate ()
                {
                    while (true)
                    {
                        globalHandler.WaitOne();
                        string _mainFormString = "frmMain";
                        var _mainForm = Application.OpenForms[_mainFormString] as Form;
                        if (_mainForm != null)
                        {
                            if (_mainForm.InvokeRequired)
                                _mainForm.BeginInvoke(new MethodInvoker(delegate { _mainForm.Activate(); }));
                            else
                                _mainForm.Activate();
                        }
                    }
                }));
                monitor.IsBackground = true;
                monitor.Start();
                GC.KeepAlive(monitor);
                return false;
            }
        }
    }
}
