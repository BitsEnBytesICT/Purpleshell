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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPage));
            this.baseContainer = new System.Windows.Forms.SplitContainer();
            this.quickButtonLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.startScriptButton = new ShellHolder.Controls.CustomButton();
            this.stopScriptButton = new ShellHolder.Controls.CustomButton();
            this.saveButton = new ShellHolder.Controls.CustomButton();
            this.homeButton = new ShellHolder.Controls.CustomButton();
            this.syntaxHighlightButton = new ShellHolder.Controls.CustomButton();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.textBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.baseContainer)).BeginInit();
            this.baseContainer.Panel1.SuspendLayout();
            this.baseContainer.Panel2.SuspendLayout();
            this.baseContainer.SuspendLayout();
            this.quickButtonLayout1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox)).BeginInit();
            this.SuspendLayout();
            // 
            // baseContainer
            // 
            this.baseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.baseContainer.IsSplitterFixed = true;
            this.baseContainer.Location = new System.Drawing.Point(0, 0);
            this.baseContainer.Margin = new System.Windows.Forms.Padding(0);
            this.baseContainer.Name = "baseContainer";
            this.baseContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // baseContainer.Panel1
            // 
            this.baseContainer.Panel1.Controls.Add(this.quickButtonLayout1);
            // 
            // baseContainer.Panel2
            // 
            this.baseContainer.Panel2.Controls.Add(this.mainContainer);
            this.baseContainer.Size = new System.Drawing.Size(1080, 720);
            this.baseContainer.SplitterDistance = 40;
            this.baseContainer.SplitterWidth = 1;
            this.baseContainer.TabIndex = 0;
            // 
            // quickButtonLayout1
            // 
            this.quickButtonLayout1.ColumnCount = 9;
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.quickButtonLayout1.Controls.Add(this.startScriptButton, 0, 0);
            this.quickButtonLayout1.Controls.Add(this.stopScriptButton, 1, 0);
            this.quickButtonLayout1.Controls.Add(this.saveButton, 3, 0);
            this.quickButtonLayout1.Controls.Add(this.homeButton, 7, 0);
            this.quickButtonLayout1.Controls.Add(this.syntaxHighlightButton, 5, 0);
            this.quickButtonLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickButtonLayout1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.quickButtonLayout1.Location = new System.Drawing.Point(0, 0);
            this.quickButtonLayout1.Margin = new System.Windows.Forms.Padding(0);
            this.quickButtonLayout1.Name = "quickButtonLayout1";
            this.quickButtonLayout1.RowCount = 1;
            this.quickButtonLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.quickButtonLayout1.Size = new System.Drawing.Size(1080, 40);
            this.quickButtonLayout1.TabIndex = 5;
            // 
            // startScriptButton
            // 
            this.startScriptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startScriptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.startScriptButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.startScriptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startScriptButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.startScriptButton.BorderRadius = 8;
            this.startScriptButton.BorderSize = 3;
            this.startScriptButton.FlatAppearance.BorderSize = 0;
            this.startScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startScriptButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startScriptButton.HoverToolTip = "Click to start script.";
            this.startScriptButton.ImageIcon = global::Purpleshell.Properties.Resources.Start;
            this.startScriptButton.ImagePadding = 11;
            this.startScriptButton.Location = new System.Drawing.Point(2, 2);
            this.startScriptButton.Margin = new System.Windows.Forms.Padding(0);
            this.startScriptButton.Name = "startScriptButton";
            this.startScriptButton.Size = new System.Drawing.Size(35, 35);
            this.startScriptButton.TabIndex = 3;
            this.startScriptButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startScriptButton.UseVisualStyleBackColor = false;
            this.startScriptButton.Click += new System.EventHandler(this.startScript_Click);
            // 
            // stopScriptButton
            // 
            this.stopScriptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopScriptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.stopScriptButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.stopScriptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopScriptButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.stopScriptButton.BorderRadius = 8;
            this.stopScriptButton.BorderSize = 3;
            this.stopScriptButton.FlatAppearance.BorderSize = 0;
            this.stopScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopScriptButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stopScriptButton.HoverToolTip = "Click to stop the running script.";
            this.stopScriptButton.ImageIcon = global::Purpleshell.Properties.Resources.Stop;
            this.stopScriptButton.ImagePadding = 11;
            this.stopScriptButton.Location = new System.Drawing.Point(42, 2);
            this.stopScriptButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopScriptButton.Name = "stopScriptButton";
            this.stopScriptButton.Size = new System.Drawing.Size(35, 35);
            this.stopScriptButton.TabIndex = 5;
            this.stopScriptButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stopScriptButton.UseVisualStyleBackColor = false;
            this.stopScriptButton.Click += new System.EventHandler(this.stopScriptButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.saveButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.saveButton.BorderRadius = 8;
            this.saveButton.BorderSize = 3;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.saveButton.HoverToolTip = "Click to save or use Ctrl + S.";
            this.saveButton.ImageIcon = global::Purpleshell.Properties.Resources.Save;
            this.saveButton.ImagePadding = 10;
            this.saveButton.Location = new System.Drawing.Point(92, 2);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(35, 35);
            this.saveButton.TabIndex = 7;
            this.saveButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.homeButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.homeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.homeButton.BorderRadius = 8;
            this.homeButton.BorderSize = 3;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.homeButton.HoverToolTip = "Click to open the startup page.";
            this.homeButton.ImageIcon = global::Purpleshell.Properties.Resources.Home;
            this.homeButton.ImagePadding = 7;
            this.homeButton.Location = new System.Drawing.Point(1022, 2);
            this.homeButton.Margin = new System.Windows.Forms.Padding(0);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(35, 35);
            this.homeButton.TabIndex = 8;
            this.homeButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // syntaxHighlightButton
            // 
            this.syntaxHighlightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.syntaxHighlightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.syntaxHighlightButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.syntaxHighlightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.syntaxHighlightButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.syntaxHighlightButton.BorderRadius = 8;
            this.syntaxHighlightButton.BorderSize = 3;
            this.syntaxHighlightButton.FlatAppearance.BorderSize = 0;
            this.syntaxHighlightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syntaxHighlightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.syntaxHighlightButton.HoverToolTip = "Click to enable or disable syntax highlighting.";
            this.syntaxHighlightButton.ImageIcon = null;
            this.syntaxHighlightButton.ImagePadding = 7;
            this.syntaxHighlightButton.Location = new System.Drawing.Point(962, 2);
            this.syntaxHighlightButton.Margin = new System.Windows.Forms.Padding(0);
            this.syntaxHighlightButton.Name = "syntaxHighlightButton";
            this.syntaxHighlightButton.Size = new System.Drawing.Size(35, 35);
            this.syntaxHighlightButton.TabIndex = 9;
            this.syntaxHighlightButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.syntaxHighlightButton.UseVisualStyleBackColor = false;
            this.syntaxHighlightButton.Click += new System.EventHandler(this.syntaxHighlight_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.textBox);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.consoleBox);
            this.mainContainer.Size = new System.Drawing.Size(1080, 746);
            this.mainContainer.SplitterDistance = 448;
            this.mainContainer.TabIndex = 3;
            // 
            // textBox
            // 
            this.textBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.textBox.BackBrush = null;
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.textBox.CharHeight = 14;
            this.textBox.CharWidth = 8;
            this.textBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.ForeColor = System.Drawing.Color.White;
            this.textBox.IndentBackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox.IsReplaceMode = false;
            this.textBox.LineNumberColor = System.Drawing.Color.Crimson;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Name = "textBox";
            this.textBox.Paddings = new System.Windows.Forms.Padding(0);
            this.textBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBox.ServiceColors")));
            this.textBox.ShowFoldingLines = true;
            this.textBox.Size = new System.Drawing.Size(1080, 448);
            this.textBox.TabIndex = 1;
            this.textBox.Zoom = 100;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.ForeColor = System.Drawing.Color.White;
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(1080, 294);
            this.consoleBox.TabIndex = 0;
            this.consoleBox.Text = "";
            // 
            // ProjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.baseContainer);
            this.Name = "ProjectPage";
            this.Size = new System.Drawing.Size(1080, 720);
            this.baseContainer.Panel1.ResumeLayout(false);
            this.baseContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.baseContainer)).EndInit();
            this.baseContainer.ResumeLayout(false);
            this.quickButtonLayout1.ResumeLayout(false);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox)).EndInit();
            this.ResumeLayout(false);

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
    }
}
