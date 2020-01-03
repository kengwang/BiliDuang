using System.Drawing;

namespace BiliDuang.UI
{
    partial class Dialog
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
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.title = new MaterialSkin.Controls.MaterialLabel();
            this.Content = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.IconTxt = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(325, 204);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(48, 36);
            this.materialFlatButton1.TabIndex = 0;
            this.materialFlatButton1.ForeColor = Other.IsDarkMode()?Color.White: Color.Black;
            this.materialFlatButton1.Text = "确认";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Depth = 0;
            this.title.Font = new System.Drawing.Font("微软雅黑", 20F);           
            this.title.Location = new System.Drawing.Point(23, 22);
            this.title.MouseState = MaterialSkin.MouseState.HOVER;
            this.title.Name = "title";
            this.title.ForeColor = Other.IsDarkMode() ? Color.White : Color.Black;
            this.title.Size = new System.Drawing.Size(69, 35);
            this.title.TabIndex = 1;
            this.title.Text = "消息";
            // 
            // Content
            // 
            this.Content.AutoSize = true;
            this.Content.Depth = 0;
            this.Content.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Content.ForeColor = Other.IsDarkMode() ? Color.White : Color.Black;            
            this.Content.Location = new System.Drawing.Point(30, 61);
            this.Content.MouseState = MaterialSkin.MouseState.HOVER;
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(99, 20);
            this.Content.TabIndex = 2;
            this.Content.Text = "消息提示内容";
            // 
            // Dialog
            // 
            this.AcceptButton = this.materialFlatButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = Other.IsDarkMode() ? Color.Black : Color.White;
            this.ClientSize = new System.Drawing.Size(386, 255);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.title);
            this.Controls.Add(this.materialFlatButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialLabel title;
        private MaterialSkin.Controls.MaterialLabel Content;
    }
}