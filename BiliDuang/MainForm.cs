using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliDuang
{
    public partial class MainForm : MaterialForm
    {
        private bool resultSeeing = false;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);


            if (Other.IsDarkMode())
            {//Dark Mode
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey500, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo500, Primary.Indigo500, Accent.LightBlue200, TextShade.WHITE);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            RefreshUserData();
        }

        private void ResultShowReady()
        {
            //159 - > 0
            //26,164,917
            materialLabel1.Text = "勇者大人请传令↓";
            materialFlatButton1.Text = "Logout";
            resultSeeing = true;
            while (panel1.Location.Y != 134)
            {
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 1);
            }
        }
        private void CloseCase()
        {
            materialLabel1.Text = "勇者大人请传令->";
            materialFlatButton1.Text = "Link Start!";
            resultSeeing = false;
            while (panel1.Location.Y != 318)
            {
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 1);
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (!resultSeeing)
            {
                videoList1.DisableAllCards();
                Tabs.SelectTab(1);
                Video v = new Video(SearchBox.Text);
                switch (v.Type)
                {
                    case 1:
                        //av
                        VideoClass.AV av = v.av[0];
                        if (av.status)
                        {
                            ResultShowReady();
                            videoList1.InitCards(v.av[0].episodes);
                            materialLabel2.Text = v.av[0].name;
                        }
                        break;
                    case 3:
                        //SS
                        ResultShowReady();
                        materialLabel2.Text = v.ss.ss[0].name;
                        foreach (VideoClass.SeasonSection ss in v.ss.ss)
                        {
                            videoList1.InitCards(ss.episodes);
                        }
                        break;
                }
            }
            else
            {
                Tabs.SelectTab(0);
                CloseCase();
            }

        }

        public void RefreshUserData()
        {
            User.RefreshUserInfo();
            LoginButton.Icon = Image.FromFile(User.face);
            LoginButton.Text = User.name;
            LoginButton.BackColor = Other.GetBackGroundColor();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!User.islogin)
            {
                UI.BLoginForm loginForm = new UI.BLoginForm();
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                loginForm.Show();
                loginForm.Login();
            }

        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in videoList1.panel2.Controls)
            {
                if (c is UI.AVCard)
                {
                    UI.AVCard card = (UI.AVCard)c;
                    card.check = true;
                }
            }
            
        }

        private void DownloadSelected_Click(object sender, EventArgs e)
        {
            foreach (Control c in videoList1.panel2.Controls)
            {
                if (c is UI.AVCard)
                {
                    UI.AVCard card = (UI.AVCard)c;
                    if (card.check)
                    {
                        card.StartDownload();
                    }
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
