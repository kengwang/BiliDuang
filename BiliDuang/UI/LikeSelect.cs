using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class LikeSelect : MaterialForm
    {
        private readonly string mid;
        private int pageall = 0;
        private int pagenow = 1;

        public LikeSelect(string uidin)
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();
            mid = uidin;
            LoadPage();
        }

        public void LoadPage()
        {
            // https://api.bilibili.com/x/space/arc/search?mid=258150656&ps=30&tid=0&pn=1&keyword=&order=pubdate&jsonp=jsonp
            WebClient MyWebClient = new WebClient
            {
                Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            };
            MyWebClient.Headers.Add("Cookie", User.cookie);
            MyWebClient.Headers.Add("Origin", "https://space.bilibili.com");
            MyWebClient.Headers.Add("Referer", "https://www.bilibili.com/medialist/detail/ml" + mid);
            string json = Encoding.UTF8.GetString(MyWebClient.DownloadData(string.Format("https://api.bilibili.com/x/v3/fav/resource/list?media_id={0}&pn={1}&ps=6&order=mtime&type=0&tid=0&jsonp=jsonp", mid, pagenow))); //如果获取网站页面采用的是UTF-8，则使用这句
            MyWebClient.Dispose();
            JSONCallback.LikeBoxItem.LikeBoxItem upUpload = JsonConvert.DeserializeObject<JSONCallback.LikeBoxItem.LikeBoxItem>(json);
            if (upUpload.code != 0)
            {
                MessageBox.Show("获取收藏夹错误: " + upUpload.message);
                Close();
                Dispose();
                return;
            }
            Text = upUpload.data.info.title;
            panel1.Controls.Clear();
            int lasty = 0;
            foreach (JSONCallback.LikeBoxItem.MediasItem data in upUpload.data.medias)
            {
                string aid = data.id;
                LikeSelectItem item = new LikeSelectItem(aid, data.title, data.cover, data.attr == 0);
                panel1.Controls.Add(item);
                item.Location = new Point(0, lasty);
                lasty += item.Size.Height;
            }
            pageall = Convert.ToInt32(Math.Ceiling((double)(upUpload.data.info.media_count / 6)));
            if (pagenow * 6 >= upUpload.data.info.media_count)
            {
                PageNextButton.Visible = false;
            }
            else
            {
                PageNextButton.Visible = true;
            }

            if (pagenow == 1)
            {
                PageUpButton.Visible = false;
            }
            else
            {
                PageUpButton.Visible = true;
            }



            materialLabel1.Text = "第 " + pagenow.ToString() + " 页 / 共 " + pageall.ToString() + " 页";
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is LikeSelectItem)
                {
                    LikeSelectItem item = (LikeSelectItem)c;
                    item.check = materialCheckBox1.Checked;
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            string path = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dialog.SelectedPath;
                foreach (Control c in panel1.Controls)
                {
                    LikeSelectItem item = (LikeSelectItem)c;
                    item.Download(path);
                }
            }
        }

        private void PageNextButton_Click(object sender, EventArgs e)
        {
            pagenow++;
            LoadPage();
        }

        private void PageUpButton_Click(object sender, EventArgs e)
        {
            pagenow--;
            LoadPage();
        }
    }
}
