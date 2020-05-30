namespace BiliDuang.UI.UserDataForm
{
    partial class BangumiListItem
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BName = new MaterialSkin.Controls.MaterialLabel();
            this.Des = new MaterialSkin.Controls.MaterialLabel();
            this.Progress = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BName
            // 
            this.BName.Depth = 0;
            this.BName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.BName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BName.Location = new System.Drawing.Point(124, 8);
            this.BName.MouseState = MaterialSkin.MouseState.HOVER;
            this.BName.Name = "BName";
            this.BName.Size = new System.Drawing.Size(209, 25);
            this.BName.TabIndex = 1;
            this.BName.Text = "番剧名称";
            // 
            // Des
            // 
            this.Des.Depth = 0;
            this.Des.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Des.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Des.Location = new System.Drawing.Point(131, 33);
            this.Des.MouseState = MaterialSkin.MouseState.HOVER;
            this.Des.Name = "Des";
            this.Des.Size = new System.Drawing.Size(192, 110);
            this.Des.TabIndex = 2;
            this.Des.Text = "番剧简介";
            // 
            // Progress
            // 
            this.Progress.Depth = 0;
            this.Progress.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Progress.Location = new System.Drawing.Point(11, 157);
            this.Progress.MouseState = MaterialSkin.MouseState.HOVER;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(231, 20);
            this.Progress.TabIndex = 3;
            this.Progress.Text = "进度";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.IconTxt = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(287, 151);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(48, 36);
            this.materialFlatButton1.TabIndex = 4;
            this.materialFlatButton1.Text = "下载";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // BangumiListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Des);
            this.Controls.Add(this.BName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BangumiListItem";
            this.Size = new System.Drawing.Size(335, 183);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel BName;
        private MaterialSkin.Controls.MaterialLabel Des;
        private MaterialSkin.Controls.MaterialLabel Progress;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}
