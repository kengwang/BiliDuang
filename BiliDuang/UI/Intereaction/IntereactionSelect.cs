using BiliDuang.VideoClass;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BiliDuang
{
    public partial class IntereactionSelect : MaterialForm
    {
        private readonly VideoClass.episode ep;
        private string edgeid = "1";
        private string cid;
        private readonly string aid;
        private readonly string graphversion;
        private JSONCallback.EdgeInfo.EdgeInfo edgeInfo = null;
        private readonly List<IntereactiveVideo> videos = new List<IntereactiveVideo>();
        private readonly List<Button> buttons = new List<Button>();
        private readonly Random random = new Random();
        private readonly string cookie;


        public IntereactionSelect(VideoClass.episode epin)
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            Other.RefreshColorSceme();
            ep = epin;
            aid = ep.aid;
            cid = ep.cid;
            graphversion = ep.interactionVersion;

            if (!ep.isinteractive)
            {
                Close();
                Dispose();
            }

            //获取互动视频的Cookie
            cookie = User.cookie;
            IntereactiveVideo v = new IntereactiveVideo
            {
                aid = aid,
                cid = cid,
                name = "视频开始",
                nodeid = "1"
            };
            videos.Add(v);
            LoadEdge();
        }

        public void LoadEdge()
        {
            try
            {

                buttons.Clear();
                SelectionPanel.Controls.Clear();
                WebClient MyWebClient = new WebClient
                {
                    Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                };
                MyWebClient.Headers.Add("Cookie", cookie);
                string callback = Encoding.UTF8.GetString(MyWebClient.DownloadData(string.Format("https://api.bilibili.com/x/stein/edgeinfo_v2?aid={0}&edge_id={1}&graph_version={2}", aid, edgeid, graphversion))); 
                edgeInfo = JsonConvert.DeserializeObject<JSONCallback.EdgeInfo.EdgeInfo>(callback);
                MyWebClient.Dispose();
                if (!Settings.lowcache)
                {
                    try
                    {
                        if (cid == "")
                        {
                            cid = edgeInfo.data.story_list[0].cid;
                        }

                        new WebClient().DownloadFile(string.Format("http://i0.hdslb.com/bfs/steins-gate/{0}_screenshot.jpg", cid), Environment.CurrentDirectory + string.Format("/temp/av{0}-edge{1}.jpg", aid, edgeid));

                    }
                    catch (Exception)
                    {

                    }
                    if (File.Exists(Environment.CurrentDirectory + string.Format("/temp/av{0}-edge{1}.jpg", aid, edgeid)))
                    {
                        SelectionPanel.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + string.Format("/temp/av{0}-edge{1}.jpg", aid, edgeid));
                    }

                }
                if (edgeInfo.data.edges.questions == null)
                {
                    Dialog.Show("您无法继续选择,请直接开始下载");
                    return;
                }
                for (int i = 0; i < edgeInfo.data.edges.questions[0].choices.Count; i++)
                {
                    JSONCallback.EdgeInfo.ChoicesItem choice = edgeInfo.data.edges.questions[0].choices[i];
                    Button button;
                    button.edgeid = choice.id;
                    button.cid = choice.cid;
                    button.option = choice.option;
                    if (choice.x != 0 && choice.y != 0)
                    {
                        button.x = Convert.ToInt32(Math.Floor(choice.x / 1.5));
                        button.y = Convert.ToInt32(Math.Floor(choice.y / 1.5));
                    }
                    else
                    {
                        button.x = 0;
                        button.y = (edgeInfo.data.edges.questions[0].choices.Count * 40) - (i * 38);
                    }
                    button.id = random.Next();
                    buttons.Add(button);

                    InteractiveSelectButton btn = new InteractiveSelectButton();
                    SelectionPanel.Controls.Add(btn);
                    btn.Text = button.option;
                    btn.uniqueid = button.id;
                    btn.Location = new Point(button.x, button.y);
                    btn.Click += SelectAnswer;
                }
            }
            catch (Exception)
            {
                Dialog.Show("您无法继续选择,请直接开始下载");
            }
        }

        private void SelectAnswer(object sender, EventArgs e)
        {
            InteractiveSelectButton btn = (InteractiveSelectButton)sender;
            foreach (Button button in buttons)
            {
                if (button.id != btn.uniqueid)
                {
                    continue;
                }

                IntereactiveVideo v = new IntereactiveVideo
                {
                    aid = aid,
                    cid = button.cid,
                    name = btn.Text,
                    nodeid = button.edgeid
                };
                edgeid = button.edgeid;
                cid = button.cid;
                videos.Add(v);
                LoadEdge();
                break;
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择视频下载路径,会将你所有选项下载到里面");
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string downloadpath = dialog.SelectedPath;
                foreach (IntereactiveVideo video in videos)
                {
                    episode ep = new episode
                    {
                        aid = aid,
                        cid = video.cid,
                        name = video.name + " (" + video.nodeid + ")"
                    };
                    ep.Download(downloadpath, 120);
                }
                Dialog.Show("成功添加下载!");
            }
            return;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            if (MessageBox.Show("重置剧情将会重置所选择的所有视频,如需要下载,请先点击取消再点击开始下载.\r\n否则你只需点击确定.", "请注意", messButton) == DialogResult.OK)
            {
                cid = ep.cid;
                edgeid = "1";
                videos.Clear();
                LoadEdge();
            }

        }
    }

    internal class InteractiveSelectButton : MaterialFlatButton
    {
        public int uniqueid;
    }

    internal struct IntereactiveVideo
    {
        public string aid;
        public string cid;
        public string nodeid;
        public string name;
    }

    internal struct Button
    {
        public int id;
        public string edgeid;
        public string cid;
        public int x;
        public int y;
        public string option;
    }

}
