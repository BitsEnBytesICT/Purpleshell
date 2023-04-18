using System.Diagnostics;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder.Util
{
    public class FileUtils
    {
        public static readonly string FilterExtension = "*.ps1";
        public static readonly string Extension = ".ps1";

        public class Project
        {
            public string displayName { get; set; }
            public string filePath { get; set; }
            public long sizeBytes { get; set; }
            public DateTime lastWriteTime { get; set; }
            public DateTime creationTime { get; set; }

            /// Data to use in mainpage.
            public FileStream fileStream { get; set; }
        }


        /// Retrieve project directory equal across all places.
        public static string GetSavedProjectsDirectory() {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Projects");
            try {
                /// If saved projects directory doesnt exist yet, create it.
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                    Trace.WriteLine("Saved Projects directory did not exist yet. Made it now :)");
                }
            } catch (Exception ex) {
                /// If exception occurs, bad.
                Trace.WriteLine(ex.StackTrace);
            }
            return path;
        }


        public static List<Project> RetrieveRecentProjects() {

            List<Project> recentProjects = new List<Project>();

            /// Retrieve all powershell files saved in the projects folder.
            string[] filePaths = Directory.GetFiles(FileUtils.GetSavedProjectsDirectory(), FileUtils.FilterExtension);
            foreach (string filePath in filePaths) {

                /// Retrieves all the file info and fills it into project.
                recentProjects.Add(RetrieveProjectFile(filePath));
            }

            /// Sort all projects by most recent date.
            return recentProjects.OrderBy(p => p.lastWriteTime).ToList();
        }

        public static Project RetrieveProjectFile(string filePath) {

            Project project = new Project();
            FileInfo fileInfo = new FileInfo(filePath);

            Trace.WriteLine("Loading file: " + filePath);

            project.displayName = Path.GetFileNameWithoutExtension(fileInfo.Name);
            project.creationTime = fileInfo.CreationTime;
            project.lastWriteTime = fileInfo.LastWriteTime;
            project.sizeBytes = fileInfo.Length;
            project.filePath = filePath;

            return project;
        }

        public static void ImportAFile(string[] filePaths, bool lockExtensions) {

            if (lockExtensions) {
                foreach (string filename in filePaths) {
                    if (Path.GetExtension(filename) != FileUtils.Extension) {
                        MessageBox.Show(String.Format("One or more of your files is not a valid powershell file ({0})", FileUtils.Extension));
                        return;
                    }
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

                }
                catch (Exception e) {
                    MessageBox.Show(
                        "An error occured while importing '" + Path.GetFileName(file) + "'" + Environment.NewLine + Environment.NewLine +
                        e.Message + Environment.NewLine +
                        e.StackTrace + Environment.NewLine);
                }
            }
            MessageBox.Show(String.Format(
                    "Successfully imported {0}/{1} projects.", filesImported, filePaths.Length) +
                    (filesRenamed > 0 ? Environment.NewLine + String.Format("Had to rename {0} files to avoid duplication.", filesRenamed) : ""));
        }



        public static bool SaveFile(ProjectPage projectPage, string text) {

            Project project = projectPage.project;

            try {
                if (project == null)
                    return false;

                project.fileStream.SetLength(0);
                using (StreamWriter sr = new StreamWriter(project.fileStream, leaveOpen: true)) {
                    sr.Write(text);
                    sr.Close();
                }
            }
            catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
                return false;
            }

            projectPage.SaveButtonEnable(false);
            return true;
        }

        /// Returns true if able to continue process after, else cancel everything after.
        public static bool AreYouSureSave(List<TabPage> tabPages) {

            List<ProjectPage> projectPages = new List<ProjectPage>();
            foreach (TabPage tabPage in tabPages) {
                ProjectPage page = tabPage.Controls[0] as ProjectPage;
                if (!page.isSaved)
                    projectPages.Add(page);
            }

            /// If all projects are saved just continue.
            if (projectPages.Count <= 0)
                return true;

            /// If only one project needs to be passed thru run the normal prompt.
            if (projectPages.Count == 1) {

                ProjectPage project = projectPages[0];

                DialogResult dialogResult = MessageBox.Show(String.Format("Save changes to project '{0}' ?", project.project.displayName), "", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) {
                    /// Save currently loaded file.
                    project.SaveFile();
                    return true;
                }
                else if (dialogResult == DialogResult.No) {
                    /// Do nothing, dont save file just continue.
                    return true;
                }
                else {
                    /// Do not continue.
                }

            } /// if multiple projects arent saved run modified prompt.
            else {
                string txt = "Save changes to all projects below?" + Environment.NewLine;
                foreach (ProjectPage page in projectPages) {
                    txt += Environment.NewLine + "* " + page.project.displayName;
                }

                DialogResult dialogResult = MessageBox.Show(txt, "", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) {
                    /// Save currently loaded file.
                    foreach (ProjectPage page in projectPages) {
                        if (!page.isSaved)
                            page.SaveFile();
                    }
                    return true;
                }
                else if (dialogResult == DialogResult.No) {
                    /// Do nothing, dont save file just continue.
                    return true;
                }
                else {
                    /// Do not continue.
                }
            }
            return false;
        }
    }
}
