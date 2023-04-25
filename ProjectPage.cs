using FastColoredTextBoxNS;
using ShellHolder.Util;
using System.ComponentModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Text.RegularExpressions;
using static ShellHolder.Util.FileUtils;

namespace ShellHolder
{
    public partial class ProjectPage : UserControl
    {

        public Project project;


        /// The background worker for processing scripts.
        public BackgroundWorker worker = new BackgroundWorker();

        public bool isSaved = true;

        public ProjectPage(Project projectRef) {
            InitializeComponent();


            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Dock = DockStyle.Fill;


            project = projectRef;
            
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
        }

        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);

        private void TextBox_TextChanged(object? sender, FastColoredTextBoxNS.TextChangedEventArgs e) {


            e.ChangedRange.ClearStyle(GreenStyle);


            /// Comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);


            /// Folding markers
            e.ChangedRange.ClearFoldingMarkers();

            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");

            if (project == null) {
                return;
            }

            SaveButtonEnable(true);
        }

        public void SetTextBox(string text) {
            textBox.Text = text;
        }

        public void SaveFile() {
            FileUtils.SaveFile(this, textBox.Text);
        }

        /// 
        /// Quickbutton Menu Items
        ///

        private void saveButton_Click(object sender, EventArgs e) {

            if (project == null)
                return;

            SaveFile();
        }

        private void startScript_Click(object sender, EventArgs e) {

            if (project == null)
                return;

            if (worker.IsBusy)
                return;


            string script = textBox.Text;

            consoleBox.Text = "";
            ScriptButtonRunning(true);

            worker.RunWorkerAsync(script);
        }

        private void stopScriptButton_Click(object sender, EventArgs e) {

            if (project == null)
                return;

            if (!worker.IsBusy)
                return;
            
            worker.CancelAsync();
        }

        /// 
        /// Quickbutton Menu Items
        ///

        private void Worker_DoWork(object? sender, DoWorkEventArgs e) {

            if (e.Argument == null || sender == null) {
                return;
            }


            string script = e.Argument.ToString();
            BackgroundWorker worker = sender as BackgroundWorker;

            /// Create powershell runspace, to run the script in its own enviroment.
            PowerShell runspace = PowerShell.Create();
            runspace.AddScript(script);

            /// Make an console output event handler that handles its output back on the main thread via the reportprogress backgroundworker.
            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += (sender, e) => {
                if (sender == null || worker == null) return;

                PSObject newRecord = ((PSDataCollection<PSObject>)sender)[e.Index];
                string recordString = newRecord.ToString();
                worker.ReportProgress(200, recordString);
            };

            /// Start the runspace and keep running until end is declared.
            runspace.BeginInvoke<PSObject, PSObject>(null, output);
            while (runspace.InvocationStateInfo.State == PSInvocationState.Running) {

                if (worker == null) return;
                
                /// If any errors occur during runtime of runspace, report the error and stop outside shell (backgroundworker) by throwing an exception which will be caught outside of the thread.
                if (runspace.HadErrors) {
                    worker.ReportProgress(400, runspace.Streams.Error);
                    throw new InvalidOperationException();
                }

                /// If the user requested to cancel the worker, the do this immediatly. This will destroy the runspace and put the worker in an non use state.
                if (worker.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e) {

            string output = e.UserState.ToString();

            if (output.Length <= 0) 
                return;

            /// If report is positive (200), log to console default.
            if (e.ProgressPercentage == 200) {
                AddToConsole(e.UserState.ToString(), Color.White);
            }
            /// If console is error handling (400) handle all the errors at once.
            else if (e.ProgressPercentage == 400) {
                PSDataCollection<ErrorRecord> errorStreams = e.UserState as PSDataCollection<ErrorRecord>;
                foreach (ErrorRecord record in errorStreams) {
                    string text = record.Exception.Message;
                    AddToConsole(text, Color.White);
                }
            }
        }

        private void AddToConsole(string text, Color color = new Color()) {

            consoleBox.SuspendLayout();

            if (!color.IsEmpty)
                consoleBox.SelectionColor = color;

            consoleBox.AppendText(text + Environment.NewLine);
            consoleBox.SelectionColor = consoleBox.ForeColor;
            consoleBox.ScrollToCaret();

            consoleBox.ResumeLayout();
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                AddToConsole(Environment.NewLine + "Error occurred!", Color.Red);
            }
            else if (e.Cancelled) {
                AddToConsole(Environment.NewLine + "Cancelled!", Color.Orange);
            }
            else
                AddToConsole(Environment.NewLine + "Success!", Color.LimeGreen);

            ScriptButtonRunning(false);
        }

        public void ScriptButtonRunning(bool enable) {
            startScriptButton.Enabled = !enable;
            stopScriptButton.Enabled = enable;
        }

        public void SaveButtonEnable(bool enable) {
            saveButton.Enabled = enable;
            saveButton.NotificationIcon = enable;
            isSaved = !enable;
        }

        public void UnloadProject(TabPage page, bool formClosing = false) {

            try {
                /// Close all pipelines and empty resources.
                project.fileStream.Close();
                worker.Dispose();

                /// If user isnt closing the entire application, make sure to remove the tab as well.
                if (!formClosing) {
                    MainPage.mainPage.GetProjectsControl().TabPages.Remove(page);
                }

                Trace.WriteLine("Succesfully closed project " + project.displayName);
            } catch (Exception ex) {
                ProjectUtil.ExceptionMessageBox(ex, project.displayName);
            }
        }

        private void homeButton_Click(object sender, EventArgs e) {
            MainPage.mainPage.startUp.ShowPage(true);
        }
    }
}
