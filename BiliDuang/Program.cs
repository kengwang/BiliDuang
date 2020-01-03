using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliDuang
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            env.mainForm = new MainForm();
            env.mainForm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(env.mainForm);
        }
    }
}
