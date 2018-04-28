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
    public partial class ComposeForm : Form
    {
        ApiClient _ac;
        Types.Status _inReplyTo;
        string _visibility;

        string Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                publicMenuItem.Checked = value == "public";
                unlistedMenuItem.Checked = value == "unlisted";
                followersMenuItem.Checked = value == "private";
                directMenuItem.Checked = value == "direct";
                _visibility = value;
            }
        }

        public ComposeForm()
        {
            InitializeComponent();
        }

        public ComposeForm(ApiClient ac)
            : this()
        {
            _ac = ac;

            Visibility = "public";
        }

        public ComposeForm(ApiClient ac, Types.Status inReplyTo)
            : this(ac)
        {
            Text = "Compose Reply";

            var actual = inReplyTo.ReblogOrSelf();
            _inReplyTo = inReplyTo;
            Visibility = actual.Visibility;
            // TODO: remove ourselves as a mention
            var actualMentions = actual.Mentions
                .Where(x => x.AccountId != actual.Account.AccountId);
            contentBox.Text = string.Join(" ", actualMentions
                .Select(x => x.ToString()).ToArray());
            cwBox.Text = actual.ContentWarning;
        }

        public ComposeForm(ApiClient ac, string template, string cw, string privacy)
            : this(ac)
        {
            Text = "Compose Reply";

            Visibility = privacy;
            contentBox.Text = template ?? "";
            cwBox.Text = cw ?? "";

            contentBox.SelectionStart = contentBox.Text.Length;
        }

        QueryString ToQueryString()
        {
            var qs = new QueryString();
            qs.Add("status", contentBox.Text);
            if (_inReplyTo != null)
                qs.Add("in_reply_to_id", _inReplyTo.Id.ToString());
            if (!string.IsNullOrEmpty(cwBox.Text))
                qs.Add("spoiler_text", cwBox.Text);
            qs.Add("sensitive", sensitiveMenuItem.Checked.ToString());
            qs.Add("visibility", Visibility);
            return qs;
        }

        public void SendStatus()
        {
            try
            {
                var res = _ac.SendUrlencoded("/api/v1/statuses", "POST", ToQueryString());
            
                // we don't actually need it
                JsonUtility.MaybeDeserialize<Types.Status>(res);

                Close();
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Sending Status");
            }
        }

        private void textboxInput(object sender, EventArgs e)
        {
            // TODO: we shouldn't hardcode this, get it from API
            remainingCharsLabel.Text = (500 -
                (cwBox.Text.Length +
                    contentBox.Text.Length)).ToString();
        }

        private void sendMenuItem_Click(object sender, EventArgs e)
        {
            SendStatus();
        }

        private void sensitiveMenuItem_Click(object sender, EventArgs e)
        {
            sensitiveMenuItem.Checked = !sensitiveMenuItem.Checked;
        }

        private void VisibilityItemClick(object sender, EventArgs e)
        {
            if (sender == publicMenuItem)
                Visibility = "public";
            else if (sender == unlistedMenuItem)
                Visibility = "unlisted";
            else if (sender == followersMenuItem)
                Visibility = "private";
            else if (sender == directMenuItem)
                Visibility = "direct";
            else 
                throw new Exception("Visiblity item event invoked for unknown item");
        }
    }
}