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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStartupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectControl = new System.Windows.Forms.TabControl();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1064, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
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
            // projectControl
            // 
            this.projectControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.projectControl.ItemSize = new System.Drawing.Size(110, 20);
            this.projectControl.Location = new System.Drawing.Point(0, 24);
            this.projectControl.Name = "projectControl";
            this.projectControl.SelectedIndex = 0;
            this.projectControl.Size = new System.Drawing.Size(1064, 537);
            this.projectControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.projectControl.TabIndex = 1;
            this.projectControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            this.projectControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjectControl_MouseClick);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1064, 561);
            this.Controls.Add(this.projectControl);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(1080, 600);
            this.Name = "MainPage";
            this.Text = "ShellHolder";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem openStartupItem;
        private TabControl projectControl;
    }
}