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

        public void UpdateAccountInPlace()
        {
            try
            {
                _account = Types.Account.GetById(_ac, _accountId);
                _statuses = _account.GetStatuses(_ac);
                _followers = _account.GetFollowers(_ac);
                _following = _account.GetFollowing(_ac);
                _relationship = _account.GetRelationship(_ac);
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
                _relationship = _relationship.Following ? _relationship.Unfollow(_ac) : _relationship.Follow(_ac);
                followMenuItem.Checked = _relationship.Following;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Following");
            }
        }

        private void composeMenuItem_Click(object sender, EventArgs e)
        {
            var template = string.Format("@{0} ", _account.AccountId);
            var cf = new ComposeForm(_ac, template, "", "direct");
            cf.Show();
        }

        private void muteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_relationship.Muting)
                {
                    var notifMute = false;
                    var qs = new QueryString();
                    // TODO: can mute/notif mute desync?
                    if (_relationship.Muting)
                    {
                        switch (MessageBox.Show("Do you want to mute notifications from this user as well?",
                            "Muting",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1))
                        {
                            case DialogResult.Yes:
                                notifMute = true;
                                break;
                            case DialogResult.No:
                                break;
                            default: // incl cancel
                                return;
                        }
                    }
                    qs.Add("notifications", notifMute.ToString());
                    _relationship = _relationship.Mute(_ac, notifMute);
                }
                else
                {
                    _relationship = _relationship.Unmute(_ac);
                }
                muteMenuItem.Checked = _relationship.Muting;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Muting");
            }
        }

        private void blockMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _relationship = _relationship.Blocking ? _relationship.Unblock(_ac) : _relationship.Block(_ac);
                blockMenuItem.Checked = _relationship.Blocking;
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Blocking");
            }
        }
    }
}