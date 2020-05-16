using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiliDuang.UI.Download
{
    public partial class DownloadItem : UserControl
    {
        public int index;
        public bool clean = true;
        public DownloadItem(int index)
        {
            InitializeComponent();
            this.index = index;
            RefreshUI();
        }
        public void RefreshUI()
        {
            if (DownloadQueue.objs.Count - 1 >= index)
            {
                MissionName.Text = DownloadQueue.objs[index].name;
                Directory.Text = DownloadQueue.objs[index].saveto;
                if (DownloadQueue.objs[index].progress >= 100) materialProgressBar1.Value = 100;
                else if (DownloadQueue.objs[index].progress < 0) materialProgressBar1.Value = 0;
                else materialProgressBar1.Value = DownloadQueue.objs[index].progress;
                StatusBox.Text = DownloadQueue.objs[index].message;
                if (DownloadQueue.objs[index].status == 66)
                {
                    DownloadQueue.objs.RemoveAt(index);
                    clean = false;
                    DownloadQueue.StartAll();
                    return;
                }
                if (DownloadQueue.objs[index].status < 0)
                {
                    DownloadQueue.objs[index].Pause();
                    this.BackColor = Color.Red;
                    MissionStateChange.Text = "4";
                }
                if (DownloadQueue.objs[index].status != 5)
                {
                    this.BackColor = Color.Orange;
                    MissionStateChange.Text = "4";
                }
                else
                {
                    this.BackColor = Other.GetBackGroundColor();
                    MissionStateChange.Text = ";";
                }
            }
            else
            {
                clean = false;
            }
        }

        private void MissionStateChange_Click(object sender, EventArgs e)
        {
            //暂停 ; 播放 4
            if (DownloadQueue.objs[index].status == 1)
            {
                DownloadQueue.objs[index].Resume();
                MissionStateChange.Text = "4";
            }
            else if (DownloadQueue.objs[index].status < 0)
            {
                RetryButton_Click();
            }
            else
            {
                DownloadQueue.objs[index].Pause();
                MissionStateChange.Text = ";";
            }
        }

        private void MissonCancel_Click(object sender, EventArgs e)
        {
            DownloadQueue.objs[index].Cancel();
            DownloadQueue.objs.RemoveAt(index);
            this.RefreshUI();
        }

        private void RetryButton_Click()
        {
            DownloadQueue.objs[index].LinkStart();
            this.RefreshUI();
        }
    }
}