using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BiliDuang.UI
{
    public partial class AVCard : UserControl
    {
        public string av;
        public bool check {
            set
            {
                checkbox.Checked = value;
            }
            get
            {
                return checkbox.Checked;
            }
        }
        public VideoClass.episode ep=new VideoClass.episode();
        public AVCard(VideoClass.episode avdata)
        {
            InitializeComponent();
            av = avdata.aid;
            pic.Image = Image.FromFile(avdata.pic);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            Title.Text = avdata.name;
            aid.Text = "AV"+avdata.aid;
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
            StartDownload();
        }

        public void StartDownload()
        {
            Download.Text = "正在下载";
            ep.Download(Environment.CurrentDirectory + "\\Download\\" + "av" + av, VideoClass.VideoQuality.Int(QualityBox.SelectedItem.ToString()));

        }

        private void AVCard_Load(object sender, EventArgs e)
        {
            QualityBox.SelectedIndex = 0;
        }
    }
}
