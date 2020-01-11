namespace BiliDuang.UI
{
    partial class AVCard
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new MaterialSkin.Controls.MaterialLabel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.aid = new System.Windows.Forms.LinkLabel();
            this.checkbox = new MaterialSkin.Controls.MaterialCheckBox();
            this.DownloadImg = new System.Windows.Forms.Label();
            this.Download = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.QualityBox = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Depth = 0;
            this.Title.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Title.Location = new System.Drawing.Point(3, 89);
            this.Title.MouseState = MaterialSkin.MouseState.HOVER;
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(262, 142);
            this.Title.TabIndex = 0;
            this.Title.Text = "标题就是我,我就是标题";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(2, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(143, 81);
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            this.pic.MouseLeave += new System.EventHandler(this.pic_MouseLeave);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
            // 
            // aid
            // 
            this.aid.AutoSize = true;
            this.aid.Font = new System.Drawing.Font("宋体", 15F);
            this.aid.LinkColor = System.Drawing.Color.Black;
            this.aid.Location = new System.Drawing.Point(12, 231);
            this.aid.Name = "aid";
            this.aid.Size = new System.Drawing.Size(89, 20);
            this.aid.TabIndex = 3;
            this.aid.TabStop = true;
            this.aid.Text = "av170001";
            this.aid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aid_LinkClicked);
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.Depth = 0;
            this.checkbox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkbox.Location = new System.Drawing.Point(347, 12);
            this.checkbox.Margin = new System.Windows.Forms.Padding(0);
            this.checkbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkbox.Name = "checkbox";
            this.checkbox.Ripple = true;
            this.checkbox.Size = new System.Drawing.Size(26, 30);
            this.checkbox.TabIndex = 4;
            this.checkbox.UseVisualStyleBackColor = true;
            // 
            // DownloadImg
            // 
            this.DownloadImg.AutoSize = true;
            this.DownloadImg.BackColor = System.Drawing.Color.Transparent;
            this.DownloadImg.Font = new System.Drawing.Font("宋体", 13F);
            this.DownloadImg.Location = new System.Drawing.Point(13, 23);
            this.DownloadImg.Name = "DownloadImg";
            this.DownloadImg.Size = new System.Drawing.Size(80, 18);
            this.DownloadImg.TabIndex = 6;
            this.DownloadImg.Text = "下载封面";
            this.DownloadImg.Visible = false;
            // 
            // Download
            // 
            this.Download.AutoSize = true;
            this.Download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Download.Depth = 0;
            this.Download.Icon = null;
            this.Download.IconTxt = null;
            this.Download.Location = new System.Drawing.Point(152, 47);
            this.Download.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Download.MouseState = MaterialSkin.MouseState.HOVER;
            this.Download.Name = "Download";
            this.Download.Primary = false;
            this.Download.Size = new System.Drawing.Size(48, 36);
            this.Download.TabIndex = 7;
            this.Download.Text = "下载";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 13);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(380, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 300);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(-4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 298);
            this.label3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(379, 10);
            this.label4.TabIndex = 11;
            // 
            // QualityBox
            // 
            this.QualityBox.Depth = 0;
            this.QualityBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.QualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QualityBox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.QualityBox.FormattingEnabled = true;
            this.QualityBox.Items.AddRange(new object[] {
            "1080P60",
            "1080P+",
            "1080P",
            "720P60",
            "720P",
            "480P",
            "360P"});
            this.QualityBox.Location = new System.Drawing.Point(234, 51);
            this.QualityBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.QualityBox.Name = "QualityBox";
            this.QualityBox.Size = new System.Drawing.Size(140, 26);
            this.QualityBox.TabIndex = 12;
            // 
            // AVCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QualityBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.DownloadImg);
            this.Controls.Add(this.checkbox);
            this.Controls.Add(this.aid);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.Title);
            this.Name = "AVCard";
            this.Size = new System.Drawing.Size(390, 307);
            this.Load += new System.EventHandler(this.AVCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel Title;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.LinkLabel aid;
        private MaterialSkin.Controls.MaterialCheckBox checkbox;
        private System.Windows.Forms.Label DownloadImg;
        private MaterialSkin.Controls.MaterialFlatButton Download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public MaterialSkin.Controls.MaterialComboBox QualityBox;
    }
}
