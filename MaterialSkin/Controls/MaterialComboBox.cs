using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class MaterialComboBox : ComboBox, IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public MaterialSkinManager SkinManager { get { return MaterialSkinManager.Instance; } }
        [Browsable(false)]
        public MouseState MouseState { get; set; }

        private bool isHovered = false;
        private bool isPressed = false;
        private bool isFocused = false;

        public MaterialComboBox() : base()
        {
            this.SetStyle(ControlStyles.DoubleBuffer
                          | ControlStyles.AllPaintingInWmPaint
                          | ControlStyles.OptimizedDoubleBuffer
                          | ControlStyles.UserPaint, true);
            //设置为手动绘制
            this.DrawMode = DrawMode.OwnerDrawFixed;
            //设置固定的DropDownList样式
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.UpdateStyles();
            Font = SkinManager.ROBOTO_MEDIUM_10;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.ItemHeight = GetPreferredSize(Size.Empty).Height;

            Color backColor, borderColor, foreColor;

            if (Parent != null)
            {
                backColor = Parent.BackColor;
            }
            else
            {
                backColor = Color.FromArgb(255, 255, 255);
            }

            if (isHovered && !isPressed && Enabled)
            {
                //foreColor = Color.FromArgb(17, 17, 17);
                //borderColor = Color.FromArgb(51, 51, 51);
                foreColor = Color.FromArgb(0, 120, 215);
                borderColor = Color.FromArgb(0, 120, 215);
            }
            else if (isHovered && isPressed && Enabled)
            {
                //foreColor = Color.FromArgb(153, 153, 153);
                //borderColor = Color.FromArgb(153, 153, 153);
                foreColor = Color.FromArgb(0, 120, 215);
                borderColor = Color.FromArgb(0, 120, 215);
            }
            else if (!Enabled)
            {
                //foreColor = Color.FromArgb(136, 136, 136);
                //borderColor = Color.FromArgb(204, 204, 204);
                foreColor = Color.FromArgb(17, 17, 17);
                borderColor = Color.FromArgb(51, 51, 51);
            }
            else
            {
                //foreColor = Color.FromArgb(153, 153, 153);
                //borderColor = Color.FromArgb(153, 153, 153);
                foreColor = Color.FromArgb(17, 17, 17);
                borderColor = Color.FromArgb(51, 51, 51);
            }

            e.Graphics.Clear(backColor);

            using (Pen p = new Pen(borderColor))
            {
                Rectangle boxRect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(p, boxRect);
            }

            using (SolidBrush b = new SolidBrush(foreColor))
            {
                e.Graphics.FillPolygon(b, new Point[] { new Point(Width - 20, (Height / 2) - 2), new Point(Width - 9, (Height / 2) - 2), new Point(Width - 15, (Height / 2) + 4) });
            }

            Color textColor = Color.FromArgb(17, 17, 17);
            Rectangle textRect = new Rectangle(2, 2, Width - 20, Height - 4);
            TextRenderer.DrawText(e.Graphics, Text, Font, textRect, textColor, backColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            if (false && isFocused)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Color backColor, foreColor;

                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect)
                    || e.State == DrawItemState.None)
                {
                    backColor = Color.FromArgb(255, 255, 255);
                    foreColor = Color.FromArgb(0, 0, 0);
                }
                else
                {
                    backColor = Color.FromArgb(0, 120, 215); //Color.FromArgb(0, 174, 219);
                    foreColor = Color.FromArgb(250, 250, 250);
                }

                using (SolidBrush b = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
                }

                Rectangle textRect = new Rectangle(0, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                string text;
                Object item = Items[e.Index];
                if (!string.IsNullOrEmpty(DisplayMember))
                {
                    Type type = item.GetType();
                    PropertyInfo prop = type.GetProperty(DisplayMember);
                    text = (string)prop.GetValue(item, null);
                }
                else
                {
                    text = item.ToString();
                }
                TextRenderer.DrawText(e.Graphics, text, Font, textRect, foreColor, backColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else
            {
                base.OnDrawItem(e);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            isFocused = true;
            Invalidate();

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLostFocus(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            isFocused = true;
            Invalidate();

            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnLeave(e);
        }

        #region Keyboard Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                isHovered = true;
                isPressed = true;
                Invalidate();
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            isHovered = false;
            isPressed = false;
            Invalidate();

            base.OnKeyUp(e);
        }

        #endregion

        #region Mouse Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Invalidate();

            base.OnMouseLeave(e);
        }

        #endregion

        #region Overridden Methods

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize;
            base.GetPreferredSize(proposedSize);

            using (var g = CreateGraphics())
            {
                string measureText = Text.Length > 0 ? Text : "MeasureText";
                proposedSize = new Size(int.MaxValue, int.MaxValue);
                preferredSize = TextRenderer.MeasureText(g, measureText, Font, proposedSize, TextFormatFlags.Left | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.VerticalCenter);
                preferredSize.Height += 4;
            }

            return preferredSize;
        }

        #endregion
    }
}
