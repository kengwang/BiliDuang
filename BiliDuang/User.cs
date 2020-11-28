using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
namespace BiliDuang
{
    public class User
    {
        public static bool islogin = false;
        public static string name;
        //public static string SESSDATA;
        private static string _face;
        public static string face
        {
            get
            {
                return _face;
            }
            set
            {
                string deerory = Environment.CurrentDirectory + "/temp/"; string fileName = "uid" + uid + ".png";
                if (!File.Exists(deerory + fileName))
                {
                    WebRequest imgRequest = WebRequest.Create(value); HttpWebResponse res;
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
                        downImage.Save(deerory + fileName); downImage.Dispose();
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
        private static string _cookie = null;
        public static string cookie
        {
            get
            {
                if (_cookie == null)
                {
                    if (File.Exists(Environment.CurrentDirectory + "/config/cookie"))
                    {
                        return File.ReadAllText(Environment.CurrentDirectory + "/config/cookie");
                    }
                }
                return _cookie;
            }
            set
            {
                _cookie = value;
                Directory.CreateDirectory(Environment.CurrentDirectory + "/config/");
                File.WriteAllText(Environment.CurrentDirectory + "/config/cookie", value);
            }
        }
        public static JSONCallback.User.User UserJson = new JSONCallback.User.User();

        public static JSONCallback.User.User GetUserInfo(string uid)
        {
            JSONCallback.User.User Json = new JSONCallback.User.User();

            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            try
            {
                string DataRaw = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/acc/info?mid=" + uid + "&jsonp=jsonp")); //如果获取网站页面采用的是UTF-8，则使用这句
                MyWebClient.Dispose();
                UserJson = JsonConvert.DeserializeObject<JSONCallback.User.User>(DataRaw);
                if (UserJson.code != 0)
                {
                    return null;
                }
                else
                {
                    return UserJson;
                }
            }
            catch (WebException e)
            {
                Dialog.Show("用户信息获取错误" + e.Message);
                return null;
            }


        }

        public static void RefreshUserInfo()
        {
            //SESSDATA = Other.TextGetCenter("SESSDATA=", ";", cookie);
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", cookie);
            try
            {
                UserDataRaw = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/myinfo?jsonp=jsonp")); //如果获取网站页面采用的是UTF-8，则使用这句
            }
            catch (WebException e)
            {
                Dialog.Show("用户信息获取错误" + e.Message);
            }
            MyWebClient.Dispose();
            UserJson = JsonConvert.DeserializeObject<JSONCallback.User.User>(UserDataRaw);
            if (UserJson.code != 0)
            {
                islogin = false;
                return;
            }
            islogin = true;
            uid = UserJson.data.mid;
            face = UserJson.data.face;
            name = UserJson.data.name;
        }
    }
}
