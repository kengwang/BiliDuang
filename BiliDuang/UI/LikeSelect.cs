using BiliDuang.JSONCallback.LikeBoxItem;
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
    public partial class LikeSelect : MaterialForm
    {
        private string path;
        public string id;
        private string LikeDataRAW;
        private LikeBoxItem LikeJSON;

        public LikeSelect(string id)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();

            //https://api.bilibili.com/medialist/gateway/base/info?media_id=295080471
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", User.cookie);
            MyWebClient.Headers.Add("Origin", "https://space.bilibili.com");
            MyWebClient.Headers.Add("Referer", "https://www.bilibili.com/medialist/detail/ml" + id);
            LikeDataRAW = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/medialist/gateway/base/resource/ids?media_id=" + id)); //如果获取网站页面采用的是UTF-8，则使用这句
            LikeJSON = JsonConvert.DeserializeObject<JSONCallback.LikeBoxItem.LikeBoxItem>(LikeDataRAW);
            int lasty = 0;
            foreach (JSONCallback.LikeBoxItem.DataItem data in LikeJSON.data)
            {
                string bvid = data.bv_id;
                LikeSelectItem item = new LikeSelectItem(bvid);
                panel1.Controls.Add(item);
                item.Location = new Point(0, lasty);
                lasty += item.Size.Height;
            }
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
    }
}
