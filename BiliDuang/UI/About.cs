using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;

namespace BiliDuang.UI
{
    public partial class About : MaterialForm
    {
        int egg = 0;
        public About()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();
            materialLabel3.Text = "版本 " + Settings.versionName + " (" + Settings.versionCode + ")";
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kengwang/BiliDuang");
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
            egg++;
            string msg = "";
            if (egg % 5 == 0)
            {
                switch (egg / 5)
                {
                    case 1:
                        msg = "你在干嘛?";
                        break;
                    case 2:
                        msg = "你在干嘛?";
                        break;
                    case 3:
                        msg = "记得打赏哦(*^▽^*)";
                        break;
                    case 4:
                        msg = "お腹（なか）空（す）きました~";
                        break;
                    case 5:
                        msg = "お腹（なか）ぺこぺこ~";
                        break;
                    case 6:
                        msg = "このぼくは DARLING だ!";
                        break;
                    case 7:
                        msg = "どうしてこれなの!";
                        break;
                    case 8:
                        msg = "好了不皮了233";
                        egg = -10000000;
                        break;
                }
                Dialog dlg = new Dialog(msg);
                dlg.ShowDialog();
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.biliplus.com/");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            int R = ran.Next(255);
            int G = ran.Next(255);
            int B = ran.Next(255);
            B = (R + G > 400) ? R + G - 400 : B;//0 : 380 - R - G;
            B = (B > 255) ? 255 : B;
            button1.BackColor = Color.FromArgb(R, G, B);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://afdian.net/@kengwang");

        }
    }
}
