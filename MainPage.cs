using ShellHolder.Properties;
using ShellHolder.Util;
using System.Diagnostics;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder
{
    public partial class MainPage : Form
    {

        /// Holds the main pointer to the startup page to be called when needed.
        public StartupPage startUp = new StartupPage();


        /// Public pointer to reference mainPage thread.
        public static MainPage mainPage;


        public MainPage() {
            InitializeComponent();
            mainPage = this;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);


            /// Initializes startup page.
            this.Controls.Add(startUp);
            startUp.ShowPage(true);
        }

        public TabControl GetProjectsControl() {
            return projectControl;
        }

        private void Form_KeyDown(object? sender, KeyEventArgs e) {

            /// Ctrl-S Save
            if (e.Control && e.KeyCode == Keys.S) {
                e.SuppressKeyPress = true;

                if (projectControl.TabCount == 0 || projectControl.SelectedIndex < 0)
                    return;

                TabPage tab = (TabPage)projectControl.Controls[projectControl.SelectedIndex];
                ProjectPage page = (ProjectPage)tab.Controls[0];
                if (!page.isSaved) {
                    page.SaveFile();
                }
            } /*else if (e.Control && e.KeyCode == Keys.Q) {
                this.Controls.Add(startUp);
                startUp.ShowPage(true);
                Trace.WriteLine("Calelsdfdsf");
            }*/
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {

            List<TabPage> tabPages = new List<TabPage>();
            foreach (TabPage page in projectControl.TabPages) {
                tabPages.Add(page);
            }

            if (!FileUtils.AreYouSureSave(tabPages)) {
                e.Cancel = true;
            }

            if (!e.Cancel) {
                foreach (TabPage tabPage in projectControl.TabPages) {
                    ProjectPage projectPage = tabPage.Controls[0] as ProjectPage;
                    projectPage.UnloadProject(tabPage, true);
                    //Trace.WriteLine("fuck it.");
                }
            }

            base.OnFormClosing(e);
        }

        public bool IsProjectLoaded(Project project) {
            foreach (TabPage page in projectControl.Controls) {
                if (page.Text == project.displayName) {
                    return true;
                }
            }
            return false;
        }

        public TabPage GetProjectTabPage(Project project) {
            foreach (TabPage page in projectControl.Controls) {
                if (page.Text == project.displayName) {
                    return page;
                }
            }
            return null;
        }

        public void LoadProjectFromDirectory(Project project, bool newProject) {

            if (!newProject) {
                if (!File.Exists(project.filePath)) {
                    MessageBox.Show("Could not find specified project");
                    return;
                }

                if (IsProjectLoaded(project)) {

                    Trace.WriteLine("Project is already opened in the editor.");
                    Trace.WriteLine(project.displayName);
                    projectControl.SelectTab(project.displayName);
                    

                    startUp.ShowPage(false);
                    return;
                }                        
            }

            startUp.ShowPage(false);


            /// Setup new project
            try {
                FileStream stream = File.Open(project.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                string contents = "";

                if (!newProject) {
                    using (StreamReader sr = new StreamReader(stream, leaveOpen: true)) {
                        contents = sr.ReadToEnd();
                        sr.Close();
                    }
                }

                project.fileStream = stream;
                ProjectPage projectPage = new ProjectPage(project);

                projectPage.SetTextBox(contents);
                projectPage.SaveButtonEnable(false);

                TabPage tab = new TabPage();
                tab.Controls.Add(projectPage);
                tab.Name = project.displayName;
                tab.Text = project.displayName;

                projectControl.Controls.Add(tab);
                projectControl.SelectedTab = tab;
            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
                Trace.WriteLine(e.StackTrace);
                return;
            }
        }



        ///
        /// Toolstrip Items
        ///

        private void openStartupItem_Click(object sender, EventArgs e) {
            startUp.ShowPage(true);
        }

        ///
        /// Toolstrip Items
        ///



        Point imageLocation = new Point(22, 6);
        Point imageHitArea = new Point(22, 6);

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e) {

            //Trace.WriteLine("JHSDFJHDSHBFSHBJFSHJBFHBJSDHJFSDJHFHBSJFHSDHJF" + new Random().Next());

            Trace.WriteLine(this.projectControl.TabPages[e.Index].Text + " - " + e.State.ToString());

            /*Image img;
            if (e.Index == this.projectControl.TabCount - 1) {
                img = new Bitmap(AddImage);
                projectControl.Padding = new Point(20, 4);
            }
            else {
                img = new Bitmap(CloseImage);
            }*/

            Brush tabColor;
            if (e.State == DrawItemState.Selected) {
                tabColor = new SolidBrush(Color.FromArgb(200, 200, 200));
            } else {
                tabColor = new SolidBrush(Color.FromArgb(130, 130, 130));
            }

            Rectangle r = e.Bounds;
            r = this.projectControl.GetTabRect(e.Index);

            e.Graphics.FillRectangle(tabColor, r);

            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);

            string title = projectControl.TabPages[e.Index].Text;

            e.Graphics.DrawString(title, Font, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(new Bitmap(Resources.X, 12, 12), new Point(r.X + (projectControl.GetTabRect(e.Index).Width - imageLocation.X), imageLocation.Y));
        }

        private void ProjectControl_MouseClick(object sender, MouseEventArgs e) {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = projectControl.GetTabRect(tabControl.SelectedIndex).Width - (imageHitArea.X);
            Rectangle r = projectControl.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, imageHitArea.Y);
            r.Width = 12;
            r.Height = 12;

            if (r.Contains(p)) {
                TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];

                if (!FileUtils.AreYouSureSave(new List<TabPage> { tabPage })) {
                    return;
                }

                ProjectPage projectPage = tabPage.Controls[0] as ProjectPage;
                projectPage.UnloadProject(tabPage);

                if (tabControl.TabPages.Count <= 0) {
                    startUp.ShowPage(true);
                }
            }
            /*if (projectControl.SelectedIndex == this.projectControl.TabCount - 1) {
                TabPage tab = new TabPage();
                tab.Text = "";
                projectControl.Controls.Add(tab);
                this.projectControl.TabPages[this.projectControl.TabCount - 2].Text =
                    "tabPage" + this.projectControl.TabCount.ToString();
            }
            else {
                if (r.Contains(p)) {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
                }
            }*/
        }
    }
}