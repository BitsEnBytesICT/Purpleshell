namespace ShellHolder
{
    partial class ProjectPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPage));
            baseContainer = new SplitContainer();
            quickButtonLayout1 = new TableLayoutPanel();
            startScriptButton = new Controls.CustomButton();
            stopScriptButton = new Controls.CustomButton();
            saveButton = new Controls.CustomButton();
            homeButton = new Controls.CustomButton();
            syntaxHighlightButton = new Controls.CustomButton();
            loopingButton = new Controls.CustomButton();
            mainContainer = new SplitContainer();
            textBox = new FastColoredTextBoxNS.FastColoredTextBox();
            consoleBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)baseContainer).BeginInit();
            baseContainer.Panel1.SuspendLayout();
            baseContainer.Panel2.SuspendLayout();
            baseContainer.SuspendLayout();
            quickButtonLayout1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox).BeginInit();
            SuspendLayout();
            // 
            // baseContainer
            // 
            baseContainer.Dock = DockStyle.Fill;
            baseContainer.FixedPanel = FixedPanel.Panel1;
            baseContainer.IsSplitterFixed = true;
            baseContainer.Location = new Point(0, 0);
            baseContainer.Margin = new Padding(0);
            baseContainer.Name = "baseContainer";
            baseContainer.Orientation = Orientation.Horizontal;
            // 
            // baseContainer.Panel1
            // 
            baseContainer.Panel1.Controls.Add(quickButtonLayout1);
            // 
            // baseContainer.Panel2
            // 
            baseContainer.Panel2.Controls.Add(mainContainer);
            baseContainer.Size = new Size(1080, 720);
            baseContainer.SplitterDistance = 40;
            baseContainer.SplitterWidth = 1;
            baseContainer.TabIndex = 0;
            // 
            // quickButtonLayout1
            // 
            quickButtonLayout1.ColumnCount = 10;
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            quickButtonLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            quickButtonLayout1.Controls.Add(startScriptButton, 0, 0);
            quickButtonLayout1.Controls.Add(stopScriptButton, 1, 0);
            quickButtonLayout1.Controls.Add(saveButton, 3, 0);
            quickButtonLayout1.Controls.Add(homeButton, 8, 0);
            quickButtonLayout1.Controls.Add(syntaxHighlightButton, 6, 0);
            quickButtonLayout1.Controls.Add(loopingButton, 5, 0);
            quickButtonLayout1.Dock = DockStyle.Fill;
            quickButtonLayout1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            quickButtonLayout1.Location = new Point(0, 0);
            quickButtonLayout1.Margin = new Padding(0);
            quickButtonLayout1.Name = "quickButtonLayout1";
            quickButtonLayout1.RowCount = 1;
            quickButtonLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            quickButtonLayout1.Size = new Size(1080, 40);
            quickButtonLayout1.TabIndex = 5;
            // 
            // startScriptButton
            // 
            startScriptButton.Anchor = AnchorStyles.None;
            startScriptButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            startScriptButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            startScriptButton.BackgroundImageLayout = ImageLayout.Center;
            startScriptButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            startScriptButton.BorderRadius = 8;
            startScriptButton.BorderSize = 3;
            startScriptButton.FlatAppearance.BorderSize = 0;
            startScriptButton.FlatStyle = FlatStyle.Flat;
            startScriptButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            startScriptButton.HoverToolTip = "Click to start script.";
            startScriptButton.ImageIcon = Purpleshell.Properties.Resources.Start;
            startScriptButton.ImagePadding = 11;
            startScriptButton.Location = new Point(2, 2);
            startScriptButton.Margin = new Padding(0);
            startScriptButton.Name = "startScriptButton";
            startScriptButton.Size = new Size(35, 35);
            startScriptButton.TabIndex = 3;
            startScriptButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            startScriptButton.UseVisualStyleBackColor = false;
            startScriptButton.Click += startScript_Click;
            // 
            // stopScriptButton
            // 
            stopScriptButton.Anchor = AnchorStyles.None;
            stopScriptButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            stopScriptButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            stopScriptButton.BackgroundImageLayout = ImageLayout.Center;
            stopScriptButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            stopScriptButton.BorderRadius = 8;
            stopScriptButton.BorderSize = 3;
            stopScriptButton.FlatAppearance.BorderSize = 0;
            stopScriptButton.FlatStyle = FlatStyle.Flat;
            stopScriptButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            stopScriptButton.HoverToolTip = "Click to stop the running script.";
            stopScriptButton.ImageIcon = Purpleshell.Properties.Resources.Stop;
            stopScriptButton.ImagePadding = 11;
            stopScriptButton.Location = new Point(42, 2);
            stopScriptButton.Margin = new Padding(0);
            stopScriptButton.Name = "stopScriptButton";
            stopScriptButton.Size = new Size(35, 35);
            stopScriptButton.TabIndex = 5;
            stopScriptButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            stopScriptButton.UseVisualStyleBackColor = false;
            stopScriptButton.Click += stopScriptButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.None;
            saveButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            saveButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            saveButton.BackgroundImageLayout = ImageLayout.Center;
            saveButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            saveButton.BorderRadius = 8;
            saveButton.BorderSize = 3;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            saveButton.HoverToolTip = "Click to save or use Ctrl + S.";
            saveButton.ImageIcon = Purpleshell.Properties.Resources.Save;
            saveButton.ImagePadding = 10;
            saveButton.Location = new Point(92, 2);
            saveButton.Margin = new Padding(0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(35, 35);
            saveButton.TabIndex = 7;
            saveButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // homeButton
            // 
            homeButton.Anchor = AnchorStyles.None;
            homeButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            homeButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            homeButton.BackgroundImageLayout = ImageLayout.Center;
            homeButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            homeButton.BorderRadius = 8;
            homeButton.BorderSize = 3;
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            homeButton.HoverToolTip = "Click to open the startup page.";
            homeButton.ImageIcon = Purpleshell.Properties.Resources.Home;
            homeButton.ImagePadding = 7;
            homeButton.Location = new Point(1012, 2);
            homeButton.Margin = new Padding(0);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(35, 35);
            homeButton.TabIndex = 8;
            homeButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // syntaxHighlightButton
            // 
            syntaxHighlightButton.Anchor = AnchorStyles.None;
            syntaxHighlightButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            syntaxHighlightButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            syntaxHighlightButton.BackgroundImageLayout = ImageLayout.Center;
            syntaxHighlightButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            syntaxHighlightButton.BorderRadius = 8;
            syntaxHighlightButton.BorderSize = 3;
            syntaxHighlightButton.FlatAppearance.BorderSize = 0;
            syntaxHighlightButton.FlatStyle = FlatStyle.Flat;
            syntaxHighlightButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            syntaxHighlightButton.HoverToolTip = "Click to enable or disable syntax highlighting.";
            syntaxHighlightButton.ImageIcon = null;
            syntaxHighlightButton.ImagePadding = 7;
            syntaxHighlightButton.Location = new Point(912, 2);
            syntaxHighlightButton.Margin = new Padding(0);
            syntaxHighlightButton.Name = "syntaxHighlightButton";
            syntaxHighlightButton.Size = new Size(35, 35);
            syntaxHighlightButton.TabIndex = 9;
            syntaxHighlightButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            syntaxHighlightButton.UseVisualStyleBackColor = false;
            syntaxHighlightButton.Click += syntaxHighlight_Click;
            // 
            // loopingButton
            // 
            loopingButton.Anchor = AnchorStyles.None;
            loopingButton.BackColor = Color.FromArgb(100, 120, 120, 120);
            loopingButton.BackgroundColor = Color.FromArgb(100, 120, 120, 120);
            loopingButton.BackgroundImageLayout = ImageLayout.Center;
            loopingButton.BorderColor = Color.FromArgb(100, 130, 130, 130);
            loopingButton.BorderRadius = 8;
            loopingButton.BorderSize = 3;
            loopingButton.FlatAppearance.BorderSize = 0;
            loopingButton.FlatStyle = FlatStyle.Flat;
            loopingButton.ForeColor = Color.FromArgb(100, 255, 255, 255);
            loopingButton.HoverToolTip = "Click to enable or disable looping.";
            loopingButton.ImageIcon = null;
            loopingButton.ImagePadding = 7;
            loopingButton.Location = new Point(872, 2);
            loopingButton.Margin = new Padding(0);
            loopingButton.Name = "loopingButton";
            loopingButton.Size = new Size(35, 35);
            loopingButton.TabIndex = 10;
            loopingButton.TextColor = Color.FromArgb(100, 255, 255, 255);
            loopingButton.UseVisualStyleBackColor = false;
            loopingButton.Click += looping_Click;
            // 
            // mainContainer
            // 
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Name = "mainContainer";
            mainContainer.Orientation = Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.Controls.Add(textBox);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.Controls.Add(consoleBox);
            mainContainer.Size = new Size(1080, 679);
            mainContainer.SplitterDistance = 407;
            mainContainer.TabIndex = 3;
            // 
            // textBox
            // 
            textBox.AutoCompleteBracketsList = (new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' });
            textBox.AutoScrollMinSize = new Size(2, 14);
            textBox.BackBrush = null;
            textBox.BackColor = Color.FromArgb(60, 60, 60);
            textBox.CharHeight = 14;
            textBox.CharWidth = 8;
            textBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            textBox.Dock = DockStyle.Fill;
            textBox.ForeColor = Color.White;
            textBox.IndentBackColor = SystemColors.WindowFrame;
            textBox.IsReplaceMode = false;
            textBox.LineNumberColor = Color.Crimson;
            textBox.Location = new Point(0, 0);
            textBox.Name = "textBox";
            textBox.Paddings = new Padding(0);
            textBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            textBox.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("textBox.ServiceColors");
            textBox.ShowFoldingLines = true;
            textBox.Size = new Size(1080, 407);
            textBox.TabIndex = 1;
            textBox.Zoom = 100;
            // 
            // consoleBox
            // 
            consoleBox.BackColor = Color.FromArgb(40, 40, 40);
            consoleBox.Dock = DockStyle.Fill;
            consoleBox.ForeColor = Color.White;
            consoleBox.Location = new Point(0, 0);
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            consoleBox.Size = new Size(1080, 268);
            consoleBox.TabIndex = 0;
            consoleBox.Text = "";
            // 
            // ProjectPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(baseContainer);
            Name = "ProjectPage";
            Size = new Size(1080, 720);
            baseContainer.Panel1.ResumeLayout(false);
            baseContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)baseContainer).EndInit();
            baseContainer.ResumeLayout(false);
            quickButtonLayout1.ResumeLayout(false);
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer baseContainer;
        private SplitContainer mainContainer;
        private FastColoredTextBoxNS.FastColoredTextBox textBox;
        private RichTextBox consoleBox;
        private TableLayoutPanel quickButtonLayout1;
        private Controls.CustomButton startScriptButton;
        private Controls.CustomButton stopScriptButton;
        private Controls.CustomButton saveButton;
        private Controls.CustomButton syntaxHighlightButton;
        private Controls.CustomButton homeButton;
        private Controls.CustomButton loopingButton;
    }
}
