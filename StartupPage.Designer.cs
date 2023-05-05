namespace ShellHolder
{
    partial class StartupPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.startupButtons = new System.Windows.Forms.TableLayoutPanel();
            this.NewProjectButton = new ShellHolder.Controls.StartupButton();
            this.ImportButton = new ShellHolder.Controls.StartupButton();
            this.RecentProjectsLabel = new System.Windows.Forms.Label();
            this.RecentProjectsLayout = new System.Windows.Forms.Panel();
            this.CloseStartupPage = new ShellHolder.Controls.CustomButton();
            this.RefreshButton = new ShellHolder.Controls.CustomButton();
            this.lockExtensionsCheckbox = new System.Windows.Forms.CheckBox();
            this.startupButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // startupButtons
            // 
            this.startupButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startupButtons.ColumnCount = 1;
            this.startupButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startupButtons.Controls.Add(this.NewProjectButton, 0, 0);
            this.startupButtons.Controls.Add(this.ImportButton, 0, 1);
            this.startupButtons.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.startupButtons.Location = new System.Drawing.Point(785, 65);
            this.startupButtons.Name = "startupButtons";
            this.startupButtons.RowCount = 3;
            this.startupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.startupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.startupButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.startupButtons.Size = new System.Drawing.Size(265, 264);
            this.startupButtons.TabIndex = 0;
            // 
            // NewProjectButton
            // 
            this.NewProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NewProjectButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NewProjectButton.BorderRadius = 8;
            this.NewProjectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewProjectButton.FirstLine = "New Project";
            this.NewProjectButton.FlatAppearance.BorderSize = 0;
            this.NewProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewProjectButton.ForeColor = System.Drawing.Color.White;
            this.NewProjectButton.ImageIcon = global::ShellHolder.Properties.Resources.NewProject;
            this.NewProjectButton.Location = new System.Drawing.Point(3, 3);
            this.NewProjectButton.Name = "NewProjectButton";
            this.NewProjectButton.SecondLine = "Start a new powershell project";
            this.NewProjectButton.Size = new System.Drawing.Size(259, 82);
            this.NewProjectButton.TabIndex = 0;
            this.NewProjectButton.TextColor = System.Drawing.Color.White;
            this.NewProjectButton.UseVisualStyleBackColor = false;
            this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.AllowDrop = true;
            this.ImportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ImportButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ImportButton.BorderRadius = 8;
            this.ImportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportButton.FirstLine = "Import a Script";
            this.ImportButton.FlatAppearance.BorderSize = 0;
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.ForeColor = System.Drawing.Color.White;
            this.ImportButton.ImageIcon = global::ShellHolder.Properties.Resources.ImportProject;
            this.ImportButton.Location = new System.Drawing.Point(3, 91);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.SecondLine = "Drag or click to import a script outside of ShellHolder";
            this.ImportButton.Size = new System.Drawing.Size(259, 82);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.TextColor = System.Drawing.Color.White;
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            this.ImportButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImportButton_DragDrop);
            this.ImportButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImportButton_DragEnter);
            // 
            // RecentProjectsLabel
            // 
            this.RecentProjectsLabel.AutoSize = true;
            this.RecentProjectsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecentProjectsLabel.ForeColor = System.Drawing.Color.White;
            this.RecentProjectsLabel.Location = new System.Drawing.Point(34, 45);
            this.RecentProjectsLabel.Name = "RecentProjectsLabel";
            this.RecentProjectsLabel.Size = new System.Drawing.Size(73, 17);
            this.RecentProjectsLabel.TabIndex = 2;
            this.RecentProjectsLabel.Text = "All projects";
            // 
            // RecentProjectsLayout
            // 
            this.RecentProjectsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RecentProjectsLayout.AutoScroll = true;
            this.RecentProjectsLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RecentProjectsLayout.Location = new System.Drawing.Point(34, 68);
            this.RecentProjectsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.RecentProjectsLayout.Name = "RecentProjectsLayout";
            this.RecentProjectsLayout.Padding = new System.Windows.Forms.Padding(4);
            this.RecentProjectsLayout.Size = new System.Drawing.Size(537, 502);
            this.RecentProjectsLayout.TabIndex = 3;
            // 
            // CloseStartupPage
            // 
            this.CloseStartupPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseStartupPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CloseStartupPage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CloseStartupPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CloseStartupPage.BorderRadius = 8;
            this.CloseStartupPage.BorderSize = 0;
            this.CloseStartupPage.FlatAppearance.BorderSize = 0;
            this.CloseStartupPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseStartupPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CloseStartupPage.HoverToolTip = "";
            this.CloseStartupPage.ImageIcon = global::ShellHolder.Properties.Resources.X;
            this.CloseStartupPage.ImagePadding = 7;
            this.CloseStartupPage.Location = new System.Drawing.Point(1020, 540);
            this.CloseStartupPage.Name = "CloseStartupPage";
            this.CloseStartupPage.Size = new System.Drawing.Size(30, 30);
            this.CloseStartupPage.TabIndex = 4;
            this.CloseStartupPage.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CloseStartupPage.UseVisualStyleBackColor = false;
            this.CloseStartupPage.Click += new System.EventHandler(this.CloseStartupPage_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.RefreshButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.RefreshButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.RefreshButton.BorderRadius = 5;
            this.RefreshButton.BorderSize = 0;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RefreshButton.HoverToolTip = "";
            this.RefreshButton.ImageIcon = global::ShellHolder.Properties.Resources.Refresh;
            this.RefreshButton.ImagePadding = 4;
            this.RefreshButton.Location = new System.Drawing.Point(546, 40);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(25, 25);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // lockExtensionsCheckbox
            // 
            this.lockExtensionsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lockExtensionsCheckbox.AutoSize = true;
            this.lockExtensionsCheckbox.Checked = true;
            this.lockExtensionsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockExtensionsCheckbox.Location = new System.Drawing.Point(1025, 217);
            this.lockExtensionsCheckbox.Name = "lockExtensionsCheckbox";
            this.lockExtensionsCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lockExtensionsCheckbox.Size = new System.Drawing.Size(15, 14);
            this.lockExtensionsCheckbox.TabIndex = 6;
            this.lockExtensionsCheckbox.UseVisualStyleBackColor = false;
            // 
            // StartupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.lockExtensionsCheckbox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CloseStartupPage);
            this.Controls.Add(this.RecentProjectsLayout);
            this.Controls.Add(this.RecentProjectsLabel);
            this.Controls.Add(this.startupButtons);
            this.Name = "StartupPage";
            this.Size = new System.Drawing.Size(1080, 600);
            this.startupButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TableLayoutPanel startupButtons;
        private Controls.StartupButton NewProjectButton;
        //private Controls.StartupButton OpenButton;
        private Controls.StartupButton ImportButton;
        private Label RecentProjectsLabel;
        private Panel RecentProjectsLayout;
        private Controls.CustomButton CloseStartupPage;
        private Controls.CustomButton RefreshButton;
        private CheckBox lockExtensionsCheckbox;
    }
}