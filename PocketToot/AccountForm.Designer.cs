﻿namespace PocketToot
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
            this.composeMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.followMenuItem = new System.Windows.Forms.MenuItem();
            this.muteMenuItem = new System.Windows.Forms.MenuItem();
            this.blockMenuItem = new System.Windows.Forms.MenuItem();
            this.sep1 = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.browserMenuItem = new System.Windows.Forms.MenuItem();
            this.copyLinkMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.notesPage = new System.Windows.Forms.TabPage();
            this.bioBox = new System.Windows.Forms.WebBrowser();
            this.statusPage = new System.Windows.Forms.TabPage();
            this.statusesBox = new PocketToot.TootListView();
            this.followersPage = new System.Windows.Forms.TabPage();
            this.followersBox = new PocketToot.AccountListView();
            this.followingPage = new System.Windows.Forms.TabPage();
            this.followingBox = new PocketToot.AccountListView();
            this.movedToPanel = new System.Windows.Forms.Panel();
            this.movedToLabel = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.notesPage.SuspendLayout();
            this.statusPage.SuspendLayout();
            this.followersPage.SuspendLayout();
            this.followingPage.SuspendLayout();
            this.movedToPanel.SuspendLayout();
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
            this.menu.MenuItems.Add(this.followMenuItem);
            this.menu.MenuItems.Add(this.muteMenuItem);
            this.menu.MenuItems.Add(this.blockMenuItem);
            this.menu.MenuItems.Add(this.sep1);
            this.menu.MenuItems.Add(this.refreshMenuItem);
            this.menu.MenuItems.Add(this.browserMenuItem);
            this.menu.MenuItems.Add(this.copyLinkMenuItem);
            this.menu.Text = "&Menu";
            // 
            // followMenuItem
            // 
            this.followMenuItem.Text = "&Follow";
            this.followMenuItem.Click += new System.EventHandler(this.followMenuItem_Click);
            // 
            // muteMenuItem
            // 
            this.muteMenuItem.Text = "&Mute";
            this.muteMenuItem.Click += new System.EventHandler(this.muteMenuItem_Click);
            // 
            // blockMenuItem
            // 
            this.blockMenuItem.Text = "&Block";
            this.blockMenuItem.Click += new System.EventHandler(this.blockMenuItem_Click);
            // 
            // sep1
            // 
            this.sep1.Text = "-";
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
            // notesPage
            // 
            this.notesPage.Controls.Add(this.bioBox);
            this.notesPage.Controls.Add(this.movedToPanel);
            this.notesPage.Location = new System.Drawing.Point(0, 0);
            this.notesPage.Name = "notesPage";
            this.notesPage.Size = new System.Drawing.Size(240, 245);
            this.notesPage.Text = "Bio";
            // 
            // bioBox
            // 
            this.bioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bioBox.Location = new System.Drawing.Point(0, 23);
            this.bioBox.Name = "bioBox";
            this.bioBox.Size = new System.Drawing.Size(240, 222);
            // 
            // statusPage
            // 
            this.statusPage.Controls.Add(this.statusesBox);
            this.statusPage.Location = new System.Drawing.Point(0, 0);
            this.statusPage.Name = "statusPage";
            this.statusPage.Size = new System.Drawing.Size(232, 242);
            this.statusPage.Text = "Statuses";
            // 
            // statusesBox
            // 
            this.statusesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusesBox.FullRowSelect = true;
            this.statusesBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.statusesBox.ItemWidth = 60;
            this.statusesBox.Location = new System.Drawing.Point(0, 0);
            this.statusesBox.Name = "statusesBox";
            this.statusesBox.Size = new System.Drawing.Size(232, 242);
            this.statusesBox.TabIndex = 0;
            this.statusesBox.View = System.Windows.Forms.View.Details;
            this.statusesBox.ItemActivate += new System.EventHandler(this.statusesBox_ItemActivate);
            // 
            // followersPage
            // 
            this.followersPage.Controls.Add(this.followersBox);
            this.followersPage.Location = new System.Drawing.Point(0, 0);
            this.followersPage.Name = "followersPage";
            this.followersPage.Size = new System.Drawing.Size(232, 242);
            this.followersPage.Text = "Followers";
            // 
            // followersBox
            // 
            this.followersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.followersBox.FullRowSelect = true;
            this.followersBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.followersBox.ItemWidth = 60;
            this.followersBox.Location = new System.Drawing.Point(0, 0);
            this.followersBox.Name = "followersBox";
            this.followersBox.Size = new System.Drawing.Size(232, 242);
            this.followersBox.TabIndex = 0;
            this.followersBox.View = System.Windows.Forms.View.Details;
            this.followersBox.ItemActivate += new System.EventHandler(this.followersBox_ItemActivate);
            // 
            // followingPage
            // 
            this.followingPage.Controls.Add(this.followingBox);
            this.followingPage.Location = new System.Drawing.Point(0, 0);
            this.followingPage.Name = "followingPage";
            this.followingPage.Size = new System.Drawing.Size(232, 242);
            this.followingPage.Text = "Following";
            // 
            // followingBox
            // 
            this.followingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.followingBox.FullRowSelect = true;
            this.followingBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.followingBox.ItemWidth = 60;
            this.followingBox.Location = new System.Drawing.Point(0, 0);
            this.followingBox.Name = "followingBox";
            this.followingBox.Size = new System.Drawing.Size(232, 242);
            this.followingBox.TabIndex = 0;
            this.followingBox.View = System.Windows.Forms.View.Details;
            this.followingBox.ItemActivate += new System.EventHandler(this.followingBox_ItemActivate);
            // 
            // movedToPanel
            // 
            this.movedToPanel.Controls.Add(this.movedToLabel);
            this.movedToPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movedToPanel.Location = new System.Drawing.Point(0, 0);
            this.movedToPanel.Name = "movedToPanel";
            this.movedToPanel.Size = new System.Drawing.Size(240, 23);
            // 
            // movedToLabel
            // 
            this.movedToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.movedToLabel.Location = new System.Drawing.Point(7, 4);
            this.movedToLabel.Name = "movedToLabel";
            this.movedToLabel.Size = new System.Drawing.Size(226, 16);
            this.movedToLabel.TabIndex = 0;
            this.movedToLabel.Text = "Moved to";
            this.movedToLabel.Click += new System.EventHandler(this.movedToLabel_Click);
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
            this.notesPage.ResumeLayout(false);
            this.statusPage.ResumeLayout(false);
            this.followersPage.ResumeLayout(false);
            this.followingPage.ResumeLayout(false);
            this.movedToPanel.ResumeLayout(false);
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
        private AccountListView followersBox;
        private AccountListView followingBox;
        private System.Windows.Forms.MenuItem followMenuItem;
        private System.Windows.Forms.MenuItem sep1;
        private System.Windows.Forms.MenuItem composeMenuItem;
        private System.Windows.Forms.MenuItem muteMenuItem;
        private System.Windows.Forms.MenuItem blockMenuItem;
        private System.Windows.Forms.Panel movedToPanel;
        private System.Windows.Forms.LinkLabel movedToLabel;
    }
}