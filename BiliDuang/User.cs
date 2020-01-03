using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BiliDuang
{
    public class User
    {
        public static bool islogin = false;
        public static string name;
        public static string SESSDATA;
        private static string _face;
        public static string face
        {
            get
            {
                return _face;
            }
            set
            {
                string deerory = Environment.CurrentDirectory + "\\temp\\";

                string fileName = "face.png";
                if (!File.Exists(deerory + fileName))
                {
                    WebRequest imgRequest = WebRequest.Create(value);

                    HttpWebResponse res;
                    try
                    {
                        res = (HttpWebResponse)imgRequest.GetResponse();
                    }
                    catch (WebException ex)
                    {

                        res = (HttpWebResponse)ex.Response;
                    }

                    if (res.StatusCode.ToString() == "OK")
                    {
                        System.Drawing.Image downImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream());




                        if (!System.IO.Directory.Exists(deerory))
                        {
                            System.IO.Directory.CreateDirectory(deerory);
                        }

                        downImage.Save(deerory + fileName);

                        downImage.Dispose();
                        _face = deerory + fileName;
                    }


                }
                else
                {
                    _face = deerory + fileName;
                }
            }
        }
        private static string UserDataRaw;
        public static string uid;
        private static string _cookie=null;
        public static string cookie
        {
            get
            {
                if (_cookie == null)
                {
                    if (File.Exists(Environment.CurrentDirectory + "\\config\\cookie"))
                    {
                        return File.ReadAllText(Environment.CurrentDirectory + "\\config\\cookie");
                    }
                }
                return _cookie;
            }
            set
            {              
                _cookie = value;
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\config\\");
                File.WriteAllText(Environment.CurrentDirectory+"\\config\\cookie", value);
            }
        }

        private static JSONCallback.User.User UserJson = new JSONCallback.User.User();
        public static void RefreshUserInfo()
        {
            SESSDATA = Other.TextGetCenter("SESSDATA=", ";", cookie);
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", cookie);
            UserDataRaw = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/myinfo?jsonp=jsonp")); //如果获取网站页面采用的是UTF-8，则使用这句
            MyWebClient.Dispose();
            UserJson = JsonConvert.DeserializeObject<JSONCallback.User.User>(UserDataRaw);
            if (UserJson.code != 0)
            {
                islogin = false;
                return;
            }
            islogin = true;
            face = UserJson.data.face;
            uid = UserJson.data.mid;
            name = UserJson.data.name;
        }
    }
}
