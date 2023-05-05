using FastColoredTextBoxNS;
using ShellHolder.Properties;
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


            /// Syntax button
            SetSyntaxButtonImage(SettingsUtil.IsSyntaxHighlightEnabled());



            /// Setup textBox
            textBox.TextChanged += TextBox_TextChanged;

            textBox.Language = Language.Custom;
            textBox.AutoIndent = true;
            textBox.LeftBracket = '(';
            textBox.RightBracket = ')';
            textBox.LeftBracket2 = '{';
            textBox.RightBracket2 = '}';
            textBox.SelectionColor = Color.FromArgb(50, 0, 0, 255);
            textBox.CaretColor = Color.FromArgb(255, 255, 255, 255);
        }

        //Style CommentStyle = new TextStyle(new SolidBrush(Color.FromArgb(160, 160, 160)), null, FontStyle.Italic);
        //Style StringStyle = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);

        // Define styles for syntax highlighting
        Style commentStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Italic);
        Style stringStyle = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);
        Style variableStyle = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
        Style variableExpressionStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        Style cmdletStyle = new TextStyle(Brushes.LightGray, null, FontStyle.Regular);
        Style parameterStyle = new TextStyle(Brushes.DarkCyan, null, FontStyle.Regular);
        Style typeAcceleratorStyle = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        Style typeNameStyle = new TextStyle(Brushes.DeepSkyBlue, null, FontStyle.Regular);
        Style attributeStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);
        Style cmdletPlaceholderStyle = new TextStyle(Brushes.BlueViolet, null, FontStyle.Regular);
        Style scriptBlockStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        Style multilineStringStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        Style hereStringStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);

        // Define regex patterns for syntax highlighting
        Regex commentPattern = new Regex(@"#.*$", RegexOptions.Multiline);
        Regex singleQuotedStringPattern = new Regex(@"'([^'\\]*(?:\\.[^'\\]*)*)'", RegexOptions.Multiline);
        Regex doubleQuotedStringPattern = new Regex("\"([^\"\\\\]*(?:\\\\.[^\"\\\\]*)*)\"", RegexOptions.Multiline);
        Regex variablePattern = new Regex(@"(?<!`)\$(\w+|(?<brace>{)\w+(?<end-brace>})|\?)", RegexOptions.Multiline);
        Regex variableExpressionPattern = new Regex(@"\$\(([^)]*)\)", RegexOptions.Multiline);
        Regex cmdletPattern = new Regex(@"\b(Get|Set|New|Add|Remove|Clear|Update|Invoke|Export|Import|Convert|Compare|Format|Measure|Out|Select|Sort|Group|Join|Where|ForEach|Switch|Write)\-[A-Za-z]+", RegexOptions.IgnoreCase);
        Regex parameterPattern = new Regex(@"-(\w+)", RegexOptions.Multiline);
        Regex typeAcceleratorPattern = new Regex(@"\b([A-Z]\w+\.)+\w+\b", RegexOptions.Multiline);
        Regex typeNamePattern = new Regex(@"\b([A-Z]\w*)\b", RegexOptions.Multiline);
        Regex attributePattern = new Regex(@"\[(.*?)\]", RegexOptions.Multiline);
        Regex cmdletPlaceholderPattern = new Regex(@"\{(?<index>\d+)\}", RegexOptions.Multiline);
        Regex scriptBlockPattern = new Regex(@"\{.*?\}", RegexOptions.Singleline);
        Regex multilineStringPattern = new Regex(@"(@['""])(.*?)\1", RegexOptions.Singleline);
        Regex hereStringPattern = new Regex(@"(@['""]{1,2})(.*?)\1", RegexOptions.Singleline);


        private void TextBox_TextChanged(object? sender, FastColoredTextBoxNS.TextChangedEventArgs e) {

            e.ChangedRange.ClearStyle(StyleIndex.All);

            if (SettingsUtil.IsSyntaxHighlightEnabled()) {

                // Set the style for comments
                e.ChangedRange.SetStyle(commentStyle, commentPattern);

                // Set the style for single-quoted and double-quoted strings
                e.ChangedRange.SetStyle(stringStyle, singleQuotedStringPattern);
                e.ChangedRange.SetStyle(stringStyle, doubleQuotedStringPattern);

                // Set the style for variables
                e.ChangedRange.SetStyle(variableStyle, variablePattern);

                // Set the style for variables enclosed in $( )
                e.ChangedRange.SetStyle(variableExpressionStyle, variableExpressionPattern);

                // Set the style for cmdlets
                e.ChangedRange.SetStyle(cmdletStyle, cmdletPattern);

                // Set the style for parameters
                e.ChangedRange.SetStyle(parameterStyle, parameterPattern);

                // Set the style for type accelerators
                e.ChangedRange.SetStyle(typeAcceleratorStyle, typeAcceleratorPattern);

                // Set the style for type names
                e.ChangedRange.SetStyle(typeNameStyle, typeNamePattern);

                // Set the style for attributes
                e.ChangedRange.SetStyle(attributeStyle, attributePattern);

                // Set the style for cmdlet placeholders enclosed in { }
                e.ChangedRange.SetStyle(cmdletPlaceholderStyle, cmdletPlaceholderPattern);

                // Set the style for script blocks enclosed in { }
                e.ChangedRange.SetStyle(scriptBlockStyle, scriptBlockPattern);

                // Set the style for multiline string literals enclosed in @' '@ or @" "@
                e.ChangedRange.SetStyle(multilineStringStyle, multilineStringPattern);

                // Set the style for here-strings enclosed in @"" "@ or @'' '@
                e.ChangedRange.SetStyle(hereStringStyle, hereStringPattern);
            }

            // Folding markers
            e.ChangedRange.ClearFoldingMarkers();

            e.ChangedRange.SetFoldingMarkers("{ ", "}");
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

        private void syntaxHighlight_Click(object sender, EventArgs e) {
            bool enabled = !SettingsUtil.IsSyntaxHighlightEnabled();
            SetSyntaxButtonImage(enabled);
            SettingsUtil.SetSyntaxHighlight(enabled);
        }

        private void SetSyntaxButtonImage(bool enabled) {
            syntaxHighlightButton.ImageIcon = (enabled ? Resources.SyntaxEnabled : Resources.SyntaxDisabled);
        }
    }
}
