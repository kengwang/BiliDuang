using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliDuang.UI.UserDataForm
{

    public partial class LikeBoxItem : UserControl
    {
        private string id;
        public LikeBoxItem(string id,string name)
        {
            InitializeComponent();
            this.id = id;
            materialLabel1.Text = name;

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //mlxxx
            UserInfoForm f = (UserInfoForm)Parent.Parent.Parent;
            f.LoadingToast.Visible = true;
            LikeSelect likeSelect = new LikeSelect(id);
            likeSelect.ShowDialog();
            f.LoadingToast.Visible = false;
        }
    }
}
