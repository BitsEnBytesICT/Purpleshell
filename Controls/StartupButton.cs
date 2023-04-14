using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace ShellHolder.Controls
{
    public class StartupButton : Button
    {

        private int borderSize = 0;
        private Color borderColor = Color.Green;
        private int borderRadius = 8;

        private string firstLine = "Firstline";
        private string secondLine = "Secondline";
        private Image imageIcon = null;



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
        public string FirstLine
        {
            get { return firstLine; }
            set { firstLine = value; }
        }
        [Category("AA Custom Options")]
        public string SecondLine
        {
            get { return secondLine; }
            set { secondLine = value; }
        }
        [Category("AA Custom Options")]
        public Image ImageIcon
        {
            get { return imageIcon; }
            set { imageIcon = value; }
        }

        public override string Text {
            get { return ""; }
            set { base.Text = value; }
        }


        //Constructor
        public StartupButton() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.FromArgb(80, 80, 80);
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);
            Dock = DockStyle.Fill;
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
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
            }
            else
            {
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

            StringFormat sf = new StringFormat() { };
            Brush brush = new SolidBrush(ForeColor);


            if (imageIcon != null) {
                pevent.Graphics.DrawImage(imageIcon, 10, 10, 40, 40);
            }

            int startX = 60;

            Rectangle rectFirst = new Rectangle(startX, 10, ClientRectangle.Width - startX, 25);
            //pevent.Graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), rectFirst);
            pevent.Graphics.DrawString(firstLine, new Font(Font.FontFamily, 13, FontStyle.Bold), brush, rectFirst, sf);

            Rectangle rectSecond = new Rectangle(startX, rectFirst.Height + rectFirst.Top, ClientRectangle.Width - startX, 40);
            //pevent.Graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), rectSecond);
            StringFormat sf2 = new StringFormat() { Trimming = StringTrimming.Word };
            pevent.Graphics.DrawString(secondLine, Font, brush, rectSecond, sf2);
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
