using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiliDuang.UI.Download
{
    public partial class DownloadList : UserControl
    {

        public DownloadList()
        {
            InitializeComponent();
            timer1.Start();
        }

        public void RefreshUI()
        {
            if (panel1.Controls.Count != DownloadQueue.objs.Count)
            {
                this.panel1.Controls.Clear();
                this.panel1.SuspendLayout();
                int i = 0;
                int y = 0;
                int lasth = 0;
                try
                {
                    foreach (DownloadObject obj in DownloadQueue.objs)
                    {
                        DownloadItem objui = new DownloadItem(i);
                        objui.Size = new Size(this.Size.Width, objui.Size.Height + 10);
                        y = y + lasth;
                        objui.Location = new Point(0, y);
                        lasth = objui.Height;
                        this.panel1.Controls.Add(objui);
                        i++;
                    }
                }
                catch (Exception e) { }
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

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }


    }
}
