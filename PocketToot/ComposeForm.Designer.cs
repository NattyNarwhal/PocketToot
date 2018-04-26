namespace PocketToot
{
    partial class ComposeForm
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
            this.sendMenuItem = new System.Windows.Forms.MenuItem();
            this.menu = new System.Windows.Forms.MenuItem();
            this.sensitiveMenuItem = new System.Windows.Forms.MenuItem();
            this.privacyMenu = new System.Windows.Forms.MenuItem();
            this.publicMenuItem = new System.Windows.Forms.MenuItem();
            this.unlistedMenuItem = new System.Windows.Forms.MenuItem();
            this.followersMenuItem = new System.Windows.Forms.MenuItem();
            this.directMenuItem = new System.Windows.Forms.MenuItem();
            this.contentBox = new System.Windows.Forms.TextBox();
            this.cwLabel = new System.Windows.Forms.Label();
            this.cwBox = new System.Windows.Forms.TextBox();
            this.remainingCharsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.sendMenuItem);
            this.mainMenu1.MenuItems.Add(this.menu);
            // 
            // sendMenuItem
            // 
            this.sendMenuItem.Text = "&Send";
            this.sendMenuItem.Click += new System.EventHandler(this.sendMenuItem_Click);
            // 
            // menu
            // 
            this.menu.MenuItems.Add(this.sensitiveMenuItem);
            this.menu.MenuItems.Add(this.privacyMenu);
            this.menu.Text = "&Menu";
            // 
            // sensitiveMenuItem
            // 
            this.sensitiveMenuItem.Text = "&Sensitive Media";
            this.sensitiveMenuItem.Click += new System.EventHandler(this.sensitiveMenuItem_Click);
            // 
            // privacyMenu
            // 
            this.privacyMenu.MenuItems.Add(this.publicMenuItem);
            this.privacyMenu.MenuItems.Add(this.unlistedMenuItem);
            this.privacyMenu.MenuItems.Add(this.followersMenuItem);
            this.privacyMenu.MenuItems.Add(this.directMenuItem);
            this.privacyMenu.Text = "Status &Privacy";
            // 
            // publicMenuItem
            // 
            this.publicMenuItem.Text = "&Public";
            this.publicMenuItem.Click += new System.EventHandler(this.VisibilityItemClick);
            // 
            // unlistedMenuItem
            // 
            this.unlistedMenuItem.Text = "&Unlisted";
            this.unlistedMenuItem.Click += new System.EventHandler(this.VisibilityItemClick);
            // 
            // followersMenuItem
            // 
            this.followersMenuItem.Text = "&Followers";
            this.followersMenuItem.Click += new System.EventHandler(this.VisibilityItemClick);
            // 
            // directMenuItem
            // 
            this.directMenuItem.Text = "&Direct";
            this.directMenuItem.Click += new System.EventHandler(this.VisibilityItemClick);
            // 
            // contentBox
            // 
            this.contentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentBox.Location = new System.Drawing.Point(3, 3);
            this.contentBox.Multiline = true;
            this.contentBox.Name = "contentBox";
            this.contentBox.Size = new System.Drawing.Size(234, 215);
            this.contentBox.TabIndex = 0;
            this.contentBox.TextChanged += new System.EventHandler(this.textboxInput);
            // 
            // cwLabel
            // 
            this.cwLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cwLabel.Location = new System.Drawing.Point(3, 221);
            this.cwLabel.Name = "cwLabel";
            this.cwLabel.Size = new System.Drawing.Size(174, 20);
            this.cwLabel.Text = "Content Warning";
            // 
            // cwBox
            // 
            this.cwBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cwBox.Location = new System.Drawing.Point(3, 244);
            this.cwBox.Name = "cwBox";
            this.cwBox.Size = new System.Drawing.Size(234, 21);
            this.cwBox.TabIndex = 2;
            this.cwBox.TextChanged += new System.EventHandler(this.textboxInput);
            // 
            // remainingCharsLabel
            // 
            this.remainingCharsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remainingCharsLabel.Location = new System.Drawing.Point(183, 221);
            this.remainingCharsLabel.Name = "remainingCharsLabel";
            this.remainingCharsLabel.Size = new System.Drawing.Size(54, 20);
            this.remainingCharsLabel.Text = "500";
            this.remainingCharsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ComposeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.remainingCharsLabel);
            this.Controls.Add(this.cwBox);
            this.Controls.Add(this.cwLabel);
            this.Controls.Add(this.contentBox);
            this.Menu = this.mainMenu1;
            this.Name = "ComposeForm";
            this.Text = "Compose Status";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem sendMenuItem;
        private System.Windows.Forms.MenuItem menu;
        private System.Windows.Forms.TextBox contentBox;
        private System.Windows.Forms.Label cwLabel;
        private System.Windows.Forms.TextBox cwBox;
        private System.Windows.Forms.Label remainingCharsLabel;
        private System.Windows.Forms.MenuItem sensitiveMenuItem;
        private System.Windows.Forms.MenuItem privacyMenu;
        private System.Windows.Forms.MenuItem publicMenuItem;
        private System.Windows.Forms.MenuItem unlistedMenuItem;
        private System.Windows.Forms.MenuItem followersMenuItem;
        private System.Windows.Forms.MenuItem directMenuItem;
    }
}