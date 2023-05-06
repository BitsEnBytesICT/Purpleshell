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
        public static string GetProjectNameInput(string filePath, string projectName, string defaultInput = "") {

            string error = "";
            string input = defaultInput;

            while (true) {

                string question = "";
                if (error.Length > 0) { 
                    question += " * " + error + Environment.NewLine + Environment.NewLine;
                }
                question += "What would you like to name your project?";
                input = Interaction.InputBox(question, " ", input);

                /// If input is empty, user either hit cancel or entered empty string. And we return.
                if (input.Length <= 0)
                    return "";

                error = IsValidProjectName(input, filePath, projectName);

                /// If no errors occur, continue.
                if (error.Length <= 0) {
                    break;
                }
            }
            return input;
        }

        public static string GetSaveFilepath() {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog()) {
                folderBrowser.Description = "Please select where you would like to save this project.";
                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath)) {
                    return folderBrowser.SelectedPath;
                }
            }
            return "";
        }

        private static string IsValidProjectName(string input, string filePath, string projectName) {

            if (input.Length == 0) {
                return "Input is empty.";
            }
            else if (input.IndexOfAny(Path.GetInvalidFileNameChars()) > -1) {
                return "Contains an invalid character.";
            }
            else if (File.Exists(Path.Combine(filePath, input + FileUtils.Extension))) {
                return  "Project name already exists.";
            }
            else if (projectName.Length > 0 && input == projectName) {
                return "Project name is the same as before??";
            }
            return "";
        }

        public static void ExceptionMessageBox(Exception ex, string projectName) {
            MessageBox.Show(
                        "An error occured with '" + projectName + "'" + Environment.NewLine + Environment.NewLine +
                        ex.Message + Environment.NewLine +
                        ex.StackTrace + Environment.NewLine);
        }

        public static void ExceptionMessageBox(string message, Exception ex) {
            MessageBox.Show(
                        message + Environment.NewLine + Environment.NewLine +
                        ex.Message + Environment.NewLine +
                        ex.StackTrace + Environment.NewLine);
        }

        public static void LoadProjectFromDirectory(Project project, bool newProject) {

            if (!newProject) {
                if (!File.Exists(project.filePath)) {
                    MessageBox.Show("Could not find specified project");
                    MainPage.mainPage.startUp.ReloadProjects();
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
