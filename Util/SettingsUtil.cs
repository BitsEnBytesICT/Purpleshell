using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder.Util
{
    public class SettingsUtil
    {
        private static List<Project> projects = new List<Project>();
        private static bool sytaxHighlightEnabled = false;

        private static string settingsFile = FileUtils.GetBaseDirectory() + "settings.txt";

        public static List<Project> GetProjects() {

            Load();
            return projects;
        }

        public static void AddProject(Project project) {
            projects.Add(project);
            SettingsUtil.Save();
        }

        public static void RemoveProject(Project project) {
            projects.Remove(project);
            SettingsUtil.Save();
        }

        public static void Load() {

           try {
                bool saveAgain = false;
           
                sytaxHighlightEnabled = Purpleshell.Properties.Settings.Default.SyntaxHighlight;
                    
                projects.Clear();
                foreach (string path in Purpleshell.Properties.Settings.Default.Projects) {
                    if (File.Exists(path)) {
                        projects.Add(FileUtils.RetrieveProjectFile(path));
                    }
                    else
                        saveAgain = true;
                }

                if (saveAgain)
                    Save();

            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox("A problem occured loading the config file.", ex);
            }
        }

        public static void Save() {

            try {

                Purpleshell.Properties.Settings.Default.SyntaxHighlight = sytaxHighlightEnabled;

                StringCollection paths = new StringCollection();
                foreach (Project project in projects) {
                    paths.Add(project.filePath);
                }
                Purpleshell.Properties.Settings.Default.Projects = paths;

                Purpleshell.Properties.Settings.Default.Save();

            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox("A problem occured saving the config file.", ex);
            }
        }

        public static bool IsSyntaxHighlightEnabled() {
            return sytaxHighlightEnabled;
        }

        public static void SetSyntaxHighlight(bool enabled) {
            sytaxHighlightEnabled = enabled;
            Save();
        }
    }
}
