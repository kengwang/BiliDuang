using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class AVCard : UserControl
    {
        public string av;
        public bool check
        {
            set
            {
                checkbox.Checked = value;
            }
            get
            {
                return checkbox.Checked;
            }
        }
        public string DPath = null;
        public VideoClass.episode ep = new VideoClass.episode();
        public AVCard(VideoClass.episode avdata)
        {
            InitializeComponent();
            av = avdata.aid;
            if (avdata.pic.Contains("http"))
            {
                new Thread(new ThreadStart(LoadImage)).Start();
            }
            else
            {
                pic.Image = Image.FromFile(avdata.pic);
            }
            Title.Text = avdata.name;
            aid.Text = "AV" + avdata.aid;
            ep = avdata;
        }

        private void LoadImage()
        {
            if (Settings.lowcache) return;
            ep.DownloadImage("cache");
            if (ep.pic != null && !ep.pic.Contains("http"))
            {//下载好了
                pic.Image = Image.FromFile(ep.pic);
            }
            else if (ep.pic != null)
            {
                pic.WaitOnLoad = false;
                pic.LoadAsync(ep.pic);
            }

        }

        public AVCard()
        {
            InitializeComponent();
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            DownloadImg.Visible = true;
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
            DownloadImg.Visible = false;
        }

        private void aid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("https://www.bilibili.com/av{0}", av));
        }


        public void Download_Click(object sender, EventArgs e)
        {
            if (DPath == null)
            {
                MessageBox.Show("您还未选择下载目录!您可以在列表上方选择全部的,也可以在接下来弹出的对话框中选择单个文件");
                var dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DPath = dialog.SelectedPath;
                    StartDownload();
                    return;
                }
                return;
            }
            StartDownload();
        }

        public void StartDownload()
        {
            Download.Text = "正在下载";
            ep.Download(DPath, VideoClass.VideoQuality.Int(QualityBox.SelectedItem.ToString()));

        }

        private void AVCard_Load(object sender, EventArgs e)
        {
            QualityBox.SelectedIndex = 0;
        }

        private void DownloadImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG 图片文件(*.jpg)|*.jpg";
            dialog.FileName = string.Format("av{0}-c{1}.jpg", ep.aid, ep.cid);
            dialog.RestoreDirectory = true;
            dialog.Title = "请选择图片保存位置:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ep.DownloadImage(dialog.FileName);
                if (!ep.pic.Contains("http"))
                    pic.Image = Image.FromFile(ep.pic);
            }

        }

        private void pic_Click(object sender, EventArgs e)
        {
            DownloadImg_Click(sender, e);
        }
    }
}
