namespace PocketToot
{
    partial class TimelineForm
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
            this.composeMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.timelineMenu = new System.Windows.Forms.MenuItem();
            this.localPublicTumelineMenuItem = new System.Windows.Forms.MenuItem();
            this.publicTimelineMenuItem = new System.Windows.Forms.MenuItem();
            this.tagTimelineMenuItem = new System.Windows.Forms.MenuItem();
            this.favouritesMenuItem = new System.Windows.Forms.MenuItem();
            this.sep2 = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.showMoreMenuItem = new System.Windows.Forms.MenuItem();
            this.sep1 = new System.Windows.Forms.MenuItem();
            this.myProfileMenuItem = new System.Windows.Forms.MenuItem();
            this.sep3 = new System.Windows.Forms.MenuItem();
            this.settingsMenuItem = new System.Windows.Forms.MenuItem();
            this.statusListView = new PocketToot.TootListView();
            this.notificationsMenuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.composeMenuItem);
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // composeMenuItem
            // 
            this.composeMenuItem.Text = "&Compose";
            this.composeMenuItem.Click += new System.EventHandler(this.composeMenuItem_Click);
            // 
            // menu
            // 
            this.menu.MenuItems.Add(this.timelineMenu);
            this.menu.MenuItems.Add(this.notificationsMenuItem);
            this.menu.MenuItems.Add(this.favouritesMenuItem);
            this.menu.MenuItems.Add(this.sep2);
            this.menu.MenuItems.Add(this.refreshMenuItem);
            this.menu.MenuItems.Add(this.showMoreMenuItem);
            this.menu.MenuItems.Add(this.sep1);
            this.menu.MenuItems.Add(this.myProfileMenuItem);
            this.menu.MenuItems.Add(this.sep3);
            this.menu.MenuItems.Add(this.settingsMenuItem);
            this.menu.Text = "&Menu";
            // 
            // timelineMenu
            // 
            this.timelineMenu.MenuItems.Add(this.localPublicTumelineMenuItem);
            this.timelineMenu.MenuItems.Add(this.publicTimelineMenuItem);
            this.timelineMenu.MenuItems.Add(this.tagTimelineMenuItem);
            this.timelineMenu.Text = "Change &Timeline";
            // 
            // localPublicTumelineMenuItem
            // 
            this.localPublicTumelineMenuItem.Text = "&Local Timeline";
            this.localPublicTumelineMenuItem.Click += new System.EventHandler(this.localPublicTumelineMenuItem_Click);
            // 
            // publicTimelineMenuItem
            // 
            this.publicTimelineMenuItem.Text = "&Federated Timeline";
            this.publicTimelineMenuItem.Click += new System.EventHandler(this.publicTimelineMenuItem_Click);
            // 
            // tagTimelineMenuItem
            // 
            this.tagTimelineMenuItem.Text = "Hash&tag...";
            this.tagTimelineMenuItem.Click += new System.EventHandler(this.tagTimelineMenuItem_Click);
            // 
            // favouritesMenuItem
            // 
            this.favouritesMenuItem.Text = "&Favourites";
            this.favouritesMenuItem.Click += new System.EventHandler(this.favouritesMenuItem_Click);
            // 
            // sep2
            // 
            this.sep2.Text = "-";
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Text = "&Refresh";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // showMoreMenuItem
            // 
            this.showMoreMenuItem.Text = "Show &More";
            this.showMoreMenuItem.Click += new System.EventHandler(this.showMoreMenuItem_Click);
            // 
            // sep1
            // 
            this.sep1.Text = "-";
            // 
            // myProfileMenuItem
            // 
            this.myProfileMenuItem.Text = "My &Profile";
            this.myProfileMenuItem.Click += new System.EventHandler(this.myProfileMenuItem_Click);
            // 
            // sep3
            // 
            this.sep3.Text = "-";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Text = "&Settings...";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // statusListView
            // 
            this.statusListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusListView.FullRowSelect = true;
            this.statusListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.statusListView.ItemWidth = 60;
            this.statusListView.Location = new System.Drawing.Point(0, 0);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(240, 268);
            this.statusListView.TabIndex = 0;
            this.statusListView.View = System.Windows.Forms.View.Details;
            this.statusListView.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // notificationsMenuItem
            // 
            this.notificationsMenuItem.Text = "&Notifications";
            this.notificationsMenuItem.Click += new System.EventHandler(this.notificationsMenuItem_Click);
            // 
            // TimelineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusListView);
            this.Menu = this.mainMenu1;
            this.Name = "TimelineForm";
            this.Text = "PocketToot";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem refreshMenuItem;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.MenuItem settingsMenuItem;
        private System.Windows.Forms.MenuItem composeMenuItem;
        private System.Windows.Forms.MenuItem sep1;
        private System.Windows.Forms.MenuItem timelineMenu;
        private System.Windows.Forms.MenuItem publicTimelineMenuItem;
        private System.Windows.Forms.MenuItem tagTimelineMenuItem;
        private TootListView statusListView;
        private System.Windows.Forms.MenuItem showMoreMenuItem;
        private System.Windows.Forms.MenuItem localPublicTumelineMenuItem;
        private System.Windows.Forms.MenuItem favouritesMenuItem;
        private System.Windows.Forms.MenuItem sep2;
        private System.Windows.Forms.MenuItem myProfileMenuItem;
        private System.Windows.Forms.MenuItem sep3;
        private System.Windows.Forms.MenuItem notificationsMenuItem;

    }
}

