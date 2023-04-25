using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShellHolder.Util.FileUtils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShellHolder.Util
{
    public class ProjectUtil
    {
        public static string ProjectName = "ShellHolder";


        /// Will return empty string in case of cancel. Otherwise checked and correct name has been verified.
        public static string GetProjectNameInput() {

            List<string> errors = new List<string>();
            string input;

            while (true) {

                string question = "";
                foreach (string error in errors) {
                    question += " * " + error + Environment.NewLine;
                }
                question += Environment.NewLine + "What would you like to name your project?";
                input = Interaction.InputBox(question, " ", "");


                /// If input is empty, user either hit cancel or entered empty string. And we return.
                if (input.Length == 0)
                    return "";


                errors = IsValidProjectName(input);


                /// If no errors occur, continue.
                if (errors.Count == 0) {
                    break;
                }
            }
            return input;
        }

        private static List<string> IsValidProjectName(string input) {
            List<string> errors = new List<String>();

            if (input.Length == 0) {
                errors.Add("Input is empty.");
            }
            else if (input.IndexOfAny(Path.GetInvalidFileNameChars()) > -1) {
                errors.Add("Contains an invalid character.");
            }
            else if (File.Exists(Path.Combine(FileUtils.GetSavedProjectsDirectory(), input + FileUtils.Extension))) {
                errors.Add("Project name already exists.");
            }
            return errors;
        }

        public static void ExceptionMessageBox(Exception ex, string projectName) {
            MessageBox.Show(
                        "An error occured with '" + projectName + "'" + Environment.NewLine + Environment.NewLine +
                        ex.Message + Environment.NewLine +
                        ex.StackTrace + Environment.NewLine);
        }

        public static void LoadProjectFromDirectory(Project project, bool newProject) {

            if (!newProject) {
                if (!File.Exists(project.filePath)) {
                    MessageBox.Show("Could not find specified project");
                    return;
                }

                if (MainPage.mainPage.IsProjectLoaded(project)) {

                    Trace.WriteLine("Project is already opened in the editor.");
                    Trace.WriteLine(project.displayName);
                    MainPage.mainPage.SelectTab(project);


                    MainPage.mainPage.startUp.ShowPage(false);
                    return;
                }
            }

            MainPage.mainPage.startUp.ShowPage(false);


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

                MainPage.mainPage.AddTab(tab, true);
            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
                Trace.WriteLine(e.StackTrace);
                return;
            }
        }
    }
}
