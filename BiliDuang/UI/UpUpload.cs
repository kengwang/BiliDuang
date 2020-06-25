using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class UpUpload : MaterialForm
    {
        string uid;
        int pageall = 0;
        int pagenow = 1;

        public UpUpload(string uidin)
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();
            uid = uidin;
            LoadPage();
        }

        public void LoadPage()
        {
            // https://api.bilibili.com/x/space/arc/search?mid=258150656&ps=30&tid=0&pn=1&keyword=&order=pubdate&jsonp=jsonp
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", User.cookie);
            MyWebClient.Headers.Add("Origin", "https://space.bilibili.com");
            MyWebClient.Headers.Add("Referer", "https://space.bilibili.com/" + uid + "/video");
            string json = Encoding.UTF8.GetString(MyWebClient.DownloadData(string.Format("https://api.bilibili.com/x/space/arc/search?mid={0}&ps=6&pn={1}&order=pubdate&jsonp=jsonp", uid, pagenow))); //如果获取网站页面采用的是UTF-8，则使用这句
            MyWebClient.Dispose();
            JSONCallback.UpUpload.UpUpload upUpload = JsonConvert.DeserializeObject<JSONCallback.UpUpload.UpUpload>(json);
            panel1.Controls.Clear();
            int lasty = 0;
            foreach (JSONCallback.UpUpload.VlistItem data in upUpload.data.list.vlist)
            {
                LikeSelectItem item = new LikeSelectItem(data.aid, data.title, data.pic);
                panel1.Controls.Add(item);
                item.Location = new Point(0, lasty);
                lasty += item.Size.Height;
            }

            if (upUpload.data.page.pn * upUpload.data.page.ps >= upUpload.data.page.count)
            {
                PageNextButton.Visible = false;
            }
            else
            {
                PageNextButton.Visible = true;
            }

            if (upUpload.data.page.pn == 1)
            {
                PageUpButton.Visible = false;
            }
            else
            {
                PageUpButton.Visible = true;
            }

            pageall = Convert.ToInt32(Math.Ceiling((double)(upUpload.data.page.count / 6)));
            
            materialLabel1.Text = "第 " + pagenow.ToString() + " 页 / 共 " + pageall.ToString()+" 页";
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
            var dialog = new FolderBrowserDialog();
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
