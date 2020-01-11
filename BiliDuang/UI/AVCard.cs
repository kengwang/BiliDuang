using System;
using System.Diagnostics;
using System.Drawing;
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
            pic.Image = Image.FromFile(avdata.pic);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            Title.Text = avdata.name;
            aid.Text = "AV" + avdata.aid;
            ep = avdata;
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
    }
}
