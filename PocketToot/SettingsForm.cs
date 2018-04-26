using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PocketToot
{
    public partial class SettingsForm : Form
    {
        const string VERIFY_CREDENTIALS = "/api/v1/accounts/verify_credentials";

        ApiClient ac;

        public SettingsForm()
        {
            InitializeComponent();
            hostnameBox.Text = Settings.GetSetting("InstanceHostname", "");
            tokenBox.Text = Settings.GetSetting("InstanceToken", "");
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
                var uJson = tempAc.Get(VERIFY_CREDENTIALS);
                var u = JsonUtility.MaybeDeserialize<Types.Account>(uJson);
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
        }
    }
}