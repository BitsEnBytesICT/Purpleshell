using Microsoft.VisualBasic;
using ShellHolder.Controls;
using ShellHolder.Util;
using System.Diagnostics;
using System.Windows.Forms;
using static ShellHolder.Util.FileUtils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShellHolder
{
    public partial class StartupPage : UserControl
    {
        

        /// Holds all recents projects into memory to be loaded on demand.
        List<Project> recentProjects = new List<Project>();



        public StartupPage() {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            Trace.WriteLine("Startup Page initialized.");

            recentProjects = FileUtils.RetrieveRecentProjects();
            FillRecentProjectsButtons(recentProjects);
        }

        private void StartupPage_Load(object sender, EventArgs e) {

            Trace.WriteLine("Startup Page loaded.");
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
                filePath = Path.Combine(GetSavedProjectsDirectory(), input + ".ps1"),
            };

            MainPage.mainPage.LoadProjectFromDirectory(project, true);
            //MessageBox.Show("Created project with name: " + input);
        }


        private void ImportButton_Click(object sender, EventArgs e) {

            Trace.WriteLine("CLICKED THE IMPORT BUTTOn");

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Powershell files (*.ps1)|*.ps1";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {

                    string[] filePaths = openFileDialog.FileNames;
                    foreach (string file in filePaths) {
                        Trace.WriteLine(file);
                    }

                    ImportAFile(filePaths);
                }
            }
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

            FileUtils.ImportAFile(filePaths);

            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }


        private void RefreshButton_Click(object sender, EventArgs e) {

            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }


        public void ShowPage(bool show) {
            if (show) {
                this.Show();
                this.BringToFront();

                recentProjects = FileUtils.RetrieveRecentProjects();
                FillRecentProjectsButtons(recentProjects);
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
