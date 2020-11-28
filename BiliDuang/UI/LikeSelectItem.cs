using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class LikeSelectItem : UserControl
    {
        public string avid;
        public string name;
        private bool cancheck = true;
        private string picurl;
        public bool check
        {
            get
            {
                if (cancheck)
                {
                    return materialCheckBox1.Checked;
                }
                else
                {
                    return false;
                }

            }
            set
            {
                if (cancheck)
                {
                    materialCheckBox1.Checked = value;
                }

            }
        }
        public LikeSelectItem(string avid, string name = "未获取", string picurl = "未获取", bool avalible = true)
        {
            InitializeComponent();
            materialLabel2.Text = "av" + avid;
            this.avid = avid;
            if (avalible == false)
            {
                cancheck = false;
            }
            else
            {
                this.picurl = picurl;
                if (!File.Exists(Environment.CurrentDirectory + "/temp/av" + avid + ".jpg"))
                    new Thread(new ThreadStart(LoadImage)).Start();
                else
                {
                    picurl = Environment.CurrentDirectory + "/temp/av" + avid + ".jpg";
                    pic.Image = Image.FromFile(Environment.CurrentDirectory + "/temp/av" + avid + ".jpg");

                }
            }
            materialLabel1.Text = name;
            this.name = name;
        }

        private void LoadImage()
        {
            if (Settings.lowcache) return;
            DownloadImage("cache");
            if (picurl != null && !picurl.Contains("http"))
            {//下载好了
                pic.Image = Image.FromFile(picurl);
            }
            else if (picurl != null)
            {
                pic.WaitOnLoad = false;
                pic.LoadAsync(picurl);
            }

        }

        public void DownloadImage(string saveto)
        {
            string deerory = Environment.CurrentDirectory + "/temp/";
            string fileName = string.Format("av{0}.jpg", avid);
            if (picurl.Contains("http"))
            {
                if (!File.Exists(deerory + fileName))
                {
                    WebRequest imgRequest = WebRequest.Create(picurl);
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
                        picurl = deerory + fileName;
                        if (saveto != "cache")
                            File.Copy(picurl, saveto);
                    }
                }
                else
                {
                    picurl = deerory + fileName;
                    if (saveto != "cache")
                        File.Copy(picurl, saveto);
                }
            }
            else
            {
                if (saveto != "cache")
                    File.Copy(picurl, saveto);
            }

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            env.mainForm.SearchBox.Text = "av" + avid;
            env.mainForm.SearchStart();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Download(dialog.SelectedPath);
            }
        }

        public void Download(string saveto)
        {
            if (cancheck)
            {
                VideoClass.AV av = new VideoClass.AV(avid, true);
                foreach (VideoClass.episode ep in av.episodes)
                {
                    ep.Download(saveto + "/" + name + "(av" + avid + ")", VideoClass.VideoQuality.Q1080P60);
                }
            }
        }

        private void pic_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG 图片文件(*.jpg)|*.jpg";
            dialog.FileName = string.Format("av{0}.jpg", avid);
            dialog.RestoreDirectory = true;
            dialog.Title = "请选择图片保存位置:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DownloadImage(dialog.FileName);
                if (!picurl.Contains("http"))
                    pic.Image = Image.FromFile(picurl);
            }
        }

    }
}
