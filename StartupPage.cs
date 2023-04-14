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

            ImportAFile(filePaths);
        }

        private void ImportAFile(string[] filePaths) {
            foreach (string filename in filePaths) {
                if (Path.GetExtension(filename) != FileUtils.Extension) {
                    MessageBox.Show("One or more of your files is not a valid powershell file (.ps1)");
                    return;
                }
            }

            int filesImported = 0; /// Counts the amount of files that were correctly imported.
            int filesRenamed = 0; /// Counts the amount of files that had to be renamed because of duplication problems.
            foreach (string file in filePaths) {
                try {

                    string content = "";

                    /// Open and read imported file, copy all of its content to string.
                    FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
                    using (StreamReader reader = new StreamReader(fileStream)) {
                        content = reader.ReadToEnd();
                        reader.Close();
                    }
                    
                    /// Generate a new filename for the upcoming project, insure no duplicate names by counting upwards.
                    string filename = Path.GetFileNameWithoutExtension(file);
                    string filePath = Path.Combine(FileUtils.GetSavedProjectsDirectory(), Path.GetFileName(filename) + FileUtils.Extension);
                    int count = 0;
                    while (File.Exists(filePath)) {
                        count++;
                        filePath = Path.Combine(FileUtils.GetSavedProjectsDirectory(), (Path.GetFileNameWithoutExtension(filename) + count + FileUtils.Extension));
                    }

                    /// Create new file at designated projects folder and write imported file content to it.
                    FileStream newFileStream = File.Create(filePath);
                    using (StreamWriter writer = new StreamWriter(newFileStream)) {
                        writer.Write(content);
                        writer.Close();
                    }

                    /// Stat tracking at last to ensure correct.
                    if (count > 0)
                        filesRenamed++;
                    filesImported++;

                } catch (Exception e) {
                    MessageBox.Show(
                        "An error occured while importing '" + Path.GetFileName(file) + "'" + Environment.NewLine + Environment.NewLine +
                        e.Message + Environment.NewLine +
                        e.StackTrace + Environment.NewLine);
                }
            }


            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());

            MessageBox.Show(String.Format(
                    "Successfully imported {0}/{1} projects.", filesImported, filePaths.Length) +
                    (filesRenamed > 0 ? Environment.NewLine + String.Format("Had to rename {0} files to avoid duplication.", filesRenamed) : ""));
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

        private void RefreshButton_Click(object sender, EventArgs e) {

            FillRecentProjectsButtons(FileUtils.RetrieveRecentProjects());
        }
    }
}
