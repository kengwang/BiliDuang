using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace BiliDuang.UI.UserDataForm
{
    public partial class BangumiListItem : UserControl
    {
        JSONCallback.UserBangumiFollow.ListItem BItem;
        public BangumiListItem(JSONCallback.UserBangumiFollow.ListItem BangumiItem)
        {
            InitializeComponent();
            BItem = BangumiItem;
            BName.Text = BItem.title;
            Des.Text = BItem.evaluate;
            Progress.Text = BItem.progress + " | " + BItem.new_ep.index_show;
            string deerory = Environment.CurrentDirectory + "\\temp\\";
            string fileName = string.Format("ss{0}.jpg", BItem.season_id);
            if (!File.Exists(deerory + fileName))
            {
                WebRequest imgRequest = WebRequest.Create(BItem.cover); HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)imgRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                }
                if (res.StatusCode.ToString() == "OK")
                {
                    System.Drawing.Image downImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream()); if (!System.IO.Directory.Exists(deerory))
                    {
                        System.IO.Directory.CreateDirectory(deerory);
                    }
                    downImage.Save(deerory + fileName); downImage.Dispose();
                }
            }
            pictureBox1.Image = Image.FromFile(deerory + fileName);
        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            env.mainForm.SearchBox.Text = BItem.url;
            env.mainForm.SearchStart();
            Parent.Parent.Parent.Dispose();
        }
    }
}
