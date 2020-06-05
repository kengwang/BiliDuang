using BiliDuang.UI;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            Other.RefreshColorSceme();

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\config");
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\temp");
            RefreshUserData();
            Settings.ReadSettings();
            materialSingleLineTextField2.Text = Settings.maxMission.ToString();
            LowCache.Checked = Settings.lowcache;
            useoutland.Checked = Settings.outland;
            materialLabel2.BackColor = Other.GetBackGroundColor();
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
                SearchStart();
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
            if (User.islogin)
            {
                LoginButton.Icon = Image.FromFile(User.face);
                LoginButton.Text = User.name;
            }
            else
            {
                LoginButton.Icon = null;
                LoginButton.Text = "登录bilibili,开启新世界";
            }
            LoginButton.BackColor = Other.GetBackGroundColor();
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
            Settings.SaveSettings();
            Environment.Exit(0);
        }

        private void QualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in videoList1.panel2.Controls)
            {
                if (c is UI.AVCard)
                {
                    UI.AVCard card = (UI.AVCard)c;
                    card.QualityBox.SelectedIndex = QualityBox.SelectedIndex;
                }
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control c in videoList1.panel2.Controls)
            {
                if (c is UI.AVCard)
                {
                    UI.AVCard card = (UI.AVCard)c;

                    card.check = !card.check;

                }
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (Control c in videoList1.panel2.Controls)
                {
                    if (c is UI.AVCard)
                    {
                        UI.AVCard card = (UI.AVCard)c;

                        card.DPath = dialog.SelectedPath;

                    }
                }
                materialSingleLineTextField1.Text = dialog.SelectedPath;
            }
        }

        public void StartAllButton_Click(object sender, EventArgs e)
        {
            DownloadQueue.StartAll();
        }

        private void PauseAll_Click(object sender, EventArgs e)
        {
            DownloadQueue.PauseAll();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            DownloadQueue.DeleteAll();
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchStart();
            }
        }

        public void SearchStart()
        {
            videoList1.DisableAllCards();
            Settings.outland = useoutland.Checked;
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
                        Tabs.SelectTab(1);
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
                    Tabs.SelectTab(1);
                    break;
            }
        }


        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedIndex >= 2)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DownloadQueue.SaveMissons();
            Environment.Exit(0);
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            using (Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = "-version";
                // 禁用操作系统外壳程序 
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;    //输出开启
                process.StartInfo.RedirectStandardInput = true;        //输入开启
                process.Start();    //启动进程
                MessageBox.Show(process.StandardOutput.ReadToEnd() + Environment.NewLine);    //需要读取的控制台内容
            }


        }

        private void materialSingleLineTextField1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (Control c in videoList1.panel2.Controls)
                {
                    if (c is UI.AVCard)
                    {
                        UI.AVCard card = (UI.AVCard)c;

                        card.DPath = materialSingleLineTextField1.Text;


                    }
                }
                MessageBox.Show(materialSingleLineTextField1.Text);
            }
        }

        private void useoutland_CheckedChanged(object sender, EventArgs e)
        {
            Settings.outland = useoutland.Checked;
            Settings.SaveSettings();
        }

        private void LowCache_CheckedChanged(object sender, EventArgs e)
        {
            Settings.lowcache = LowCache.Checked;
            Settings.SaveSettings();
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            Settings.maxMission = int.Parse(materialSingleLineTextField2.Text);
            Settings.SaveSettings();
        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            About aboutdlg = new About();
            aboutdlg.ShowDialog();
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedIndex == 0)
            {
                Settings.autodark = true;
                Other.RefreshColorSceme();
            }
            else
            {
                Settings.autodark = false;
                Settings.darkmode = materialComboBox1.SelectedIndex == 2 ? false : true;
                Other.RefreshColorSceme();
            }
        }

        private void LoginButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                EditSession form = new EditSession();
                form.ShowDialog();
                RefreshUserData();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (!User.islogin)
                {
                    UI.BLoginForm loginForm = new UI.BLoginForm();
                    loginForm.StartPosition = FormStartPosition.CenterScreen;
                    loginForm.Show();
                    loginForm.Login();
                }
                else
                {
                    UserInfoForm uf = new UserInfoForm();
                    uf.ShowDialog();
                }
            }
        }
    }
}
