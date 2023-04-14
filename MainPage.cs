using Microsoft.VisualBasic;
using ShellHolder.Util;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder
{
    public partial class MainPage : Form
    {

        /// Holds the main pointer to the startup page to be called when needed.
        public StartupPage startUp = new StartupPage();

        /// The background worker for processing scripts.
        public BackgroundWorker worker = new BackgroundWorker();


        /// Public pointer to reference mainPage thread.
        public static MainPage mainPage;




        /// File variables 
        public Project? currentProject = null;
        private bool isSaved = true;



        public MainPage() {
            InitializeComponent();
            mainPage = this;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);


            /// Initialize backroundworker
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;



            /// Setup quick button
            startScriptButton.Enabled = true;
            stopScriptButton.Enabled = false;

            SaveButtonEnable(false);



            /// Setup textBox
            textBox.TextChanged += TextBox_TextChanged;



            /// Initializes startup page.
            this.Controls.Add(startUp);
            startUp.ShowPage(true);
        }

        private void Form_KeyDown(object? sender, KeyEventArgs e) {

            /// Ctrl-S Save
            if (e.Control && e.KeyCode == Keys.S) {
                e.SuppressKeyPress = true;
                if (!isSaved)
                    SaveFile();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {

            if (!AreYouSureSave()) {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        private void TextBox_TextChanged(object? sender, FastColoredTextBoxNS.TextChangedEventArgs e) {

            if (currentProject == null) {
                return;
            }

            SaveButtonEnable(true);
        }

        private void SaveButtonEnable(bool enable) {
            saveButton.Enabled = enable;
            saveButton.NotificationIcon = enable;
            isSaved = !enable;
        }

        /*private void StartupPageShow() {
            startUp.Show();
            startUp.BringToFront();
        }*/


        /// Returns true if code can continue.
        public bool AreYouSureSave() {
            if (!isSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes to your project?", "", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) {
                    /// Save currently loaded file.
                    SaveFile();
                }
                else if (dialogResult == DialogResult.No) {
                    /// Do nothing, dont save file just continue.
                }
                else {
                    /// Do not continue.
                    return false;
                }
            }
            return true;
        }

        public void UnloadCurrentProject() {
            if (currentProject == null)
                return;

            currentProject.fileStream.Close();
            currentProject = null;
        }


        public void LoadProjectFromDirectory(Project project, bool newProject) {


            if (!AreYouSureSave())
                return;


            if (!newProject) {
                if (!File.Exists(project.filePath)) {
                    MessageBox.Show("Could not find specified project");
                    return;
                }
            }

            startUp.ShowPage(false);



            /// Finish up old project
            UnloadCurrentProject();




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
                
                textBox.Text = contents;

                currentProject = project;
                currentProject.fileStream = stream;

                SaveButtonEnable(false);
            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
                Trace.WriteLine(e.StackTrace);
                return;
            }
            
        }



        ///
        /// Toolstrip Items
        ///

        private void openStartupItem_Click(object sender, EventArgs e) {
            startUp.ShowPage(true);
        }

        ///
        /// Toolstrip Items
        /// 



        /// 
        /// Quickbutton Menu Items
        ///

        private void saveButton_Click(object sender, EventArgs e) {

            if (currentProject == null)
                return;

            SaveFile();
        }

        private bool SaveFile() {

            try {
                if (currentProject == null)
                    return false;

                currentProject.fileStream.SetLength(0);
                using (StreamWriter sr = new StreamWriter(currentProject.fileStream, leaveOpen: true)) {
                    sr.Write(textBox.Text);
                    sr.Close();
                }
            }
            catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, currentProject.displayName);
                return false;
            }

            SaveButtonEnable(false);
            return true;
        }

        /// 
        /// Quickbutton Menu Items
        ///

        private void startScript_Click(object sender, EventArgs e) {

            if (currentProject == null)
                return;

            if (worker.IsBusy)
                return;



            string script = textBox.Text;

            consoleBox.Text = "";

            startScriptButton.Enabled = false;
            stopScriptButton.Enabled = true;

            worker.RunWorkerAsync(script);
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e) {

            if (e.Argument == null || sender == null) {
                return;
            }


            string script = e.Argument.ToString();
            BackgroundWorker worker = sender as BackgroundWorker;

            PowerShell runspace = PowerShell.Create();
            runspace.AddScript(script);

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += (sender, e) => {
                PSObject newRecord = ((PSDataCollection<PSObject>)sender)[e.Index];
                string recordString = newRecord.ToString();
                worker.ReportProgress(0, recordString);
            };

            var res = runspace.BeginInvoke<PSObject, PSObject>(null, output);
            while (runspace.InvocationStateInfo.State == PSInvocationState.Running) {
                if (worker.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e) {

            string output = e.UserState.ToString();

            Trace.WriteLine(output);

            if (output.Length > 0) {
                consoleBox.AppendText(e.UserState.ToString() + Environment.NewLine);
            }
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled == true) {
                consoleBox.Text += "Canceled!";
            }
            else if (!(e.Error == null)) {
                consoleBox.Text += ("Error: " + e.Error.StackTrace);
            }
            else {
                consoleBox.Text += "Done!";
            }

            startScriptButton.Enabled = true;
            stopScriptButton.Enabled = false;
        }

        private void stopScriptButton_Click(object sender, EventArgs e) {

            if (currentProject == null)
                return;

            if (!worker.IsBusy) {
                return;
            }

            worker.CancelAsync();
        }
    }
}