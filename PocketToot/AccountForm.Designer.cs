namespace PocketToot
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusPage = new System.Windows.Forms.TabPage();
            this.followersPage = new System.Windows.Forms.TabPage();
            this.followingPage = new System.Windows.Forms.TabPage();
            this.notesPage = new System.Windows.Forms.TabPage();
            this.bioBox = new System.Windows.Forms.WebBrowser();
            this.statusesBox = new PocketToot.TootListView();
            this.menu = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.browserMenuItem = new System.Windows.Forms.MenuItem();
            this.copyLinkMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.statusPage.SuspendLayout();
            this.notesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.notesPage);
            this.tabControl1.Controls.Add(this.statusPage);
            this.tabControl1.Controls.Add(this.followersPage);
            this.tabControl1.Controls.Add(this.followingPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 1;
            // 
            // statusPage
            // 
            this.statusPage.Controls.Add(this.statusesBox);
            this.statusPage.Location = new System.Drawing.Point(0, 0);
            this.statusPage.Name = "statusPage";
            this.statusPage.Size = new System.Drawing.Size(240, 245);
            this.statusPage.Text = "Statuses";
            // 
            // followersPage
            // 
            this.followersPage.Location = new System.Drawing.Point(0, 0);
            this.followersPage.Name = "followersPage";
            this.followersPage.Size = new System.Drawing.Size(232, 242);
            this.followersPage.Text = "Followers";
            // 
            // followingPage
            // 
            this.followingPage.Location = new System.Drawing.Point(0, 0);
            this.followingPage.Name = "followingPage";
            this.followingPage.Size = new System.Drawing.Size(232, 242);
            this.followingPage.Text = "Following";
            // 
            // notesPage
            // 
            this.notesPage.Controls.Add(this.bioBox);
            this.notesPage.Location = new System.Drawing.Point(0, 0);
            this.notesPage.Name = "notesPage";
            this.notesPage.Size = new System.Drawing.Size(240, 245);
            this.notesPage.Text = "Bio";
            // 
            // bioBox
            // 
            this.bioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bioBox.Location = new System.Drawing.Point(0, 0);
            this.bioBox.Name = "bioBox";
            this.bioBox.Size = new System.Drawing.Size(240, 245);
            // 
            // statusesBox
            // 
            this.statusesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusesBox.FullRowSelect = true;
            this.statusesBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.statusesBox.ItemWidth = 60;
            this.statusesBox.Location = new System.Drawing.Point(0, 0);
            this.statusesBox.Name = "statusesBox";
            this.statusesBox.Size = new System.Drawing.Size(240, 245);
            this.statusesBox.TabIndex = 0;
            this.statusesBox.View = System.Windows.Forms.View.Details;
            this.statusesBox.ItemActivate += new System.EventHandler(this.statusesBox_ItemActivate);
            // 
            // menu
            // 
            this.menu.MenuItems.Add(this.refreshMenuItem);
            this.menu.MenuItems.Add(this.browserMenuItem);
            this.menu.MenuItems.Add(this.copyLinkMenuItem);
            this.menu.Text = "&Menu";
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Text = "&Refresh";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // browserMenuItem
            // 
            this.browserMenuItem.Text = "&Open in Browser...";
            this.browserMenuItem.Click += new System.EventHandler(this.browserMenuItem_Click);
            // 
            // copyLinkMenuItem
            // 
            this.copyLinkMenuItem.Text = "&Copy Permalink";
            this.copyLinkMenuItem.Click += new System.EventHandler(this.copyLinkMenuItem_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.tabControl1.ResumeLayout(false);
            this.statusPage.ResumeLayout(false);
            this.notesPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage statusPage;
        private System.Windows.Forms.TabPage followersPage;
        private System.Windows.Forms.TabPage followingPage;
        private System.Windows.Forms.TabPage notesPage;
        private System.Windows.Forms.WebBrowser bioBox;
        private TootListView statusesBox;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.MenuItem refreshMenuItem;
        private System.Windows.Forms.MenuItem browserMenuItem;
        private System.Windows.Forms.MenuItem copyLinkMenuItem;
    }
}