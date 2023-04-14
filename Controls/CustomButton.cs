using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace ShellHolder.Controls
{
    public class CustomButton : Button
    {

        private int borderSize = 0;
        private Color borderColor = Color.Green;
        private int borderRadius = 8;
        private Image imageIcon = null;
        private int imagePadding = 0;
        public bool NotificationIcon = false;



        [Category("AA Custom Options")]
        public Color BackgroundColor {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("AA Custom Options")]
        public Color TextColor {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Category("AA Custom Options")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        [Category("AA Custom Options")]
        public int BorderSize {
            get { return borderSize; }
            set { borderSize = value; }
        }

        [Category("AA Custom Options")]
        public Color BorderColor {
            get { return borderColor; }
            set { borderColor = value; }
        }

        [Category("AA Custom Options")]
        public Image ImageIcon {
            get { return imageIcon; }
            set { imageIcon = value; }
        }

        [Category("AA Custom Options")]
        public int ImagePadding {
            get { return imagePadding; }
            set { imagePadding = value; }
        }


        /*public override string Text {
            get { return ""; }
            set { base.Text = value; }
        }*/


        //Constructor
        public CustomButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(50, 50);
            BackColor = Color.FromArgb(80, 80, 80);
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            BackColor = Color.FromArgb(Enabled ? 100 : 35, BackColor);
            borderColor = Color.FromArgb(Enabled ? 100 : 35, borderColor);
            ForeColor = Color.FromArgb(Enabled ? 100 : 35, ForeColor);


            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;
            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            } else {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                Region = new Region(rectSurface);
                if (borderSize >= 1) {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }

            if (imageIcon != null) {
                int width = ClientRectangle.Width - (imagePadding * 2);
                int height = ClientRectangle.Height - (imagePadding * 2);

                pevent.Graphics.DrawImage(imageIcon, imagePadding, imagePadding, width, height);
            }

            if (NotificationIcon) {
                int size = 7;
                int fromBorder = 4;
                pevent.Graphics.FillEllipse(Brushes.Orange, new Rectangle(ClientRectangle.Width - size - fromBorder, 0 + fromBorder, size, size));
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
