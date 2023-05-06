using Purpleshell.Properties;
using ShellHolder.Util;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
        Rectangle hitAreaContext = new Rectangle(35, 0, 35, 60);
        Rectangle drawContext = new Rectangle(22, 10, 12, 36);



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
            contextMenuStrip.Items.Add("Duplicate", null, new EventHandler(DuplicateProject_Click));
            contextMenuStrip.Items.Add("Delete", null, new EventHandler(DeleteProject_Click));
            contextMenuStrip.Items.Add("Remove from list", null, new EventHandler(RemoveFromList_Click));
            contextMenuStrip.Items.Add("Open in folder", null, new EventHandler(OpenFolder_Click));

            project = referenceProject;
        }

        /// When clicking at any point in button rectangle.
        private void RecentProjectButton_MouseClick(object? sender, MouseEventArgs e) {

            RecentProjectButton tabControl = (RecentProjectButton)sender;
            Point clickLocation = e.Location;
            int tabWidth = this.ClientRectangle.Width - hitAreaContext.X;
            Rectangle r = this.ClientRectangle;
            r.Offset(tabWidth, hitAreaContext.Y);
            r.Width = hitAreaContext.Width;
            r.Height = hitAreaContext.Height;

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

            if (!File.Exists(project.filePath)) {
                MessageBox.Show("Could not find specified project");
                MainPage.mainPage.startUp.ReloadProjects();
                return;
            }

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

            string input = ProjectUtil.GetProjectNameInput(project.filePath, project.displayName, project.displayName);
            if (input.Length <= 0) /// If input is empty or the user hits cancel    (yes i know, but the build in prompt for this also only returns strings and an empty one on cancel, its fkin stupid idc, im not gonna make a prompt from scratch)
                return;
            if (input == project.displayName)
                return;


            string newPath = Path.Combine(Path.GetDirectoryName(project.filePath), input + FileUtils.Extension);
            try {
                File.Move(project.filePath, newPath);
                SettingsUtil.RemoveProject(project);
                project.filePath = newPath;
                SettingsUtil.AddProject(project);
            }
            catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
            MainPage.mainPage.startUp.ReloadProjects();
        }

        private void DuplicateProject_Click(object? sender, EventArgs e) {

            if (!File.Exists(project.filePath)) {
                MessageBox.Show("Could not find specified project");
                MainPage.mainPage.startUp.ReloadProjects();
                return;
            }

            string input = ProjectUtil.GetProjectNameInput(project.filePath, project.displayName, project.displayName + "_Copy");
            if (input.Length <= 0) /// If input is empty or the user hits cancel    (yes i know, but the build in prompt for this also only returns strings and an empty one on cancel, its fkin stupid idc, im not gonna make a prompt from scratch)
                return;

            string newPath = Path.Combine(Path.GetDirectoryName(project.filePath), input + FileUtils.Extension);
            try {
                File.Copy(project.filePath, newPath);

                Project duplicateProject = RetrieveProjectFile(newPath);
                SettingsUtil.AddProject(duplicateProject);
            }
            catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
            MainPage.mainPage.startUp.ReloadProjects();
        }

        private void DeleteProject_Click(object? sender, EventArgs e) {

            if (!File.Exists(project.filePath)) {
                MessageBox.Show("Could not find specified project");
                MainPage.mainPage.startUp.ReloadProjects();
                return;
            }

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
            SettingsUtil.RemoveProject(project);
            MainPage.mainPage.startUp.ReloadProjects();
        }

        private void OpenFolder_Click(object? sender, EventArgs e) {

            if (!File.Exists(project.filePath)) {
                MessageBox.Show("Could not find specified project");
                MainPage.mainPage.startUp.ReloadProjects();
                return;
            }

            string argument = "/select, \"" + project.filePath + "\"";
            Process.Start("explorer.exe", argument);
        }

        private void RemoveFromList_Click(object? sender, EventArgs e) {

            if (!File.Exists(project.filePath)) {
                MessageBox.Show("Could not find specified project");
                MainPage.mainPage.startUp.ReloadProjects();
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                String.Format("Are you sure you want to remove the project '{0}' from your list.", project.displayName) + Environment.NewLine +
                "The file will remain in its original position and you can always import it again.", "", MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes) {
                /// If dialog result is anything else besides yes, we cancel. Otherwise we pass on.
                return;
            }

            if (MainPage.mainPage.IsProjectLoaded(project)) {

                TabPage tabPage = MainPage.mainPage.GetProjectTabPage(project);

                /// If project loaded, ensure project is saved first.
                if (!FileUtils.AreYouSureSave(new List<TabPage> { tabPage }))
                    return;

                /// Then we unload the project to ensure a safe renaming protocol.
                ProjectPage projectPage = tabPage.Controls[0] as ProjectPage;
                projectPage.UnloadProject(tabPage);
            }

            SettingsUtil.RemoveProject(project);
            MainPage.mainPage.startUp.ReloadProjects();
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

            int width = 320;

            /// Display name of project
            int nHeight = 20;
            Rectangle nameRect = new Rectangle(6, 5, width, nHeight);
            pevent.Graphics.DrawString(
                project.displayName,
                new Font(Font.FontFamily, 11, FontStyle.Bold), 
                new SolidBrush(Color.White), 
                nameRect, 
                new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.NoWrap });
            /// ---

            pevent.Graphics.DrawLine(new Pen(new SolidBrush(Color.DimGray), 1), ClientRectangle.Width - contextWidth, 5, ClientRectangle.Width - contextWidth, ClientRectangle.Height - 6);
            pevent.Graphics.DrawImage(new Bitmap(Resources.TripleDot, drawContext.Width, drawContext.Height), ClientRectangle.Width - drawContext.X, drawContext.Y, drawContext.Width, drawContext.Height);


            /// File path
            int filePathHeight = 20;
            Rectangle filePathRect = new Rectangle(6, ClientRectangle.Height - filePathHeight - 5, width, filePathHeight);
            pevent.Graphics.DrawString(
                project.filePath,
                new Font(Font.FontFamily, 7.5f, FontStyle.Regular), 
                new SolidBrush(Color.LightGray), 
                filePathRect, 
                new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.NoWrap });
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
            */
            string age = getAgoFormat(DateTime.Now - project.lastWriteTime, "written to {0}");

            /// Last time the projects file was written to
            int ageWidth = 200;
            int ageHeight = 20;
            Rectangle ageRect = new Rectangle(ClientRectangle.Width - contextWidth - ageWidth - 7, 5, ageWidth, ageHeight);
            pevent.Graphics.DrawString(age, Font, new SolidBrush(Color.LightGray), ageRect, new StringFormat() { Alignment = StringAlignment.Far });
            /// ---


            string ago = getAgoFormat(DateTime.Now - project.lastAccessTime, "accessed {0}");

            /// Last access time, access is updated by anything, renaming, opening, moving, whenever the file is interacted with.
            int agoWidth = 200;
            int agoHeight = 20;
            Rectangle agoRect = new Rectangle(ClientRectangle.Width - contextWidth - agoWidth - 7, ClientRectangle.Height - agoHeight - 5, agoWidth, agoHeight);
            pevent.Graphics.DrawString(ago, Font, new SolidBrush(Color.DimGray), agoRect, new StringFormat() { Alignment = StringAlignment.Far });
            /// ---      
        }

        private string getAgoFormat(TimeSpan timeDifference, string stringFormat = "") {
            string str;
            if (timeDifference.TotalMinutes < 1) {
                str =  String.Format("{0} seconds ago", (int)timeDifference.TotalSeconds);
            }
            else if (timeDifference.TotalMinutes <= 60) {
                str = String.Format("{0} minutes ago", (int)timeDifference.TotalMinutes);
            }
            else if (timeDifference.TotalHours <= 24) {
                str = String.Format("{0} hours ago", (int)timeDifference.TotalHours);
            }
            else if (timeDifference.TotalDays <= 30) {
                str = String.Format("{0} day{1} ago", (int)timeDifference.TotalDays, timeDifference.TotalDays >= 2 ? "s" : "");
            }
            else if (timeDifference.TotalDays > 36500) {
                return "MORE THEN A CENTURY AGO?! BRO WHAT";
            }
            else {
                str = "over a month ago";
            }

            if (stringFormat.Length > 0) {
                return String.Format(stringFormat, str);
            }
            return str;
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
