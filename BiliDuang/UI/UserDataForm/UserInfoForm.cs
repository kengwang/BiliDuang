using BiliDuang.JSONCallback.UserLikeBox;
using BiliDuang.UI.UserDataForm;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class UserInfoForm : MaterialForm
    {
        private string BangumiDataRAW;
        private JSONCallback.UserBangumiFollow.UserBangumiFollow BangumiJSON;
        private List<BangumiListItem> bitem = new List<BangumiListItem>();
        int bpn = 1, bpt = 0;
        private bool self = true;
        private string LikeDataRAW;
        private UserLikeBox LikeJSON;
        private string uid;

        public UserInfoForm(string userid = "NaN")
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                this.materialTabControl1.Region = new Region(new RectangleF(this.materialTabControl1.Left, this.materialTabControl1.Top, this.materialTabControl1.Width, this.materialTabControl1.Height));
            }

            if (userid == "NaN")
                userid = User.uid;

            uid = userid;
            Other.RefreshColorSceme();
            if (userid == User.uid)
            {
                self = true;
                User.RefreshUserInfo();
                UserNameBox.Text = User.name;
                pictureBox1.Image = Image.FromFile(User.face);
                UserLevel.Text = "LV" + User.UserJson.data.level;
                if (User.UserJson.data.vip.type == 2)
                {
                    VipType.Text = "年度大会员";
                }
                else if (User.UserJson.data.vip.type == 1)
                {
                    VipType.Text = "大会员";
                }
                else
                {
                    VipType.Text = "";
                }
                coinBox.Text = "硬币:" + User.UserJson.data.coins.ToString();
                SlogenLabel.Text = User.UserJson.data.sign;
                RefreshBangumiData();
                RefreshLikeList();
            }
            else
            {
                self = false;
                JSONCallback.User.User user = User.GetUserInfo(userid);
                if (user == null) this.Dispose();
                string _face = "";

                string deerory = Environment.CurrentDirectory + "/temp/"; string fileName = "uid" + userid + ".png";
                if (!File.Exists(deerory + fileName))
                {
                    WebRequest imgRequest = WebRequest.Create(user.data.face); HttpWebResponse res;
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

                pictureBox1.Image = Image.FromFile(_face);
                UserNameBox.Text = user.data.name;
                UserLevel.Text = "LV" + user.data.level;
                if (user.data.vip.type == 2)
                {
                    VipType.Text = "年度大会员";
                }
                else if (user.data.vip.type == 1)
                {
                    VipType.Text = "大会员";
                }
                else
                {
                    VipType.Text = "";
                }
                coinBox.Text = "硬币:" + user.data.coins.ToString();
                SlogenLabel.Text = user.data.sign;
                RefreshBangumiData();
                RefreshLikeList();
            }

        }

        private void PageNext_Click(object sender, EventArgs e)
        {
            RefreshBangumiData(bpn + 1);
        }

        private void PrePage_Click(object sender, EventArgs e)
        {
            RefreshBangumiData(bpn - 1);
        }

        private void RefreshBangumiData(int pn = 1)
        {
            LoadingToast.Visible = true;
            foreach (Control c in bitem)
            {
                c.Dispose();
            }
            bool right = false;
            int lastx = 0, lasty = 0;
            //https://api.bilibili.com/x/space/bangumi/follow/list?type=1&follow_status=0&vmid=
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", User.cookie);
            BangumiDataRAW = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/space/bangumi/follow/list?type=1&ps=10&pn=" + pn + "&vmid=" + uid)); //如果获取网站页面采用的是UTF-8，则使用这句
            BangumiJSON = JsonConvert.DeserializeObject<JSONCallback.UserBangumiFollow.UserBangumiFollow>(BangumiDataRAW);
            if (BangumiJSON.code != 0) return;
            MyWebClient.Dispose();
            if (pn == 1)
            {
                PrePage.Visible = false;
            }
            else
            {
                PrePage.Visible = true;
            }
            bpn = pn;
            bpt = (int)Math.Ceiling((BangumiJSON.data.total / 10.0));
            if (pn == bpt)
            {
                PageNext.Visible = false;
            }
            else
            {
                PageNext.Visible = true;
            }
            PageStat.Text = "第" + pn.ToString() + "页 共" + bpt.ToString() + "页";
            if (BangumiJSON.data.list.Count == 0)
            {
                MessageBox.Show("木有了");
            }

            foreach (JSONCallback.UserBangumiFollow.ListItem l in BangumiJSON.data.list)
            {
                if (right)
                {
                    right = false;
                    BangumiListItem item = new BangumiListItem(l);
                    bitem.Add(item);
                    BangumiFollow.Controls.Add(item);
                    item.Location = new Point(lastx, lasty);
                    lasty += item.Size.Height;
                }
                else
                {
                    right = true;
                    BangumiListItem item = new BangumiListItem(l);
                    bitem.Add(item);
                    BangumiFollow.Controls.Add(item);
                    item.Location = new Point(0, lasty);
                    lastx = item.Size.Width;
                }
            }
            LoadingToast.Visible = false;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            UpUpload upload = new UpUpload(uid);
            upload.ShowDialog();
        }

        private void RefreshLikeList()
        {
            //https://api.bilibili.com/x/v3/fav/folder/created/list-all?jsonp=jsonp&up_mid=<uid>
            //https://api.bilibili.com/x/v3/fav/folder/collected/list?pn=1&ps=20&up_mid=<uid>&jsonp=jsonp - 这个是收藏的
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", User.cookie);
            MyWebClient.Headers.Add("Origin", "https://space.bilibili.com");
            MyWebClient.Headers.Add("Referer", "https://space.bilibili.com/" + User.uid + "/favlist");
            LikeDataRAW = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/x/v3/fav/folder/created/list-all?jsonp=jsonp&up_mid=" + uid)); //如果获取网站页面采用的是UTF-8，则使用这句
            LikeJSON = JsonConvert.DeserializeObject<JSONCallback.UserLikeBox.UserLikeBox>(LikeDataRAW);
            MyWebClient.Dispose();
            int lasty = 0;
            if (LikeJSON.code == 0 && LikeJSON.data != null)
                foreach (ListItem box in LikeJSON.data.list)
                {
                    LikeBoxItem item = new LikeBoxItem(box.id, box.title);
                    Like.Controls.Add(item);
                    item.Location = new Point(0, lasty);
                    lasty += item.Size.Height;
                }
        }
    }
}
