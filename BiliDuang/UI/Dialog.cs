using System;
using System.Windows.Forms;

namespace BiliDuang.UI
{
    public partial class Dialog : Form
    {
        public Dialog(string t)
        {
            InitializeComponent();
            Content.Text = t;
        }

        public Dialog(string t, string tt)
        {
            InitializeComponent();
            Content.Text = t;
            title.Text = tt;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Dispose();
        }


    }
}
