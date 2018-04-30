using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;

namespace PocketToot
{
    public partial class SettingsForm : Form
    {
        ApiClient ac;

        public SettingsForm()
        {
            InitializeComponent();
            
            var assembly = Assembly.GetExecutingAssembly();
            appNameLabel.Text = string.Format("PocketToot {0}", assembly.GetName().Version);
            licenseBox.Text = Properties.Resources.License;

            hostnameBox.Text = Settings.GetSetting("InstanceHostname", "");
            tokenBox.Text = Settings.GetSetting("InstanceToken", "");

            emojiBox.Checked = bool.Parse(Settings.GetSetting("RenderEmoji", "true"));
        }

        public SettingsForm(ApiClient client)
            : this()
        {
            ac = client;
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                var tempAc = new ApiClient(hostnameBox.Text, tokenBox.Text);
                var u = Types.Account.GetSelf(tempAc);
                MessageBox.Show(string.Format("Logged in as {0}.", u.AccountId), "Successfully verified");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error verifying", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void SettingsForm_Closing(object sender, CancelEventArgs e)
        {
            Settings.SetSetting("InstanceHostname", hostnameBox.Text);
            Settings.SetSetting("InstanceToken", tokenBox.Text);
            Settings.SetSetting("RenderEmoji", emojiBox.Checked.ToString());
        }

        private void appAuthorLabel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore; // something unique
            Close();
        }
    }
}