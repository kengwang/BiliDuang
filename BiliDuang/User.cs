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
        private static string access_key;
        public static string face
        {
            get => _face;
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

                }
                return _cookie;
            }
            set
            {
                _cookie = value;
            }
        }

        internal static void SaveUserInfo()
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + "/config/");
            UserDataFile uf = new UserDataFile
            {
                uid = User.uid,
                cookie = User.cookie,
                access_key = User.access_key
            };
            File.WriteAllText(Environment.CurrentDirectory + "/config/user", JsonConvert.SerializeObject(uf));
        }

        public static JSONCallback.User.User UserJson = new JSONCallback.User.User();

        public static JSONCallback.User.User GetUserInfo(string uid)
        {
            JSONCallback.User.User Json = new JSONCallback.User.User();

            WebClient MyWebClient = new WebClient
            {
                Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            };
            try
            {
                string DataRaw = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/acc/info?mid=" + uid + "&jsonp=jsonp"));
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

        public static void RefreshUserAcessKey()
        {
            //这部分灵感来自 解除B站区域限制 https://github.com/ipcjs/bilibili-helper/tree/user.js/packages/unblock-area-limit
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=https%3A%2F%2Fwww.mcbbs.net%2Ftemplate%2Fmcbbs%2Fimage%2Fspecial_photo_bg.png&sign=04224646d1fea004e79606d3b038c84a");
            request.Headers.Add("Cookie", cookie);
            string callback = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
            JSONCallback.ThirdLogin.ThirdLogin thirdlogin = JsonConvert.DeserializeObject<JSONCallback.ThirdLogin.ThirdLogin>(callback);
            if (thirdlogin.status == true && thirdlogin.data.has_login == 1 && thirdlogin.data.user_info.mid.ToString() == uid)
            {
                request = HttpWebRequest.CreateHttp(thirdlogin.data.confirm_uri);
                request.AllowAutoRedirect = false;
                request.Headers.Add("Cookie", cookie);
                access_key = Other.TextGetCenter("access_key=", "&", request.GetResponse().Headers[HttpResponseHeader.Location]);
            }
            else
            {
                Dialog.Show("换取access_key失败");
            }
        }

        public static void RefreshUserInfo()
        {
            if (File.Exists(Environment.CurrentDirectory + "/config/cookie"))
            {
                Console.WriteLine("发现旧版用户信息存储文件,正在尝试转换");
                _cookie = File.ReadAllText(Environment.CurrentDirectory + "/config/cookie");
                SaveUserInfo();
                File.Delete(Environment.CurrentDirectory + "/config/cookie");
            }
            if (File.Exists(Environment.CurrentDirectory + "/config/user"))
            {
                UserDataFile uf = JsonConvert.DeserializeObject<UserDataFile>(File.ReadAllText(Environment.CurrentDirectory + "/config/user"));
                uid = uf.uid;
                access_key = uf.access_key;
                cookie = uf.cookie;
            }
            //SESSDATA = Other.TextGetCenter("SESSDATA=", ";", cookie);
            WebClient MyWebClient = new WebClient
            {
                Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            };
            MyWebClient.Headers.Add("Cookie", cookie);
            try
            {
                UserDataRaw = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/myinfo?jsonp=jsonp"));
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
                RefreshUserAcessKey();
                SaveUserInfo();
            }
            catch (WebException e)
            {
                Dialog.Show("用户信息获取错误" + e.Message);
            }
            MyWebClient.Dispose();
        }
    }
    public class UserDataFile
    {
        public string uid { get; set; }
        public string cookie { get; set; }
        public string access_key { get; set; }
    }
}
