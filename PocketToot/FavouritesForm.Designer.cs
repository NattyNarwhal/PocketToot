namespace PocketToot
{
    partial class FavouritesForm
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
            this.unfavMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.showMoreMenuItem = new System.Windows.Forms.MenuItem();
            this.statusListView = new PocketToot.TootListView();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.unfavMenuItem);
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // unfavMenuItem
            // 
            this.unfavMenuItem.Text = "&Unfavourite";
            this.unfavMenuItem.Click += new System.EventHandler(this.unfavMenuItem_Click);
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
            // 
            // FavouritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusListView);
            this.Menu = this.mainMenu1;
            this.Name = "FavouritesForm";
            this.Text = "Favourites";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem unfavMenuItem;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.MenuItem refreshMenuItem;
        private System.Windows.Forms.MenuItem showMoreMenuItem;
        private TootListView statusListView;
    }
}