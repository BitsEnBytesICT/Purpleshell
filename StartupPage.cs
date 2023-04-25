using ShellHolder.Controls;
using ShellHolder.Util;
using System.Diagnostics;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder
{
    public partial class StartupPage : UserControl
    {
        

        /// Holds all recents projects into memory to be loaded on demand.
        List<Project> recentProjects = new List<Project>();



        public StartupPage() {
            InitializeComponent();

            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;

            /// Tooltip for when hovering over the checkbox at the import button, when unchecked this will allow any file to be imported (txt, mp4, exe, anything!) instead of only to the set Extensions.
            ToolTip yourToolTip = new ToolTip();
            yourToolTip.ToolTipIcon = ToolTipIcon.Info;
            yourToolTip.AutomaticDelay = 0;
            yourToolTip.InitialDelay = 0;
            yourToolTip.ShowAlways = true;
            yourToolTip.SetToolTip(lockExtensionsCheckbox, String.Format("When checked, importing files will only allow \"{0}\" to be imported. {1}Unchecking this will open it to all file types to be imported into raw format.", FileUtils.Extension, Environment.NewLine));

            Trace.WriteLine("Startup Page initialized.");

            recentProjects = FileUtils.RetrieveRecentProjects();
            FillRecentProjectsButtons(recentProjects);
        }

        private void CloseStartupPage_Click(object sender, EventArgs e) {
            ShowPage(false);
        }

        private void NewProjectButton_Click(object sender, EventArgs e) {            
            
            string input = ProjectUtil.GetProjectNameInput();
            if (input.Length <= 0) {
                return;
            }
            
            Project project = new Project() {
                displayName = input,
                creationTime = DateTime.Now,
                lastWriteTime = DateTime.Now,
                sizeBytes = 0,
                filePath = Path.Combine(GetSavedProjectsDirectory(), input + FileUtils.Extension),
            };

            ProjectUtil.LoadProjectFromDirectory(project, true);
        }


        private void ImportButton_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog = new OpenFileDialog() {
                RestoreDirectory = true,
                Multiselect = true,

                CheckFileExists = true,
                CheckPathExists = true,
            };
            /// If user has extensions unlocked, there wont be a filter and the user can select any file, otherwise it is restricted to the FilterExtension.
            if (lockExtensionsCheckbox.Checked)
                openFileDialog.Filter = String.Format("Powershell files ({0})|{0}", FileUtils.FilterExtension);

            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;


            string[] filePaths = openFileDialog.FileNames;
            foreach (string file in filePaths) {
                Trace.WriteLine(file);
            }

            ImportAFile(filePaths, lockExtensionsCheckbox.Checked);
            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }

        private void ImportButton_DragEnter(object sender, DragEventArgs e) {

            /// Validate file that is entering import button boundary.
            if (e.Data == null)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void ImportButton_DragDrop(object sender, DragEventArgs e) {

            if (e.Data == null)
                return;

            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePaths.Length == 0) {
                MessageBox.Show("Something went wrong importing that file.");
                return;
            }

            FileUtils.ImportAFile(filePaths, lockExtensionsCheckbox.Checked);
            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }



        private void OpenButton_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog() {
                InitialDirectory = FileUtils.GetSavedProjectsDirectory(),
                Filter = String.Format("ShellHolder files ({0})|{0}", FileUtils.FilterExtension),
                CheckFileExists = true,
                CheckPathExists = true,
            };

            DialogResult result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            /// If user went outside of projects directory to retrieve file, cancel. Cant do that without importing project first.
            if (Path.GetDirectoryName(openFileDialog.FileName) != FileUtils.GetSavedProjectsDirectory()) {
                MessageBox.Show("Can only retrieve files from original folder." + Environment.NewLine + "If your trying to use files outside of project directory please import them first with the button or manually.");
                return;
            }

            Project project = FileUtils.RetrieveProjectFile(openFileDialog.FileName);
            ProjectUtil.LoadProjectFromDirectory(project, false);
        }


        private void RefreshButton_Click(object sender, EventArgs e) {

            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }


        public void ShowPage(bool show) {
            if (show) {
                FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());

                this.Show();
                this.BringToFront();
            } else {
                this.Hide();
            }
        }


        public void FillRecentProjectsButtons(List<Project> projects) {
            RecentProjectsLayout.Controls.Clear();
            foreach (Project project in projects) {
                RecentProjectsLayout.Controls.Add(new RecentProjectButton(project));
            }
        }
    }
}
