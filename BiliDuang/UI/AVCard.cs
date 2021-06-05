using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class AVCard : UserControl
    {
        public string av;
        public bool imageloaded = false;

        public bool check
        {
            set => checkbox.Checked = value;
            get => checkbox.Checked;
        }

        public string DPath = null;
        public VideoClass.episode ep = new VideoClass.episode();

        public AVCard(VideoClass.episode avdata)
        {
            InitializeComponent();
            av = avdata.aid;
            Title.Text = avdata.name;
            aid.Text = "AV" + avdata.aid;
            ep = avdata;
        }

        public void LoadImage()
        {
            if (ep.pic.Contains("http"))
            {
                if (Settings.lowcache)
                {
                    return;
                }

                Image img = ep.GetImage();
                if (img != null)
                {
                    //下载好了
                    pic.Image = img;
                }
                else if (ep.pic != null)
                {
                    pic.WaitOnLoad = false;
                    pic.LoadAsync(ep.pic);
                }
            }
            else
            {
                pic.Image = Image.FromFile(ep.pic);
            }

            imageloaded = true;
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
            if (ep.CheckIsInteractive() == false)
            {
                if (DPath == null)
                {
                    MessageBox.Show("您还未选择下载目录!您可以在列表上方选择全部的,也可以在接下来弹出的对话框中选择单个文件");
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        DPath = dialog.SelectedPath;
                        Task.Run((() => { StartDownload(); }));
                        return;
                    }

                    return;
                }

                Task.Run((() => { StartDownload(); }));
            }
            else
            {
                IntereactionSelect select = new IntereactionSelect(ep);
                select.ShowDialog();
            }
        }

        public void StartDownload()
        {
            Download.Text = "正在下载";
            ep.Download(DPath, VideoClass.VideoQuality.Int(QualityBox.SelectedItem.ToString()), ep.pid);
        }

        private void AVCard_Load(object sender, EventArgs e)
        {
            QualityBox.SelectedIndex = 0;
        }

        private void DownloadImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "JPG 图片文件(*.jpg)|*.jpg",
                FileName = string.Format("av{0}-c{1}.jpg", ep.aid, ep.cid),
                RestoreDirectory = true,
                Title = "请选择图片保存位置:"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ep.DownloadImage(dialog.FileName);
                if (!ep.pic.Contains("http"))
                {
                    pic.Image = Image.FromFile(ep.pic);
                }
            }
        }

        private void pic_Click(object sender, EventArgs e)
        {
            DownloadImg_Click(sender, e);
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift))
            {
                // 按住 shift 范围选择
                // https://github.com/kengwang/BiliDuang/issues/35
                // 我想想怎么实现哈
                bool startrange = false;
                foreach (Control ctl in env.mainForm.videoList1.panel2.Controls)
                {
                    if (ctl is AVCard)
                    {
                        AVCard card = (AVCard) ctl;
                        if (card == this)
                        {
                            startrange = false;
                            card.check = true;
                            break;
                        }

                        if (card.check || startrange)
                        {
                            startrange = true;
                            card.check = true;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}