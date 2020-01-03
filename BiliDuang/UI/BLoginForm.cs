using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace BiliDuang.UI
{
    public partial class BLoginForm : Form
    {
        private bool loaded;

        #region Cookie获取
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);

        private static string GetCookieString(string url)
        {
            // Determine the size of the cookie     
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);

            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;

                // Allocate stringbuilder large enough to hold the cookie     
                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }

        #endregion


        public BLoginForm()
        {
            InitializeComponent();
        }

        public void Login()
        {
            LoginBrowser.Url = new Uri("https://passport.bilibili.com/ajax/miniLogin/minilogin?t=0");
        }

        private void LoginBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (loaded)
            {
                if (LoginBrowser.DocumentText.Contains("你的账号存在异常"))
                {
                    this.Dispose();
                    BiliDuang.Dialog.Show("您的账号存在异常,请在PC网页端登录并修改密码后再次登录");
                }
                else
                {
                    User.cookie = GetCookieString("https://space.bilibili.com");
                    env.mainForm.RefreshUserData();
                    this.Dispose();
                }

            }
            else
            {
                LoginBrowser.Document.GetElementById("close").Click += ClosebyB;
                loaded = true;
            }
        }

        void ClosebyB(object sender, HtmlElementEventArgs e)
        {
            Dispose();
        }
    }
}
