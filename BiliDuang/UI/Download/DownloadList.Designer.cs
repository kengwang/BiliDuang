namespace BiliDuang.UI.Download
{
    partial class DownloadList
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.StartAllButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.PauseAll = new MaterialSkin.Controls.MaterialFlatButton();
            this.DeleteAll = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 490);
            this.panel1.TabIndex = 1;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(816, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(39, 20);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "刷新";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // StartAllButton
            // 
            this.StartAllButton.AutoSize = true;
            this.StartAllButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartAllButton.Depth = 0;
            this.StartAllButton.Icon = null;
            this.StartAllButton.IconTxt = null;
            this.StartAllButton.Location = new System.Drawing.Point(729, 0);
            this.StartAllButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartAllButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartAllButton.Name = "StartAllButton";
            this.StartAllButton.Primary = false;
            this.StartAllButton.Size = new System.Drawing.Size(76, 36);
            this.StartAllButton.TabIndex = 3;
            this.StartAllButton.Text = "开始下载";
            this.StartAllButton.UseVisualStyleBackColor = true;
            this.StartAllButton.Click += new System.EventHandler(this.StartAllButton_Click);
            // 
            // PauseAll
            // 
            this.PauseAll.AutoSize = true;
            this.PauseAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PauseAll.Depth = 0;
            this.PauseAll.Icon = null;
            this.PauseAll.IconTxt = null;
            this.PauseAll.Location = new System.Drawing.Point(656, 1);
            this.PauseAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PauseAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.PauseAll.Name = "PauseAll";
            this.PauseAll.Primary = false;
            this.PauseAll.Size = new System.Drawing.Size(76, 36);
            this.PauseAll.TabIndex = 4;
            this.PauseAll.Text = "暂停全部";
            this.PauseAll.UseVisualStyleBackColor = true;
            this.PauseAll.Click += new System.EventHandler(this.PauseAll_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.AutoSize = true;
            this.DeleteAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteAll.Depth = 0;
            this.DeleteAll.Icon = null;
            this.DeleteAll.IconTxt = null;
            this.DeleteAll.Location = new System.Drawing.Point(567, 1);
            this.DeleteAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Primary = false;
            this.DeleteAll.Size = new System.Drawing.Size(76, 36);
            this.DeleteAll.TabIndex = 5;
            this.DeleteAll.Text = "删除全部";
            this.DeleteAll.UseVisualStyleBackColor = true;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // DownloadList
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.DeleteAll);
            this.Controls.Add(this.PauseAll);
            this.Controls.Add(this.StartAllButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "DownloadList";
            this.Size = new System.Drawing.Size(897, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton StartAllButton;
        private MaterialSkin.Controls.MaterialFlatButton PauseAll;
        private MaterialSkin.Controls.MaterialFlatButton DeleteAll;
    }
}
