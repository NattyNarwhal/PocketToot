namespace PocketToot
{
    partial class SettingsForm
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
            this.instancePage = new System.Windows.Forms.TabPage();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.hostnameBox = new System.Windows.Forms.TextBox();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.verifyButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.instancePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.instancePage);
            this.tabControl1.Controls.Add(this.aboutPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 0;
            // 
            // instancePage
            // 
            this.instancePage.Controls.Add(this.verifyButton);
            this.instancePage.Controls.Add(this.tokenBox);
            this.instancePage.Controls.Add(this.tokenLabel);
            this.instancePage.Controls.Add(this.hostnameBox);
            this.instancePage.Controls.Add(this.hostnameLabel);
            this.instancePage.Location = new System.Drawing.Point(0, 0);
            this.instancePage.Name = "instancePage";
            this.instancePage.Size = new System.Drawing.Size(240, 245);
            this.instancePage.Text = "Instance";
            // 
            // tokenBox
            // 
            this.tokenBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenBox.Location = new System.Drawing.Point(3, 74);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.Size = new System.Drawing.Size(230, 21);
            this.tokenBox.TabIndex = 3;
            // 
            // tokenLabel
            // 
            this.tokenLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenLabel.Location = new System.Drawing.Point(7, 51);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(226, 20);
            this.tokenLabel.Text = "OAuth token";
            // 
            // hostnameBox
            // 
            this.hostnameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hostnameBox.Location = new System.Drawing.Point(3, 27);
            this.hostnameBox.Name = "hostnameBox";
            this.hostnameBox.Size = new System.Drawing.Size(230, 21);
            this.hostnameBox.TabIndex = 1;
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hostnameLabel.Location = new System.Drawing.Point(7, 4);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(226, 20);
            this.hostnameLabel.Text = "Instance name";
            // 
            // aboutPage
            // 
            this.aboutPage.Location = new System.Drawing.Point(0, 0);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Size = new System.Drawing.Size(232, 242);
            this.aboutPage.Text = "About";
            // 
            // verifyButton
            // 
            this.verifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.verifyButton.Location = new System.Drawing.Point(3, 101);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(230, 20);
            this.verifyButton.TabIndex = 6;
            this.verifyButton.Text = "Test Settings";
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SettingsForm_Closing);
            this.tabControl1.ResumeLayout(false);
            this.instancePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage instancePage;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.TextBox hostnameBox;
        private System.Windows.Forms.Label hostnameLabel;
        private System.Windows.Forms.Button verifyButton;
    }
}