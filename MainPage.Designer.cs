namespace ShellHolder
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStartupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.startScriptButton = new ShellHolder.Controls.CustomButton();
            this.quickButtonLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.stopScriptButton = new ShellHolder.Controls.CustomButton();
            this.quickButtonLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveButton = new ShellHolder.Controls.CustomButton();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.quickButtonLayout1.SuspendLayout();
            this.quickButtonLayout2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1064, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStartupItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openStartupItem
            // 
            this.openStartupItem.Name = "openStartupItem";
            this.openStartupItem.Size = new System.Drawing.Size(183, 22);
            this.openStartupItem.Text = "Open startup screen.";
            this.openStartupItem.Click += new System.EventHandler(this.openStartupItem_Click);
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
            this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.ForeColor = System.Drawing.Color.White;
            this.textBox.IndentBackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox.IsReplaceMode = false;
            this.textBox.LineNumberColor = System.Drawing.Color.Turquoise;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Name = "textBox";
            this.textBox.Paddings = new System.Windows.Forms.Padding(0);
            this.textBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBox.ServiceColors")));
            this.textBox.Size = new System.Drawing.Size(1040, 427);
            this.textBox.TabIndex = 1;
            this.textBox.Zoom = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 83);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleBox);
            this.splitContainer1.Size = new System.Drawing.Size(1040, 586);
            this.splitContainer1.SplitterDistance = 427;
            this.splitContainer1.TabIndex = 2;
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.consoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox.ForeColor = System.Drawing.Color.White;
            this.consoleBox.Location = new System.Drawing.Point(0, 0);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(1040, 155);
            this.consoleBox.TabIndex = 0;
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
            this.startScriptButton.ImageIcon = ((System.Drawing.Image)(resources.GetObject("startScriptButton.ImageIcon")));
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
            // quickButtonLayout1
            // 
            this.quickButtonLayout1.ColumnCount = 2;
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickButtonLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickButtonLayout1.Controls.Add(this.startScriptButton, 0, 0);
            this.quickButtonLayout1.Controls.Add(this.stopScriptButton, 1, 0);
            this.quickButtonLayout1.Location = new System.Drawing.Point(15, 37);
            this.quickButtonLayout1.Margin = new System.Windows.Forms.Padding(0);
            this.quickButtonLayout1.Name = "quickButtonLayout1";
            this.quickButtonLayout1.RowCount = 1;
            this.quickButtonLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.quickButtonLayout1.Size = new System.Drawing.Size(80, 40);
            this.quickButtonLayout1.TabIndex = 4;
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
            this.stopScriptButton.ImageIcon = ((System.Drawing.Image)(resources.GetObject("stopScriptButton.ImageIcon")));
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
            // quickButtonLayout2
            // 
            this.quickButtonLayout2.ColumnCount = 2;
            this.quickButtonLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickButtonLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickButtonLayout2.Controls.Add(this.saveButton, 0, 0);
            this.quickButtonLayout2.Location = new System.Drawing.Point(116, 37);
            this.quickButtonLayout2.Margin = new System.Windows.Forms.Padding(0);
            this.quickButtonLayout2.Name = "quickButtonLayout2";
            this.quickButtonLayout2.RowCount = 1;
            this.quickButtonLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.quickButtonLayout2.Size = new System.Drawing.Size(80, 40);
            this.quickButtonLayout2.TabIndex = 5;
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
            this.saveButton.ImageIcon = ((System.Drawing.Image)(resources.GetObject("saveButton.ImageIcon")));
            this.saveButton.ImagePadding = 10;
            this.saveButton.Location = new System.Drawing.Point(2, 2);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(35, 35);
            this.saveButton.TabIndex = 6;
            this.saveButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.quickButtonLayout2);
            this.Controls.Add(this.quickButtonLayout1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainPage";
            this.Text = "ShellHolder";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.quickButtonLayout1.ResumeLayout(false);
            this.quickButtonLayout2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem openStartupItem;
        private FastColoredTextBoxNS.FastColoredTextBox textBox;
        private SplitContainer splitContainer1;
        private TextBox consoleBox;
        private Controls.CustomButton startScriptButton;
        private TableLayoutPanel quickButtonLayout1;
        private Controls.CustomButton stopScriptButton;
        private TableLayoutPanel quickButtonLayout2;
        private Controls.CustomButton saveButton;
    }
}