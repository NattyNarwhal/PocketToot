namespace PocketToot
{
    partial class NotificationsForm
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
            this.notificationListView = new PocketToot.Controls.NotificationListView();
            this.clearMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.showMoreMenuItem = new System.Windows.Forms.MenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.dismissSingleMenuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.clearMenuItem);
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // notificationListView
            // 
            this.notificationListView.ContextMenu = this.contextMenu;
            this.notificationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationListView.FullRowSelect = true;
            this.notificationListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.notificationListView.ItemWidth = 60;
            this.notificationListView.Location = new System.Drawing.Point(0, 0);
            this.notificationListView.Name = "notificationListView";
            this.notificationListView.Size = new System.Drawing.Size(240, 268);
            this.notificationListView.TabIndex = 0;
            this.notificationListView.View = System.Windows.Forms.View.Details;
            this.notificationListView.ItemActivate += new System.EventHandler(this.notificationListView_ItemActivate);
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Text = "&Clear";
            this.clearMenuItem.Click += new System.EventHandler(this.clearMenuItem_Click);
            // 
            // menu
            // 
            this.menu.MenuItems.Add(this.refreshMenuItem);
            this.menu.MenuItems.Add(this.showMoreMenuItem);
            this.menu.Text = "&Menu";
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
            // contextMenu
            // 
            this.contextMenu.MenuItems.Add(this.dismissSingleMenuItem);
            // 
            // dismissSingleMenuItem
            // 
            this.dismissSingleMenuItem.Text = "&Dismiss";
            this.dismissSingleMenuItem.Click += new System.EventHandler(this.dismissSingleMenuItem_Click);
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.notificationListView);
            this.Menu = this.mainMenu1;
            this.Name = "NotificationsForm";
            this.Text = "Notifications";
            this.ResumeLayout(false);

        }

        #endregion

        private PocketToot.Controls.NotificationListView notificationListView;
        private System.Windows.Forms.MenuItem clearMenuItem;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.MenuItem refreshMenuItem;
        private System.Windows.Forms.MenuItem showMoreMenuItem;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem dismissSingleMenuItem;
    }
}