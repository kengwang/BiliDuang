using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace BiliDuang.UI.UserDataForm
{
    public partial class BangumiListItem : UserControl
    {
        JSONCallback.UserBangumiFollow.ListItem BItem;
        string _pic;
        public BangumiListItem(JSONCallback.UserBangumiFollow.ListItem BangumiItem)
        {
            InitializeComponent();
            BItem = BangumiItem;
            BName.Text = BItem.title;
            Des.Text = BItem.evaluate;
            if (BItem.progress == null)
            {
                Progress.Text = BItem.new_ep.index_show;
            }
            else
            {
                Progress.Text = BItem.progress + " | " + BItem.new_ep.index_show;
            }
            _pic = BItem.cover;
            if (!Settings.lowcache)
            {
                DownloadImage("cache");
                pictureBox1.Image = Image.FromFile(_pic);
            }
            
        }

        public void DownloadImage(string saveto)
        {
            string deerory = Environment.CurrentDirectory + "/temp/";
            string fileName = string.Format("ss{0}.jpg", BItem.season_id);
            if (!File.Exists(deerory + fileName))
            {
                WebRequest imgRequest = WebRequest.Create(BItem.cover); HttpWebResponse res;
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
                    System.Drawing.Image downImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream()); if (!System.IO.Directory.Exists(deerory))
                    {
                        System.IO.Directory.CreateDirectory(deerory);
                    }
                    downImage.Save(deerory + fileName);
                    if (saveto != "cache")
                        File.Copy(deerory + fileName, saveto);
                    downImage.Dispose();
                    _pic = deerory + fileName;
                }
            }
            else
            {
                if (saveto != "cache")
                    File.Copy(deerory + fileName, saveto);
                _pic = deerory + fileName;

            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            env.mainForm.SearchBox.Text = BItem.url;
            env.mainForm.SearchStart();
            Parent.Parent.Parent.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG 图片文件(*.jpg)|*.jpg";
            dialog.FileName = string.Format("ss{0}.jpg", BItem.season_id);
            dialog.RestoreDirectory = true;
            dialog.Title = "请选择图片保存位置:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DownloadImage(dialog.FileName);
                if (!_pic.Contains("http"))
                    pictureBox1.Image = Image.FromFile(_pic);
            }
        }
    }
}
