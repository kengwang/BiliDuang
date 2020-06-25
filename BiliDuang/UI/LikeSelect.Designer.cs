namespace BiliDuang.UI
{
    partial class LikeSelect
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.PageNextButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.PageUpButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(131, 637);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(190, 20);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "第 N 页 / 共 N 页";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PageNextButton
            // 
            this.PageNextButton.AutoSize = true;
            this.PageNextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PageNextButton.Depth = 0;
            this.PageNextButton.Icon = null;
            this.PageNextButton.IconTxt = null;
            this.PageNextButton.Location = new System.Drawing.Point(338, 635);
            this.PageNextButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PageNextButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.PageNextButton.Name = "PageNextButton";
            this.PageNextButton.Primary = false;
            this.PageNextButton.Size = new System.Drawing.Size(31, 36);
            this.PageNextButton.TabIndex = 1;
            this.PageNextButton.Text = ">";
            this.PageNextButton.UseVisualStyleBackColor = true;
            this.PageNextButton.Click += new System.EventHandler(this.PageNextButton_Click);
            // 
            // PageUpButton
            // 
            this.PageUpButton.AutoSize = true;
            this.PageUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PageUpButton.Depth = 0;
            this.PageUpButton.Icon = null;
            this.PageUpButton.IconTxt = null;
            this.PageUpButton.Location = new System.Drawing.Point(83, 635);
            this.PageUpButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PageUpButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.PageUpButton.Name = "PageUpButton";
            this.PageUpButton.Primary = false;
            this.PageUpButton.Size = new System.Drawing.Size(31, 36);
            this.PageUpButton.TabIndex = 2;
            this.PageUpButton.Text = "<";
            this.PageUpButton.UseVisualStyleBackColor = true;
            this.PageUpButton.Click += new System.EventHandler(this.PageUpButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 531);
            this.panel1.TabIndex = 3;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.IconTxt = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(292, 64);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(76, 36);
            this.materialFlatButton1.TabIndex = 5;
            this.materialFlatButton1.Text = "下载选中";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(375, 70);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(85, 30);
            this.materialCheckBox1.TabIndex = 4;
            this.materialCheckBox1.Text = "选择全部";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            this.materialCheckBox1.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // UpUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 666);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PageUpButton);
            this.Controls.Add(this.PageNextButton);
            this.Controls.Add(this.materialLabel1);
            this.Name = "LikeSelect";
            this.Text = "收藏夹查看";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton PageNextButton;
        private MaterialSkin.Controls.MaterialFlatButton PageUpButton;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}