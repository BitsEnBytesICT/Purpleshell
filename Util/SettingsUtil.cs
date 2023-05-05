using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

                if (!File.Exists(settingsFile))
                    return;

                using (StreamReader reader = new StreamReader(settingsFile)) {

                    string str = reader.ReadToEnd();
                    JObject obj = JObject.Parse(str);
                    JArray projArray = (JArray)obj["projects"];

                    sytaxHighlightEnabled = (bool)obj.GetValue("syntaxHighlight");

                    projects.Clear();
                    foreach (JValue proj in projArray) {
                        string filePath = proj.ToString();

                        if (File.Exists(filePath)) {
                            projects.Add(FileUtils.RetrieveProjectFile(filePath));
                        }
                        else
                            saveAgain = true;
                    }
                    reader.Close();
                    reader.Dispose();
                }


                if (saveAgain)
                    Save();

            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, "");
            }
        }

        public static void Save() {

            try {

                JArray projectArray = new JArray();

                foreach (Project project in projects) {
                    projectArray.Add(project.filePath);
                }

                JObject obj = new JObject {
                        {
                            "projects", projectArray
                        },
                        {
                            "syntaxHighlight", sytaxHighlightEnabled
                        }
                    };

                using (FileStream fileStream = File.Open(settingsFile, FileMode.Create, FileAccess.Write)) {
                    using (StreamWriter writer = new StreamWriter(fileStream)) {

                        //Trace.WriteLine("obj: " + obj.ToString());
                        writer.Write(obj.ToString());
                        writer.Close();
                    }
                }

            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, "");
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
