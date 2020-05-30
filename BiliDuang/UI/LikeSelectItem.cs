using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace BiliDuang.UI
{
    public partial class LikeSelectItem : UserControl
    {
        public string avid;
        public string name;
        private bool cancheck = true;
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
        VideoClass.AV av;
        public LikeSelectItem(string bvid, string name = "未获取", string picurl = "未获取")
        {
            InitializeComponent();
            
            avid = Video.ProcessBV(bvid);

            av = new VideoClass.AV(avid, true);
            materialLabel2.Text = "av" + avid;
            if (av.status == false)
            {
                cancheck = false;
            }
            else
            {
                if (!av.imgurl.Contains("http"))
                    pic.Image = Image.FromFile(av.imgurl);
            }
            materialLabel1.Text = av.name;
            this.name = av.name;
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
            dialog.FileName = string.Format("ss{0}.jpg", av);
            dialog.RestoreDirectory = true;
            dialog.Title = "请选择图片保存位置:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                av.DownloadImage(dialog.FileName);
                if (!av.imgurl.Contains("http"))
                    pic.Image = Image.FromFile(av.imgurl);
            }
        }
    }
}
