using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class VideoList : UserControl
    {
        List<VideoClass.episode> avList;

        public VideoList()
        {
            InitializeComponent();
            panel2.Size = this.Size;
        }

        public void InitCards(List<VideoClass.episode> avs)
        {
            int lastx = 0, lasty = 0, i = 0;
            //DisableAllCards();
            avList = avs;
            foreach (VideoClass.episode av in avs)
            {
                AVCard card = new AVCard(av);
                card.Size = new Size(card.Size.Width + 10, card.Size.Height + 10);
                i++;

                if (Environment.OSVersion.Platform != PlatformID.Unix)
                    card.Location = new Point(lastx + 10, lasty);
                else
                    card.Location = new Point(lastx, lasty);
                if (Environment.OSVersion.Platform != PlatformID.Unix)
                    lastx += card.Size.Width;
                else
                    lastx += 270;

                panel2.Controls.Add(card);
                if (i == 4)
                {
                    if (Environment.OSVersion.Platform != PlatformID.Unix)
                        lasty = lasty + card.Size.Height + 70;
                    else
                        lasty = lasty + card.Size.Height;
                    lastx = 0;
                    i = 0;
                }

            }
        }

        public void DisableAllCards()
        {
            panel2.Controls.Clear();
            materialLabel1.Visible = true;
        }

    }
}
