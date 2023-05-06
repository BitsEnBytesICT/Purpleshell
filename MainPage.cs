using Purpleshell.Properties;
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

        public void AddTab (TabPage tabPage, bool selectTab = false) {
            projectControl.Controls.Add(tabPage);
            if (selectTab)
                projectControl.SelectTab(tabPage);
        }

        public void SelectTab(Project project) {
            projectControl.SelectTab(project.displayName);
        }

        /// Moved load project funciton to ProjectUtil class
        /*public void LoadProjectFromDirectory(Project project, bool newProject) {

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
        }*/



        ///
        /// Toolstrip Items
        ///

        private void openStartupItem_Click(object sender, EventArgs e) {
            startUp.ShowPage(true);
        }

        ///
        /// Toolstrip Items
        ///

        Rectangle imageRec = new Rectangle(18, 6, 12, 12);

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e) {

            //Trace.WriteLine("JHSDFJHDSHBFSHBJFSHJBFHBJSDHJFSDJHFHBSJFHSDHJF" + new Random().Next());

            Trace.WriteLine(this.projectControl.TabPages[e.Index].Text + " - " + e.State.ToString());

            Brush tabColor;
            if (e.State == DrawItemState.Selected) {
                tabColor = new SolidBrush(Color.FromArgb(200, 200, 200));
            } else {
                tabColor = new SolidBrush(Color.FromArgb(130, 130, 130));
            }

            Rectangle r = projectControl.GetTabRect(e.Index);

            e.Graphics.FillRectangle(tabColor, r);


            Brush TitleBrush = new SolidBrush(Color.Black);
            string title = projectControl.TabPages[e.Index].Text;

            Rectangle stringRec = new Rectangle(r.X, r.Y + 2, r.Width - imageRec.X, r.Height);
            e.Graphics.DrawString(title, Font, TitleBrush, stringRec, new StringFormat() { Trimming = StringTrimming.EllipsisCharacter, Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.NoWrap });

            e.Graphics.DrawImage(new Bitmap(Resources.X, imageRec.Width, imageRec.Height), r.X + (r.Width - imageRec.X), imageRec.Y, imageRec.Width, imageRec.Height);
        }

        private void ProjectControl_MouseClick(object sender, MouseEventArgs e) {
            TabControl tabControl = (TabControl)sender;
            Point clickLocation = e.Location;
            int tabWidth = projectControl.GetTabRect(tabControl.SelectedIndex).Width - (imageRec.X);
            Rectangle r = projectControl.GetTabRect(tabControl.SelectedIndex);
            r.Offset(tabWidth, imageRec.Y);
            r.Width = imageRec.Width;
            r.Height = imageRec.Height;

            if (r.Contains(clickLocation)) {
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
        }
    }
}