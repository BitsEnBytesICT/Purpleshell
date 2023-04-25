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

        /// Holds all project values.
        public Project project;

        /// Sets default button text to overwrite itself to empty to draw our own.
        public override string Text {
            get { return ""; }
            set { base.Text = value; }
        }


        /// Holds the contextMenuStrip items and to call when needed.
        ContextMenuStrip contextMenuStrip;

        int contextWidth = 35;
        Rectangle contextStrip = new Rectangle(22, 10, 12, 36);



        ///Constructor
        public RecentProjectButton(Project referenceProject) {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 60);
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            Dock = DockStyle.Top;
            MouseClick += RecentProjectButton_MouseClick;

            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Open", null, new EventHandler(OpenProject_Click));
            contextMenuStrip.Items.Add("Rename", null, new EventHandler(RenameProject_Click));
            contextMenuStrip.Items.Add("Delete", null, new EventHandler(DeleteProject_Click));

            project = referenceProject;
        }

        /// When clicking at any point in button rectangle.
        private void RecentProjectButton_MouseClick(object? sender, MouseEventArgs e) {

            RecentProjectButton tabControl = (RecentProjectButton)sender;
            Point clickLocation = e.Location;
            int tabWidth = this.ClientRectangle.Width - contextStrip.X;
            Rectangle r = this.ClientRectangle;
            r.Offset(tabWidth, contextStrip.Y);
            r.Width = contextStrip.Width;
            r.Height = contextStrip.Height;

            /// Determens if click is in contextMenu location.
            if (r.Contains(clickLocation)) {
                contextMenuStrip.Show(this, this.Width, 0);
            } else            
                ProjectUtil.LoadProjectFromDirectory(project, false);
        }

        private void OpenProject_Click(object? sender, EventArgs e) {

            ProjectUtil.LoadProjectFromDirectory(project, false);
        }

        private void RenameProject_Click(object? sender, EventArgs e) {

            /// Checks if project is loaded and follows instructions to prevent errors.
            if (MainPage.mainPage.IsProjectLoaded(project)) {

                TabPage tabPage = MainPage.mainPage.GetProjectTabPage(project);

                /// If project loaded, ensure project is saved first.
                if (!FileUtils.AreYouSureSave(new List<TabPage> { tabPage }))
                    return;

                /// Then we unload the project to ensure a safe renaming protocol.
                ProjectPage projectPage = tabPage.Controls[0] as ProjectPage;
                projectPage.UnloadProject(tabPage);
            }

            string input = ProjectUtil.GetProjectNameInput();
            if (input.Length <= 0) /// If input is empty or the user hits cancel    (yes i know, but the build in prompt for this also only returns strings and an empty one on cancel, its fkin stupid idc, im not gonna make a prompt from scratch)
                return;

            string newPath = Path.Combine(FileUtils.GetSavedProjectsDirectory(), input + FileUtils.Extension);
            try {
                File.Move(project.filePath, newPath);
            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
            MainPage.mainPage.startUp.FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }

        private void DeleteProject_Click(object? sender, EventArgs e) {

            DialogResult dialogResult = MessageBox.Show(
                String.Format("Are you sure you want to delete project '{0}'", project.displayName) + Environment.NewLine +
                "This option cannot be reversed.", "", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes) {
                /// If dialog result is anything else besides yes, we cancel. Otherwise we pass on.
                return;
            }

            if (MainPage.mainPage.IsProjectLoaded(project)) {

                /// If project is loaded during runtime, unload project to ensure safe removal.
                TabPage tabPage = MainPage.mainPage.GetProjectTabPage(project);
                ProjectPage projectPage = tabPage.Controls[0] as ProjectPage;
                projectPage.UnloadProject(tabPage);
            }

            try {
                File.Delete(project.filePath);
            }
            catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
            MainPage.mainPage.startUp.FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }




        #region "Drawing of custom button."

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
            Color borderColor = Color.FromArgb(70, 70, 70);
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

            int width = 240;

            /// Display name of project
            int nHeight = 20;
            Rectangle nameRect = new Rectangle(6, 5, width, nHeight);
            pevent.Graphics.DrawString(project.displayName, new Font(Font.FontFamily, 11, FontStyle.Bold), new SolidBrush(Color.White), nameRect);
            /// ---

            pevent.Graphics.DrawLine(new Pen(new SolidBrush(Color.DimGray), 1), ClientRectangle.Width - contextWidth, 5, ClientRectangle.Width - contextWidth, ClientRectangle.Height - 6);
            //Rectangle contextRect = new Rectangle(6, ClientRectangle.Height - lwHeight - 5, width, lwHeight);
            pevent.Graphics.DrawImage(new Bitmap(Resources.TripleDot, contextStrip.Width, contextStrip.Height), ClientRectangle.Width - contextStrip.X, contextStrip.Y, contextStrip.Width, contextStrip.Height);


            /// Precise last write string
            int lwHeight = 20;
            Rectangle lastWriteRect = new Rectangle(6, ClientRectangle.Height - lwHeight - 5, width, lwHeight);
            pevent.Graphics.DrawString(project.lastWriteTime.ToString(), Font, new SolidBrush(Color.LightGray), lastWriteRect);
            /// ---


            /*/// Gives each file a different age rating to help the user reference easier.
            string age;
            TimeSpan timeDifference = DateTime.Now - project.lastWriteTime;
            if (timeDifference.TotalHours <= 24) {
                age = "Today";

                string ago;
                if (timeDifference.TotalMinutes < 1) {
                    ago = String.Format("{0} seconds ago", (int)timeDifference.TotalSeconds);
                } else if (timeDifference.TotalHours < 1) {
                    ago = String.Format("{0} minutes ago", (int)timeDifference.TotalMinutes);
                } else {
                    ago = String.Format("{0} hours ago", (int)timeDifference.TotalHours);
                }

                /// More precise last write age, seen as "x time ago"
                int agoWidth = 120;
                int agoHeight = 20;
                Rectangle agoRect = new Rectangle(ClientRectangle.Width - contextWidth - agoWidth - 7, ClientRectangle.Height - agoHeight - 5, agoWidth, agoHeight);
                pevent.Graphics.DrawString(ago, Font, new SolidBrush(Color.DimGray), agoRect, new StringFormat() { Alignment = StringAlignment.Far });
                /// ---

            } else if (timeDifference.TotalHours <= 48) {
                age = "Yesterday";
            } else if (timeDifference.TotalDays <= 7) {
                age = "This week";
            } else if (timeDifference.TotalDays <= 30) {
                age = "This month";
            } else {
                age = "Over a month ago";
            }

            /// Last write age to the project file, (today, yesterday, this month, etc)
            int ageWidth = 120;
            int ageHeight = 20;
            Rectangle ageRect = new Rectangle(ClientRectangle.Width - contextWidth - ageWidth - 7, 5, ageWidth, ageHeight);
            pevent.Graphics.DrawString(age, Font, new SolidBrush(Color.White), ageRect, new StringFormat() { Alignment = StringAlignment.Far });
            /// ---*/


            /// Gives each file a different age rating to help the user reference easier.
            string ago;
            TimeSpan timeDifference = DateTime.Now - project.lastWriteTime;
            if (timeDifference.TotalMinutes < 1) {
                ago = String.Format("{0} seconds ago", (int)timeDifference.TotalSeconds);
            }
            else if (timeDifference.TotalMinutes <= 60) {
                ago = String.Format("{0} minutes ago", (int)timeDifference.Minutes);
            }
            else if (timeDifference.TotalHours <= 48) {
                ago = String.Format("{0} hours ago", (int)timeDifference.TotalHours);
            }
            else if (timeDifference.TotalDays <= 30) {
                ago = String.Format("{0} days ago", (int)timeDifference.Days);
            }
            else if (timeDifference.TotalDays > 36500) {
                ago = "MORE THEN A CENTURY AGO?! BRO WHAT";
            }
            else {
                ago = "Over a month ago";
            }

            /// More precise last write age, seen as "x time ago"
            int agoWidth = 120;
            int agoHeight = 20;
            Rectangle agoRect = new Rectangle(ClientRectangle.Width - contextWidth - agoWidth - 7, ClientRectangle.Height - agoHeight - 5, agoWidth, agoHeight);
            pevent.Graphics.DrawString(ago, Font, new SolidBrush(Color.DimGray), agoRect, new StringFormat() { Alignment = StringAlignment.Far });
            /// ---      
        }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e) {
            Invalidate();
        }

        #endregion
    }
}
