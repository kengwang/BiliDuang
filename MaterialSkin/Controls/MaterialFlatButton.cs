using MaterialSkin.Animations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public class MaterialFlatButton : Button, IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public MaterialSkinManager SkinManager => MaterialSkinManager.Instance;
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        public bool Primary { get; set; }

        private readonly AnimationManager animationManager;
        private readonly AnimationManager hoverAnimationManager;

        private SizeF textSize;

        private Image _icon;
        public Image Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                if (AutoSize)
                {
                    Size = GetPreferredSize();
                }

                Invalidate();
            }
        }

        public string IconTxt { get; set; }

        public bool isDrawBorder = false; //是否显示边框

        public MaterialFlatButton()
        {
            Primary = false;

            animationManager = new AnimationManager(false)
            {
                Increment = 0.03,
                AnimationType = AnimationType.EaseOut
            };
            hoverAnimationManager = new AnimationManager
            {
                Increment = 0.07,
                AnimationType = AnimationType.Linear
            };

            hoverAnimationManager.OnAnimationProgress += sender => Invalidate();
            animationManager.OnAnimationProgress += sender => Invalidate();

            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoSize = true;
            Margin = new Padding(4, 6, 4, 6);
            Padding = new Padding(0);
        }

        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                textSize = CreateGraphics().MeasureString(value, SkinManager.ROBOTO_MEDIUM_10);
                if (AutoSize)
                {
                    Size = GetPreferredSize();
                }

                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.SystemDefault;
            g.Clear(Parent.BackColor);

            if (isDrawBorder)
            {
                g.DrawRectangle(SkinManager.ColorScheme.PrimaryPen, ClientRectangle);
            }

            //Hover
            Color c = SkinManager.GetFlatButtonHoverBackgroundColor();
            using (Brush b = new SolidBrush(Color.FromArgb((int)(hoverAnimationManager.GetProgress() * c.A), ColorExtension.RemoveAlpha(c))))
            {
                g.FillRectangle(b, ClientRectangle);
            }

            //Ripple
            if (animationManager.IsAnimating())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                for (int i = 0; i < animationManager.GetAnimationCount(); i++)
                {
                    double animationValue = animationManager.GetProgress(i);
                    Point animationSource = animationManager.GetSource(i);

                    using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), Color.Black)))
                    {
                        int rippleSize = (int)(animationValue * Width * 2);
                        g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                    }
                }
                g.SmoothingMode = SmoothingMode.None;
            }

            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            //Icon
            Rectangle iconRect = new Rectangle(8, 1, 24, 24);

            if (string.IsNullOrEmpty(Text))
            {
                // Center Icon
                iconRect.X += 2;
            }

            if (Icon != null)
            {
                g.DrawImage(Icon, iconRect);
                g.DrawString(IconTxt, SkinManager.ROBOTO_MEDIUM_10,
                    Brushes.White, iconRect, sf);
            }

            //Text
            Rectangle textRect = ClientRectangle;

            if (Icon != null)
            {
                //
                // Resize and move Text container
                //

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                // Third 8: right padding
                textRect.Width -= (4 + 24 + 4 + 8);

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                //textRect.X += 8 + 24 + 4;
                textRect.X += 4 + 24 + 4;
            }

            g.DrawString(
                Text,
                SkinManager.ROBOTO_MEDIUM_10,
                Enabled ? (Primary ? SkinManager.ColorScheme.PrimaryBrush : SkinManager.GetPrimaryTextBrush()) : SkinManager.GetFlatButtonDisabledTextBrush(),
                textRect, sf);
        }

        private Size GetPreferredSize()
        {
            return GetPreferredSize(new Size(0, 0));
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            // Provides extra space for proper padding for content
            int extra = 16;

            if (Icon != null)
            {
                // 24 is for icon size
                // 4 is for the space between icon & text
                //extra += 24 + 4;
                extra += 24 + 2;
            }

            return new Size((int)Math.Ceiling(textSize.Width) + extra, 36);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode)
            {
                return;
            }

            MouseState = MouseState.OUT;
            MouseEnter += (sender, args) =>
            {
                MouseState = MouseState.HOVER;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            };
            MouseLeave += (sender, args) =>
            {
                MouseState = MouseState.OUT;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.Out);
                Invalidate();
            };
            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseState = MouseState.DOWN;

                    animationManager.StartNewAnimation(AnimationDirection.In, args.Location);
                    Invalidate();
                }
            };
            MouseUp += (sender, args) =>
            {
                MouseState = MouseState.HOVER;

                Invalidate();
            };
        }
    }
}
