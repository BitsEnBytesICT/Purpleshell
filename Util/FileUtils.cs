using ShellHolder.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellHolder.Util
{
    public class FileUtils
    {

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
            string[] filePaths = Directory.GetFiles(FileUtils.GetSavedProjectsDirectory(), "*.ps1");
            foreach (string filePath in filePaths) {

                Trace.WriteLine("Loading file: " + filePath);

                Project project = new Project();


                /// Retrieves all the file info and fills it into project.
                FileInfo fileInfo = new FileInfo(filePath);

                project.displayName = Path.GetFileNameWithoutExtension(fileInfo.Name);
                project.creationTime = fileInfo.CreationTime;
                project.lastWriteTime = fileInfo.LastWriteTime;
                project.sizeBytes = fileInfo.Length;
                project.filePath = filePath;

                recentProjects.Add(project);
            }

            /// Sort all projects by most recent date.
            return recentProjects.OrderBy(p => p.lastWriteTime).ToList();
        }
    }
}
