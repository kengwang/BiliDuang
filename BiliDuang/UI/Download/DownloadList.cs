using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BiliDuang.UI.Download
{
    public partial class DownloadList : UserControl
    {

        public DownloadList()
        {
            InitializeComponent();

            if (File.Exists(Environment.CurrentDirectory + "/config/download.session"))
            {
                DialogResult dr = MessageBox.Show("发现上次未完成的任务.是否继续下载?", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DownloadQueue.readMisson();
                }
            }
            timer1.Start();
        }

        public void RefreshUI()
        {
            if (panel1.Controls.Count != DownloadQueue.objs.Count)
            {
                panel1.Controls.Clear();
                panel1.SuspendLayout();
                int i = 0;
                int y = 0;
                int lasth = 0;
                try
                {
                    foreach (DownloadObject obj in DownloadQueue.objs)
                    {
                        DownloadItem objui = new DownloadItem(i);
                        y += lasth;
                        objui.Size = new Size(Size.Width, objui.Size.Height + 10);
                        objui.Location = new Point(0, y);
                        if (Environment.OSVersion.Platform != PlatformID.Unix)
                        {
                            lasth = objui.Height;
                        }
                        else
                        {
                            lasth = objui.Height - 50;
                        }

                        panel1.Controls.Add(objui);
                        i++;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                foreach (Control c in panel1.Controls)
                {
                    if (c is DownloadItem)
                    {
                        DownloadItem item = (DownloadItem)c;
                        if (!item.clean)
                        {
                            item.Dispose();
                        }
                        item.RefreshUI();
                    }
                }
            }
            DownloadQueue.SaveMissons();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }


    }
}
