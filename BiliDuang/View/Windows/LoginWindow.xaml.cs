using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BiliDuang.Apis;
using BiliDuang.Model;
using Masuit.Tools;
using Microsoft.Web.WebView2.Core;

namespace BiliDuang.View.Windows
{
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void WebView_OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (WebView.Source.AbsolutePath.Contains("ajax/miniLogin/redirect"))
            {
                // 登录成功
                var cookies = await WebView.CoreWebView2.CookieManager.GetCookiesAsync("https://space.bilibili.com");
                BilibiliApi.Cookies = new CookieCollection();
                cookies.Select(t => t.ToSystemNetCookie()).ForEach(t => BilibiliApi.Cookies.Add(t));
                // Access Token Get
                Common.MainWindow.UserInfoViewUpdate();
                RefreshUserAccessKey();
                File.WriteAllText("user.json",JsonSerializer.Serialize(new UserLoginSavedData
                {
                    Cookie = BilibiliApi.Cookies.Cast<Cookie>().ToList(),
                }));
                Close();
            }

            _ = WebView.CoreWebView2.ExecuteScriptAsync("document.getElementById('close').style.display = 'none'");
        }

        private static async void RefreshUserAccessKey()
        {
            //这部分灵感来自 解除B站区域限制 https://github.com/ipcjs/bilibili-helper/tree/user.js/packages/unblock-area-limit
            var json = await BilibiliApi.RequestAsync(
                "https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=https%3A%2F%2Fwww.mcbbs.net%2Ftemplate%2Fmcbbs%2Fimage%2Fspecial_photo_bg.png&sign=04224646d1fea004e79606d3b038c84a",HttpMethod.Get);
            try
            {
                if (json["status"].GetValue<bool>() && json["data"]["has_login"].GetValue<int>() == 1)
                {
                    var request = WebRequest.CreateHttp(json["data"]["confirm_uri"].ToString());
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Cookie", BilibiliApi.Cookies.ToHttpString());
                    BilibiliApi.AccessKey = request.GetResponse().Headers[HttpResponseHeader.Location]
                        .TextGetCenter("access_key=", "&");
                    File.WriteAllText("user.json",JsonSerializer.Serialize(new UserLoginSavedData
                    {
                        Cookie = BilibiliApi.Cookies.Cast<Cookie>().ToList(),
                        AccessKey = BilibiliApi.AccessKey
                    }));
                }
                else
                {
                    // 换取失败
                }
            }
            catch (Exception)
            {
                // 换取失败
            }
        }
    }
}