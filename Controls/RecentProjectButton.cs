using ShellHolder.Properties;
using ShellHolder.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder.Controls
{
    public class RecentProjectButton : Button
    {
        public Project project;

        public override string Text {
            get { return ""; }
            set { base.Text = value; }
        }

        //Constructor
        public RecentProjectButton(Project referenceProject) {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 60);
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            Dock = DockStyle.Top;
            Click += StartupButton_Click;

            ContextMenuStrip cm = new ContextMenuStrip();
            //cm.Items.Add(referenceProject.displayName);
            cm.Items.Add("Delete", Resources.Delete, new EventHandler(DeleteProject_Click));
            cm.Items.Add("Rename", Resources.Rename, new EventHandler(RenameProject_Click));

            this.ContextMenuStrip = cm;

            project = referenceProject;
        }

        private void StartupButton_Click(object? sender, EventArgs e) {

            MainPage.mainPage.LoadProjectFromDirectory(project, false);
        }

        private void DeleteProject_Click(object? sender, EventArgs e) {

            if (MainPage.mainPage.currentProject != null) {

                if (project.filePath == MainPage.mainPage.currentProject.filePath) {

                    MainPage.mainPage.UnloadCurrentProject();
                    /*bool Continue = MainPage.mainPage.AreYouSureSave();
                    if (!Continue)
                        return;*/
                }
            }


            DialogResult dialogResult = MessageBox.Show(
                String.Format("Are you sure you want to delete project '{0}'", project.displayName) + Environment.NewLine +
                "This option cannot be reversed.", "", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes) {
                /// If dialog result is anything else besides yes, we cancel. Otherwise we pass on.
                return;
            }

            if (MainPage.mainPage.currentProject != null) {
                MainPage.mainPage.UnloadCurrentProject();
            }

            try {
                File.Delete(project.filePath);
            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
            MainPage.mainPage.startUp.FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }

        private void RenameProject_Click(object? sender, EventArgs e) {

            if (MainPage.mainPage.currentProject != null) {

                if (project.filePath == MainPage.mainPage.currentProject.filePath) {

                    if (!MainPage.mainPage.AreYouSureSave())
                        return;

                    MainPage.mainPage.UnloadCurrentProject();
                }
            }

            string input = ProjectUtil.GetProjectNameInput();
            if (input.Length <= 0) {
                return;
            }

            string newPath = Path.Combine(FileUtils.GetSavedProjectsDirectory(), input + FileUtils.Extension);
            Trace.WriteLine(newPath);
            try {
                File.Move(project.filePath, newPath);
            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }

            MainPage.mainPage.startUp.FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius) {

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

        protected override void OnPaint(PaintEventArgs pevent) {

            base.OnPaint(pevent);

            int borderSize = 2;
            Color borderColor = Color.FromArgb(70,70,70);
            int borderRadius = 0;

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;
            if (borderRadius > 2) {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize)) {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                Region = new Region(rectSurface);
                if (borderSize >= 1) {
                    using (Pen penBorder = new Pen(borderColor, borderSize)) {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }

            StringFormat sf = new StringFormat() { };
            Brush brush = new SolidBrush(ForeColor);

            int width = 240;

            int nHeight = 20;
            Rectangle nameRect = new Rectangle(7, 5, width, nHeight);
            pevent.Graphics.DrawString(project.displayName, new Font(Font.FontFamily, 11, FontStyle.Bold), brush, nameRect, sf);

            int lwHeight = 20;
            Rectangle lastWriteRect = new Rectangle(7, ClientRectangle.Height - lwHeight - 3, width, lwHeight);
            pevent.Graphics.DrawString(project.lastWriteTime.ToString(), Font, brush, lastWriteRect, sf);


            /// Gives each file a different age rating to help the user reference easier.
            string age = "Unknown";
            TimeSpan timeDifference = DateTime.Now - project.lastWriteTime;
            if (timeDifference.TotalHours <= 24) {
                age = "Today";
            } else if (timeDifference.TotalHours <= 48) {
                age = "Yesterday";
            } else if (timeDifference.TotalDays <= 7) {
                age = "This week";
            } else if (timeDifference.TotalDays <= 30) {
                age = "This month";
            } else {
                age = "Over a month ago";
            }

            int ageWidth = 120;
            Rectangle ageRect = new Rectangle(ClientRectangle.Width - ageWidth - 10, 5, ageWidth, 20);
            StringFormat sf3 = new StringFormat() { Alignment = StringAlignment.Far };
            pevent.Graphics.DrawString(age, Font, brush, ageRect, sf3);
        }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e) {
            Invalidate();
        }
    }
}
