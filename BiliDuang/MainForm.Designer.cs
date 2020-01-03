using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiliDuang
{
    partial class MainForm
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


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.Tabs = new MaterialSkin.Controls.MaterialTabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.SearchResult = new System.Windows.Forms.TabPage();
            this.DownloadSelected = new MaterialSkin.Controls.MaterialFlatButton();
            this.SelectAll = new MaterialSkin.Controls.MaterialFlatButton();
            this.videoList1 = new BiliDuang.UI.VideoList();
            this.DownloadView = new System.Windows.Forms.TabPage();
            this.downloadList1 = new BiliDuang.UI.Download.DownloadList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.Tabs.SuspendLayout();
            this.SearchResult.SuspendLayout();
            this.DownloadView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabSelector
            // 
            this.TabSelector.BaseTabControl = this.Tabs;
            this.TabSelector.Depth = 0;
            this.TabSelector.Font = new System.Drawing.Font("微软雅黑", 5F);
            this.TabSelector.Location = new System.Drawing.Point(-1, 77);
            this.TabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabSelector.Name = "TabSelector";
            this.TabSelector.Size = new System.Drawing.Size(1103, 54);
            this.TabSelector.TabIndex = 0;
            this.TabSelector.Text = "选择标签";
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.MainTab);
            this.Tabs.Controls.Add(this.SearchResult);
            this.Tabs.Controls.Add(this.DownloadView);
            this.Tabs.Depth = 0;
            this.Tabs.Font = new System.Drawing.Font("微软雅黑", 5F);
            this.Tabs.Location = new System.Drawing.Point(1, 137);
            this.Tabs.MouseState = MaterialSkin.MouseState.HOVER;
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1101, 542);
            this.Tabs.TabIndex = 1;
            // 
            // MainTab
            // 
            this.MainTab.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTab.Location = new System.Drawing.Point(4, 18);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(1093, 520);
            this.MainTab.TabIndex = 1;
            this.MainTab.Text = "主页";
            // 
            // SearchResult
            // 
            this.SearchResult.Controls.Add(this.DownloadSelected);
            this.SearchResult.Controls.Add(this.SelectAll);
            this.SearchResult.Controls.Add(this.videoList1);
            this.SearchResult.Location = new System.Drawing.Point(4, 18);
            this.SearchResult.Name = "SearchResult";
            this.SearchResult.Size = new System.Drawing.Size(1093, 520);
            this.SearchResult.TabIndex = 2;
            this.SearchResult.Text = "搜索结果";
            // 
            // DownloadSelected
            // 
            this.DownloadSelected.AutoSize = true;
            this.DownloadSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DownloadSelected.Depth = 0;
            this.DownloadSelected.Icon = null;
            this.DownloadSelected.IconTxt = null;
            this.DownloadSelected.Location = new System.Drawing.Point(928, 47);
            this.DownloadSelected.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DownloadSelected.MouseState = MaterialSkin.MouseState.HOVER;
            this.DownloadSelected.Name = "DownloadSelected";
            this.DownloadSelected.Primary = false;
            this.DownloadSelected.Size = new System.Drawing.Size(76, 36);
            this.DownloadSelected.TabIndex = 5;
            this.DownloadSelected.Text = "下载选中";
            this.DownloadSelected.UseVisualStyleBackColor = true;
            this.DownloadSelected.Click += new System.EventHandler(this.DownloadSelected_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.AutoSize = true;
            this.SelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectAll.Depth = 0;
            this.SelectAll.Icon = null;
            this.SelectAll.IconTxt = null;
            this.SelectAll.Location = new System.Drawing.Point(1004, 48);
            this.SelectAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SelectAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Primary = false;
            this.SelectAll.Size = new System.Drawing.Size(76, 36);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "选中全部";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // videoList1
            // 
            this.videoList1.Location = new System.Drawing.Point(-6, 82);
            this.videoList1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.videoList1.Name = "videoList1";
            this.videoList1.Size = new System.Drawing.Size(1103, 438);
            this.videoList1.TabIndex = 0;
            // 
            // DownloadView
            // 
            this.DownloadView.Controls.Add(this.downloadList1);
            this.DownloadView.Location = new System.Drawing.Point(4, 18);
            this.DownloadView.Name = "DownloadView";
            this.DownloadView.Size = new System.Drawing.Size(1093, 520);
            this.DownloadView.TabIndex = 3;
            this.DownloadView.Text = "下载管理";
            this.DownloadView.UseVisualStyleBackColor = true;
            // 
            // downloadList1
            // 
            this.downloadList1.AutoScroll = true;
            this.downloadList1.Location = new System.Drawing.Point(120, 51);
            this.downloadList1.Name = "downloadList1";
            this.downloadList1.Size = new System.Drawing.Size(1085, 469);
            this.downloadList1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.SearchBox);
            this.panel1.Controls.Add(this.materialFlatButton1);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Location = new System.Drawing.Point(51, 318);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 50);
            this.panel1.TabIndex = 4;
            // 
            // SearchBox
            // 
            this.SearchBox.Depth = 0;
            this.SearchBox.Hint = "输入AV号,md号,ss号,ep号,链接,输入完成按回车";
            this.SearchBox.Location = new System.Drawing.Point(133, 23);
            this.SearchBox.MaxLength = 32767;
            this.SearchBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PasswordChar = '\0';
            this.SearchBox.SelectedText = "";
            this.SearchBox.SelectionLength = 0;
            this.SearchBox.SelectionStart = 0;
            this.SearchBox.Size = new System.Drawing.Size(743, 25);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TabStop = false;
            this.SearchBox.Text = "av30333630";
            this.SearchBox.UseSystemPasswordChar = false;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.IconTxt = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(887, 15);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(103, 36);
            this.materialFlatButton1.TabIndex = 1;
            this.materialFlatButton1.Text = "Link Start!";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(0, 23);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(139, 28);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "勇者大人请传令->";
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(345, 86);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(757, 33);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "f";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginButton.Depth = 0;
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginButton.Icon = null;
            this.LoginButton.IconTxt = null;
            this.LoginButton.Location = new System.Drawing.Point(857, 30);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Primary = false;
            this.LoginButton.Size = new System.Drawing.Size(168, 36);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "登录bilibili,开启新世界";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 675);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.TabSelector);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Sizable = false;
            this.Text = "BiliDuang";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Tabs.ResumeLayout(false);
            this.SearchResult.ResumeLayout(false);
            this.SearchResult.PerformLayout();
            this.DownloadView.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void materialListView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector TabSelector;
        private MaterialSkin.Controls.MaterialTabControl Tabs;
        private System.Windows.Forms.TabPage MainTab;
        private MaterialSkin.Controls.MaterialFlatButton LoginButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField SearchBox;
        private Panel panel1;
        private TabPage SearchResult;
        private UI.VideoList videoList1;
        private TabPage DownloadView;
        public UI.Download.DownloadList downloadList1;
        private MaterialSkin.Controls.MaterialFlatButton SelectAll;
        private MaterialSkin.Controls.MaterialFlatButton DownloadSelected;
    }
}

