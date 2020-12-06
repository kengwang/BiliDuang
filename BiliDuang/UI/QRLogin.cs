using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace BiliDuang.UI
{
    public partial class QRLogin : MaterialForm
    {
        private string oathkey = "";
        private string cookie = "";

        public QRLogin()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();
        }

        private void RefreshLoginStatus()
        {
            //序列化参数
            string jsonParam = "oauthKey=" + oathkey;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://passport.bilibili.com/qrcode/getLoginInfo");
            request.Headers.Add("Cookie", cookie);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] byteData = Encoding.UTF8.GetBytes(jsonParam);
            int length = byteData.Length;
            request.ContentLength = length;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, length);
            writer.Close();

            //接收数据
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
            JSONCallback.QRLoginInfo.QRLoginInfoNoData loginInfo = JsonConvert.DeserializeObject<JSONCallback.QRLoginInfo.QRLoginInfoNoData>(responseString);
            if (loginInfo.status == "false")
            {
                JSONCallback.QRLoginInfo.QRLoginInfoDataInt loginInfo1 = JsonConvert.DeserializeObject<JSONCallback.QRLoginInfo.QRLoginInfoDataInt>(responseString);
                if (loginInfo1.data == -4)
                {
                    return;
                }

                if (loginInfo1.data == -5)
                {
                    materialLabel1.Text = "已扫描二维码,请在手机上确认登录";
                    return;
                }
                if (loginInfo1.data == -2)
                {
                    materialLabel1.Text = "二维码已过期,正在重新加载";
                    RefreshQRCode();
                    return;
                }
                Console.WriteLine(responseString);
            }
            else
            {
                JSONCallback.QRLoginInfo.QRLoginInfoData loginInfo1 = JsonConvert.DeserializeObject<JSONCallback.QRLoginInfo.QRLoginInfoData>(responseString);
                Uri uri = new Uri(loginInfo1.data.url);
                string backcookie = Uri.UnescapeDataString(uri.Query.TrimStart('?')).Replace("&", ";");
                User.cookie = backcookie;
                User.SaveUserInfo();
                User.RefreshUserInfo();
                timer1.Stop();
                Close();
                Dispose();
            }
        }

        private void RefreshQRCode()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://passport.bilibili.com/qrcode/getLoginUrl");
            myRequest.CookieContainer = new CookieContainer();
            //将请求的结果发送给客户端(界面、应用)
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            cookie = myResponse.Headers.Get("Set-Cookie");
            string callback = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            JSONCallback.QRUrl.QRUrl json = JsonConvert.DeserializeObject<JSONCallback.QRUrl.QRUrl>(callback);
            if (json.code == 0)
            {
                oathkey = json.data.oauthKey;
                QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(json.data.url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrcode.GetGraphic(6, Color.Black, Color.White, null, 15, 6, true);
                QRCodePicBox.Image = qrCodeImage;
                materialLabel1.Text = "请使用哔哩哔哩客户端扫码登录或扫码下载APP";
                timer1.Start();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshQRCode();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshLoginStatus();
        }
    }
}
