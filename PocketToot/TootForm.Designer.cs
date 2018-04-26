namespace PocketToot
{
    partial class TootForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TootForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.replyMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.boostMenuItem = new System.Windows.Forms.MenuItem();
            this.favMenuItem = new System.Windows.Forms.MenuItem();
            this.sep1 = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.browserMenuItem = new System.Windows.Forms.MenuItem();
            this.copyLinkMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contentsTab = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.metaListView = new System.Windows.Forms.ListView();
            this.keyHeader = new System.Windows.Forms.ColumnHeader();
            this.valueHeader = new System.Windows.Forms.ColumnHeader();
            this.threadPage = new System.Windows.Forms.TabPage();
            this.threadBox = new PocketToot.TootListView();
            this.attachmentsPage = new System.Windows.Forms.TabPage();
            this.attachmentsBox = new System.Windows.Forms.ListView();
            this.attachmentDescriptionHeader = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.tabControl1.SuspendLayout();
            this.contentsTab.SuspendLayout();
            this.threadPage.SuspendLayout();
            this.attachmentsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.replyMenuItem);
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // replyMenuItem
            // 
            this.replyMenuItem.Text = "&Reply";
            this.replyMenuItem.Click += new System.EventHandler(this.replyMenuItem_Click);
            // 
            // menu
            // 
            this.menu.MenuItems.Add(this.boostMenuItem);
            this.menu.MenuItems.Add(this.favMenuItem);
            this.menu.MenuItems.Add(this.sep1);
            this.menu.MenuItems.Add(this.refreshMenuItem);
            this.menu.MenuItems.Add(this.browserMenuItem);
            this.menu.MenuItems.Add(this.copyLinkMenuItem);
            this.menu.Text = "&Menu";
            // 
            // boostMenuItem
            // 
            this.boostMenuItem.Text = "&Boost";
            this.boostMenuItem.Click += new System.EventHandler(this.boostMenuItem_Click);
            // 
            // favMenuItem
            // 
            this.favMenuItem.Text = "&Favourite";
            this.favMenuItem.Click += new System.EventHandler(this.favMenuItem_Click);
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
            this.tabControl1.Controls.Add(this.contentsTab);
            this.tabControl1.Controls.Add(this.threadPage);
            this.tabControl1.Controls.Add(this.attachmentsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 2;
            // 
            // contentsTab
            // 
            this.contentsTab.Controls.Add(this.webBrowser1);
            this.contentsTab.Controls.Add(this.splitter1);
            this.contentsTab.Controls.Add(this.metaListView);
            this.contentsTab.Location = new System.Drawing.Point(0, 0);
            this.contentsTab.Name = "contentsTab";
            this.contentsTab.Size = new System.Drawing.Size(240, 245);
            this.contentsTab.Text = "Status";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 85);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(240, 160);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 82);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(240, 3);
            // 
            // metaListView
            // 
            this.metaListView.Columns.Add(this.keyHeader);
            this.metaListView.Columns.Add(this.valueHeader);
            this.metaListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.metaListView.FullRowSelect = true;
            this.metaListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.metaListView.Location = new System.Drawing.Point(0, 0);
            this.metaListView.Name = "metaListView";
            this.metaListView.Size = new System.Drawing.Size(240, 82);
            this.metaListView.TabIndex = 2;
            this.metaListView.View = System.Windows.Forms.View.Details;
            this.metaListView.ItemActivate += new System.EventHandler(this.metaListView_ItemActivate);
            // 
            // keyHeader
            // 
            this.keyHeader.Text = "Property Name";
            this.keyHeader.Width = 60;
            // 
            // valueHeader
            // 
            this.valueHeader.Text = "Value";
            this.valueHeader.Width = 60;
            // 
            // threadPage
            // 
            this.threadPage.Controls.Add(this.threadBox);
            this.threadPage.Location = new System.Drawing.Point(0, 0);
            this.threadPage.Name = "threadPage";
            this.threadPage.Size = new System.Drawing.Size(240, 245);
            this.threadPage.Text = "Thread";
            // 
            // threadBox
            // 
            this.threadBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadBox.FullRowSelect = true;
            this.threadBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.threadBox.ItemWidth = 60;
            this.threadBox.Location = new System.Drawing.Point(0, 0);
            this.threadBox.Name = "threadBox";
            this.threadBox.Size = new System.Drawing.Size(240, 245);
            this.threadBox.TabIndex = 0;
            this.threadBox.View = System.Windows.Forms.View.Details;
            this.threadBox.ItemActivate += new System.EventHandler(this.threadBox_ItemActivate);
            // 
            // attachmentsPage
            // 
            this.attachmentsPage.Controls.Add(this.attachmentsBox);
            this.attachmentsPage.Location = new System.Drawing.Point(0, 0);
            this.attachmentsPage.Name = "attachmentsPage";
            this.attachmentsPage.Size = new System.Drawing.Size(232, 242);
            this.attachmentsPage.Text = "Attached";
            // 
            // attachmentsBox
            // 
            this.attachmentsBox.Columns.Add(this.attachmentDescriptionHeader);
            this.attachmentsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentsBox.Location = new System.Drawing.Point(0, 0);
            this.attachmentsBox.Name = "attachmentsBox";
            this.attachmentsBox.Size = new System.Drawing.Size(232, 242);
            this.attachmentsBox.SmallImageList = this.imageList1;
            this.attachmentsBox.TabIndex = 0;
            this.attachmentsBox.View = System.Windows.Forms.View.Details;
            this.attachmentsBox.ItemActivate += new System.EventHandler(this.attachmentsBox_ItemActivate);
            // 
            // attachmentDescriptionHeader
            // 
            this.attachmentDescriptionHeader.Text = "Description";
            this.attachmentDescriptionHeader.Width = 200;
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            // 
            // TootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "TootForm";
            this.Text = "Viewing Status";
            this.tabControl1.ResumeLayout(false);
            this.contentsTab.ResumeLayout(false);
            this.threadPage.ResumeLayout(false);
            this.attachmentsPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage contentsTab;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage threadPage;
        private System.Windows.Forms.TabPage attachmentsPage;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.MenuItem boostMenuItem;
        private System.Windows.Forms.MenuItem favMenuItem;
        private System.Windows.Forms.MenuItem replyMenuItem;
        private System.Windows.Forms.MenuItem sep1;
        private System.Windows.Forms.MenuItem browserMenuItem;
        private System.Windows.Forms.MenuItem copyLinkMenuItem;
        private System.Windows.Forms.ListView attachmentsBox;
        private System.Windows.Forms.ColumnHeader attachmentDescriptionHeader;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView metaListView;
        private System.Windows.Forms.ColumnHeader keyHeader;
        private System.Windows.Forms.ColumnHeader valueHeader;
        protected System.Windows.Forms.MainMenu mainMenu1;
        private TootListView threadBox;
        private System.Windows.Forms.MenuItem refreshMenuItem;


    }
}