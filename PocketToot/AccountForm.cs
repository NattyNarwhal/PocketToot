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
        Types.Relationship _relationship;
        List<Types.Status> _statuses;
        List<Types.Account> _followers, _following;

        const string ACCOUNT_ROUTE_PREFIX_TEMPLATE = "/api/v1/accounts/{0}";
        const string ACCOUNT_RELATIONSHIPS_ROUTE_TEMPLATE = "/api/v1/accounts/relationships?id={0}";

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

        string FormatAccountByIdRoute()
        {
            return string.Format(ACCOUNT_ROUTE_PREFIX_TEMPLATE, _accountId);
        }

        string FormatAccountByIdRoute(string route)
        {
            return string.Format("{0}/{1}", FormatAccountByIdRoute(), route);
        }

        public void UpdateAccountInPlace()
        {
            try
            {
                var accountJson = _ac.Get(FormatAccountByIdRoute());
                _account = JsonUtility.MaybeDeserialize<Types.Account>(accountJson);
                var statusesJson = _ac.Get(FormatAccountByIdRoute("statuses"));
                _statuses = JsonUtility.MaybeDeserialize<List<Types.Status>>(statusesJson);
                var followersJson = _ac.Get(FormatAccountByIdRoute("followers"));
                _followers = JsonUtility.MaybeDeserialize<List<Types.Account>>(followersJson);
                var followingJson = _ac.Get(FormatAccountByIdRoute("following"));
                _following = JsonUtility.MaybeDeserialize<List<Types.Account>>(followingJson);
                // a special case....
                var relationshipsRoute = string.Format(ACCOUNT_RELATIONSHIPS_ROUTE_TEMPLATE, _accountId);
                var relationshipsJson = _ac.Get(relationshipsRoute);
                // it returns a list because you can give the route multiple....
                _relationship = JsonUtility.MaybeDeserialize<List<Types.Relationship>>(relationshipsJson).SingleOrDefault();
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

            // TODO: We scroll in more of all of these

            statusesBox.BeginUpdate();
            statusesBox.Items.Clear();
            foreach (var status in _statuses)
            {
                statusesBox.Items.Add(status);
            }
            statusesBox.EndUpdate();
            statusesBox.ItemWidth = -1;
            statusPage.Text = string.Format("Statuses ({0})", _account.Statuses);

            followingBox.BeginUpdate();
            followingBox.Items.Clear();
            foreach (var account in _following)
            {
                followingBox.Items.Add(account);
            }
            followingBox.EndUpdate();
            followingBox.ItemWidth = -1;
            followingPage.Text = string.Format("Following ({0})", _account.Following);

            followersBox.BeginUpdate();
            followersBox.Items.Clear();
            foreach (var account in _followers)
            {
                followersBox.Items.Add(account);
            }
            followersBox.EndUpdate();
            followersBox.ItemWidth = -1;
            followersPage.Text = string.Format("Followers ({0}{1})",
                _account.Followers,
                _account.Locked ? ", Locked" : "");

            followMenuItem.Checked = _relationship.Following;
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

        private void followersBox_ItemActivate(object sender, EventArgs e)
        {
            var account = followersBox.SelectedItems.FirstOrDefault();
            if (account != null)
            {
                var af = new AccountForm(_ac, account);
            }
        }

        private void followingBox_ItemActivate(object sender, EventArgs e)
        {
            var account = followingBox.SelectedItems.FirstOrDefault();
            if (account != null)
            {
                var af = new AccountForm(_ac, account);
            }
        }

        private void followMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var endpoint = _relationship.Following ? "unfollow" : "follow";
                var s = _ac.SendUrlencoded(FormatAccountByIdRoute(endpoint), "POST", null);
                _relationship = JsonUtility.MaybeDeserialize<Types.Relationship>(s);
                followMenuItem.Checked = _relationship.Following;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Following");
            }
        }
    }
}