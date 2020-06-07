namespace BiliDuang.UI
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserNameBox = new MaterialSkin.Controls.MaterialLabel();
            this.UserLevel = new MaterialSkin.Controls.MaterialLabel();
            this.VipType = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.BangumiFollow = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PageNext = new MaterialSkin.Controls.MaterialFlatButton();
            this.PageStat = new MaterialSkin.Controls.MaterialLabel();
            this.PrePage = new MaterialSkin.Controls.MaterialFlatButton();
            this.Like = new System.Windows.Forms.TabPage();
            this.coinBox = new MaterialSkin.Controls.MaterialLabel();
            this.LoadingToast = new MaterialSkin.Controls.MaterialLabel();
            this.SlogenLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            this.BangumiFollow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserNameBox
            // 
            this.UserNameBox.Depth = 0;
            this.UserNameBox.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.UserNameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UserNameBox.Location = new System.Drawing.Point(122, 76);
            this.UserNameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(455, 23);
            this.UserNameBox.TabIndex = 1;
            this.UserNameBox.Text = "用户名";
            // 
            // UserLevel
            // 
            this.UserLevel.Depth = 0;
            this.UserLevel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.UserLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UserLevel.Location = new System.Drawing.Point(124, 110);
            this.UserLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserLevel.Name = "UserLevel";
            this.UserLevel.Size = new System.Drawing.Size(49, 21);
            this.UserLevel.TabIndex = 2;
            this.UserLevel.Text = "LV";
            // 
            // VipType
            // 
            this.VipType.AutoSize = true;
            this.VipType.Depth = 0;
            this.VipType.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.VipType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VipType.Location = new System.Drawing.Point(181, 110);
            this.VipType.MouseState = MaterialSkin.MouseState.HOVER;
            this.VipType.Name = "VipType";
            this.VipType.Size = new System.Drawing.Size(0, 20);
            this.VipType.TabIndex = 3;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(12, 174);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(704, 50);
            this.materialTabSelector1.TabIndex = 4;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.BangumiFollow);
            this.materialTabControl1.Controls.Add(this.Like);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 230);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(704, 375);
            this.materialTabControl1.TabIndex = 5;
            // 
            // BangumiFollow
            // 
            this.BangumiFollow.AutoScroll = true;
            this.BangumiFollow.Controls.Add(this.panel1);
            this.BangumiFollow.Location = new System.Drawing.Point(4, 22);
            this.BangumiFollow.Name = "BangumiFollow";
            this.BangumiFollow.Padding = new System.Windows.Forms.Padding(3);
            this.BangumiFollow.Size = new System.Drawing.Size(696, 349);
            this.BangumiFollow.TabIndex = 0;
            this.BangumiFollow.Text = "我的追番";
            this.BangumiFollow.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PageNext);
            this.panel1.Controls.Add(this.PageStat);
            this.panel1.Controls.Add(this.PrePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 34);
            this.panel1.TabIndex = 0;
            // 
            // PageNext
            // 
            this.PageNext.AutoSize = true;
            this.PageNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PageNext.Depth = 0;
            this.PageNext.Icon = null;
            this.PageNext.IconTxt = null;
            this.PageNext.Location = new System.Drawing.Point(448, 0);
            this.PageNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PageNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.PageNext.Name = "PageNext";
            this.PageNext.Primary = false;
            this.PageNext.Size = new System.Drawing.Size(31, 36);
            this.PageNext.TabIndex = 2;
            this.PageNext.Text = ">";
            this.PageNext.UseVisualStyleBackColor = true;
            this.PageNext.Click += new System.EventHandler(this.PageNext_Click);
            // 
            // PageStat
            // 
            this.PageStat.Depth = 0;
            this.PageStat.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.PageStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PageStat.Location = new System.Drawing.Point(272, 9);
            this.PageStat.MouseState = MaterialSkin.MouseState.HOVER;
            this.PageStat.Name = "PageStat";
            this.PageStat.Size = new System.Drawing.Size(113, 28);
            this.PageStat.TabIndex = 1;
            this.PageStat.Text = "第N页 共N页";
            // 
            // PrePage
            // 
            this.PrePage.AutoSize = true;
            this.PrePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PrePage.Depth = 0;
            this.PrePage.Icon = null;
            this.PrePage.IconTxt = null;
            this.PrePage.Location = new System.Drawing.Point(175, 0);
            this.PrePage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PrePage.MouseState = MaterialSkin.MouseState.HOVER;
            this.PrePage.Name = "PrePage";
            this.PrePage.Primary = false;
            this.PrePage.Size = new System.Drawing.Size(31, 36);
            this.PrePage.TabIndex = 0;
            this.PrePage.Text = "<";
            this.PrePage.UseVisualStyleBackColor = true;
            this.PrePage.Click += new System.EventHandler(this.PrePage_Click);
            // 
            // Like
            // 
            this.Like.AutoScroll = true;
            this.Like.Location = new System.Drawing.Point(4, 22);
            this.Like.Name = "Like";
            this.Like.Padding = new System.Windows.Forms.Padding(3);
            this.Like.Size = new System.Drawing.Size(696, 349);
            this.Like.TabIndex = 1;
            this.Like.Text = "我的收藏夹";
            this.Like.UseVisualStyleBackColor = true;
            // 
            // coinBox
            // 
            this.coinBox.AutoSize = true;
            this.coinBox.Depth = 0;
            this.coinBox.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.coinBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coinBox.Location = new System.Drawing.Point(302, 111);
            this.coinBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.coinBox.Name = "coinBox";
            this.coinBox.Size = new System.Drawing.Size(54, 20);
            this.coinBox.TabIndex = 6;
            this.coinBox.Text = "硬币数";
            // 
            // LoadingToast
            // 
            this.LoadingToast.AutoSize = true;
            this.LoadingToast.Depth = 0;
            this.LoadingToast.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.LoadingToast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LoadingToast.Location = new System.Drawing.Point(582, 189);
            this.LoadingToast.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoadingToast.Name = "LoadingToast";
            this.LoadingToast.Size = new System.Drawing.Size(127, 20);
            this.LoadingToast.TabIndex = 7;
            this.LoadingToast.Text = "加载中,请稍后......";
            // 
            // SlogenLabel
            // 
            this.SlogenLabel.AutoSize = true;
            this.SlogenLabel.Depth = 0;
            this.SlogenLabel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.SlogenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SlogenLabel.Location = new System.Drawing.Point(124, 148);
            this.SlogenLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.SlogenLabel.Name = "SlogenLabel";
            this.SlogenLabel.Size = new System.Drawing.Size(100, 20);
            this.SlogenLabel.TabIndex = 8;
            this.SlogenLabel.Text = "Never Settle";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.IconTxt = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(661, 70);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(48, 36);
            this.materialFlatButton1.TabIndex = 9;
            this.materialFlatButton1.Text = "稿件";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 617);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.SlogenLabel);
            this.Controls.Add(this.LoadingToast);
            this.Controls.Add(this.coinBox);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.VipType);
            this.Controls.Add(this.UserLevel);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserInfoForm";
            this.Text = "用户信息";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            this.BangumiFollow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel UserNameBox;
        private MaterialSkin.Controls.MaterialLabel UserLevel;
        private MaterialSkin.Controls.MaterialLabel VipType;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage BangumiFollow;
        private System.Windows.Forms.TabPage Like;
        private MaterialSkin.Controls.MaterialLabel coinBox;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton PageNext;
        private MaterialSkin.Controls.MaterialLabel PageStat;
        private MaterialSkin.Controls.MaterialFlatButton PrePage;
        public MaterialSkin.Controls.MaterialLabel LoadingToast;
        private MaterialSkin.Controls.MaterialLabel SlogenLabel;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}