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
                if (i == 5)
                {
                    lasty = lasty + card.Size.Height;
                    lastx = 0;
                    i = 1;
                    card.Location = new Point(lastx + 10, lasty);
                    lastx += card.Size.Width;
                    panel2.Controls.Add(card);
                }
                else
                {
                    card.Location = new Point(lastx + 10, lasty);
                    lastx += card.Size.Width;
                    panel2.Controls.Add(card);
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
