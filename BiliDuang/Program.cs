using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace BiliDuang
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            env.mainForm = new MainForm
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            SystemEvents.UserPreferenceChanging += new UserPreferenceChangingEventHandler(Other.SystemEvents_UserPreferenceChanging);
#if !DEBUG
            try
            {
                Application.Run(env.mainForm);
            }
            catch (Exception e)
            {                
                string dmpname = Environment.CurrentDirectory+"/" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".crash";
                //File.Create(dmpname);
                File.WriteAllText(dmpname, "======= BiliDuang CrashDump ===========\r\nVersion: "+Settings.versionName+" ("+Settings.versionCode+")\r\nCrash Message:"+e.Message + "\r\nTrance:\r\n" + e.StackTrace);
                MessageBox.Show(e.StackTrace, "发生错误!错误已记录!");
                env.mainForm.Close();
            }
#else
            Application.Run(env.mainForm);
#endif
        }
    }
}
