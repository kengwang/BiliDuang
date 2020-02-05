namespace BiliDuang.UI.Download
{
    partial class DownloadItem
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
            this.MissionName = new MaterialSkin.Controls.MaterialLabel();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.Directory = new MaterialSkin.Controls.MaterialLabel();
            this.MissonCancel = new System.Windows.Forms.Label();
            this.MissionStateChange = new System.Windows.Forms.Label();
            this.StatusBox = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // MissionName
            // 
            this.MissionName.Depth = 0;
            this.MissionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.MissionName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.MissionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MissionName.Location = new System.Drawing.Point(0, 0);
            this.MissionName.MouseState = MaterialSkin.MouseState.HOVER;
            this.MissionName.Name = "MissionName";
            this.MissionName.Size = new System.Drawing.Size(761, 33);
            this.MissionName.TabIndex = 0;
            this.MissionName.Text = "MissionName";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.BackColor = System.Drawing.Color.White;
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialProgressBar1.ForeColor = System.Drawing.Color.Gray;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 87);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(761, 5);
            this.materialProgressBar1.Step = 1;
            this.materialProgressBar1.TabIndex = 1;
            // 
            // Directory
            // 
            this.Directory.Depth = 0;
            this.Directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Directory.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Directory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Directory.Location = new System.Drawing.Point(0, 33);
            this.Directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.Directory.Name = "Directory";
            this.Directory.Size = new System.Drawing.Size(761, 54);
            this.Directory.TabIndex = 2;
            this.Directory.Text = "Directory";
            // 
            // MissonCancel
            // 
            this.MissonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MissonCancel.Font = new System.Drawing.Font("Webdings", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MissonCancel.Location = new System.Drawing.Point(698, 33);
            this.MissonCancel.Name = "MissonCancel";
            this.MissonCancel.Size = new System.Drawing.Size(63, 54);
            this.MissonCancel.TabIndex = 3;
            this.MissonCancel.Text = "r";
            this.MissonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissonCancel.Click += new System.EventHandler(this.MissonCancel_Click);
            // 
            // MissionStateChange
            // 
            this.MissionStateChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.MissionStateChange.Font = new System.Drawing.Font("Webdings", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MissionStateChange.Location = new System.Drawing.Point(635, 33);
            this.MissionStateChange.Name = "MissionStateChange";
            this.MissionStateChange.Size = new System.Drawing.Size(63, 54);
            this.MissionStateChange.TabIndex = 4;
            this.MissionStateChange.Text = "4";
            this.MissionStateChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MissionStateChange.Click += new System.EventHandler(this.MissionStateChange_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Depth = 0;
            this.StatusBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBox.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.StatusBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusBox.Location = new System.Drawing.Point(0, 60);
            this.StatusBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(635, 27);
            this.StatusBox.TabIndex = 5;
            this.StatusBox.Text = "正在获取状态";
            // 
            // DownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.MissionStateChange);
            this.Controls.Add(this.MissonCancel);
            this.Controls.Add(this.Directory);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.MissionName);
            this.Name = "DownloadItem";
            this.Size = new System.Drawing.Size(761, 92);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel MissionName;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialLabel Directory;
        private System.Windows.Forms.Label MissonCancel;
        private System.Windows.Forms.Label MissionStateChange;
        private MaterialSkin.Controls.MaterialLabel StatusBox;
    }
}
