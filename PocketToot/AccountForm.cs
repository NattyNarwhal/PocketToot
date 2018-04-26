using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PocketToot
{
    public partial class AccountForm : Form
    {
        ApiClient _ac;
        long _accountId;
        Types.Account _account;
        List<Types.Status> _statuses;
        List<Types.Account> _followers, _following;

        const string ACCOUNT_ROUTE_PREFIX_TEMPLATE = "/api/v1/accounts/{0}";

        public AccountForm()
        {
            InitializeComponent();
        }

        public AccountForm(ApiClient client, long id)
            : this()
        {
            _ac = client;
            _accountId = id;

            UpdateAccountInPlace();
            SetForUI();

            tabControl1.SelectedIndex = 0;
        }

        public AccountForm(ApiClient client, Types.Mention mention)
            : this(client, mention.Id)
        {
        }

        public AccountForm(ApiClient client, Types.Account account)
            : this(client, account.Id)
        {
        }

        string FormatRoute()
        {
            return string.Format(ACCOUNT_ROUTE_PREFIX_TEMPLATE, _accountId);
        }

        string FormatRoute(string route)
        {
            return string.Format("{0}/{1}", FormatRoute(), route);
        }

        public void UpdateAccountInPlace()
        {
            try
            {
                var accountJson = _ac.Get(FormatRoute());
                _account = JsonUtility.MaybeDeserialize<Types.Account>(accountJson);
                var statusesJson = _ac.Get(FormatRoute("statuses"));
                _statuses = JsonUtility.MaybeDeserialize<List<Types.Status>>(statusesJson);
                var followersJson = _ac.Get(FormatRoute("followers"));
                _followers = JsonUtility.MaybeDeserialize<List<Types.Account>>(followersJson);
                var followingJson = _ac.Get(FormatRoute("following"));
                _following = JsonUtility.MaybeDeserialize<List<Types.Account>>(followingJson);
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Fetching Account Info");
            }
        }

        public void SetForUI()
        {
            Text = _account.ToString();

            bioBox.DocumentText = _account.Note;

            statusesBox.BeginUpdate();
            statusesBox.Items.Clear();
            foreach (var status in _statuses)
            {
                statusesBox.Items.Add(status);
            }
            statusesBox.EndUpdate();
            statusesBox.ItemWidth = -1;
            statusPage.Text = string.Format("Statuses ({0})", _statuses.Count);

            // TODO: impl accounts list views
            followingPage.Text = string.Format("Following ({0})", _following.Count);
            followersPage.Text = string.Format("Followers ({0}{1})",
                _followers.Count,
                _account.Locked ? ", Locked" : "");
        }

        private void statusesBox_ItemActivate(object sender, EventArgs e)
        {
            var status = statusesBox.SelectedItems.FirstOrDefault();
            if (status != null)
            {
                var tf = new TootForm(_ac, status);
                tf.Show();
            }
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAccountInPlace();
            SetForUI();
        }

        private void browserMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("iexplore", _account.Url);
        }

        private void copyLinkMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(_account.Url);
        }
    }
}