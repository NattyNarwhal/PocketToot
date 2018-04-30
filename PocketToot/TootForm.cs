using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace PocketToot
{
    public partial class TootForm : Form
    {
        ApiClient _ac;
        Types.Status _status;
        Types.Context _context;

        public TootForm()
        {
            InitializeComponent();

            attachmentsBox.SetUpImageList();
        }

        public TootForm(ApiClient ac, Types.Status status)
            : this()
        {
            _ac = ac;
            _status = status;

            UpdateStatusInPlace();

            SetForUI(_status);

            tabControl1.SelectedIndex = 0;
        }

        public void UpdateStatusInPlace()
        {
            // TODO: do this async
            // try to fetch refreshed status or fall back on given param
            try
            {
                _status = Types.Status.GetById(_ac, _status.Id);
                _context = _status.GetContext(_ac);
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Checking Status");
            }
        }

        public void SetForUI(Types.Status status)
        {
            var toUse = status.ReblogOrSelf();

            metaListView.Items.Clear();
            if (status.ContainedReblog != null)
            {
                AddMeta("Boost from", status.Account);
                AddMeta("Boost date", status.CreatedAt);
            }
            if (toUse.ReblogCount > 0)
                AddMeta("Boosts", toUse.ReblogCount);

            AddMeta("From", toUse.Account);
            AddMeta("Date", toUse.CreatedAt);

            AddMeta("Visibility", toUse.Visibility);

            if (toUse.FavouriteCount > 0)
                AddMeta("Favourites", toUse.FavouriteCount);
            if (!string.IsNullOrEmpty(toUse.ContentWarning))
                AddMeta("Spoiler", toUse.ContentWarning);
            if (toUse.Application != null)
                AddMeta("Application", toUse.Application);
            if (toUse.Pinned.HasValue && toUse.Pinned.Value)
                AddMeta("Pinned", "Yes");
            if (!string.IsNullOrEmpty(toUse.Language))
                AddMeta("Language", toUse.Language);

            favMenuItem.Checked = toUse.HasFavourited.Coerce();
            boostMenuItem.Checked = toUse.HasReblogged.Coerce();
            // we can't boost these kinds of status
            boostMenuItem.Enabled = toUse.Visibility != "direct" && toUse.Visibility != "private";
            // XXX: reblog or self? also conditions for pin and delete...
            pinMenuItem.Checked = toUse.Pinned.Coerce();

            foreach (var mention in toUse.Mentions)
            {
                AddMeta("Mentions", mention);
            }
            foreach (var tag in toUse.Tags)
            {
                AddMeta("Hashtag", tag);
            }

            // Attachments
            if (toUse.Attachments.Count > 0)
            {
                attachmentsBox.BeginUpdate();
                attachmentsBox.Items.Clear();
                foreach (var attachment in toUse.Attachments)
                {
                    attachmentsBox.Items.Add(attachment);
                }
                attachmentsBox.EndUpdate();
                attachmentsBox.ItemWidth = -1;
            }
            attachmentsPage.Text = string.Format("Attachments ({0})", toUse.Attachments.Count);

            // Thread
            if (_context != null)
            {
                threadBox.BeginUpdate();
                threadBox.Items.Clear(); // TODO: Splice in
                foreach (var s in _context.Ancestors)
                    threadBox.Items.Add(s);
                threadBox.Items.Add(_status.ReblogOrSelf());
                foreach (var s in _context.Descendants)
                    threadBox.Items.Add(s);
                threadBox.EndUpdate();
                threadBox.ItemWidth = -1;
                threadPage.Text = string.Format("Thread ({0})", threadBox.Items.Count);
            }

            keyHeader.Width = -1;
            valueHeader.Width = -1;

            string content;
            if (bool.Parse(Settings.GetSetting("RenderEmoji", "true")))
            {
                // cap size to 16px
                content = HtmlUtility.StatusContentsRenderingEmoji(toUse, 16);
            }
            else
            {
                content = toUse.Content;
            }
            webBrowser1.DocumentText = content;
        }

        void AddMeta(string n, object v)
        {
            AddMeta(n, v, v.ToString());
        }

        void AddMeta(string n, object v, string vso)
        {
            var lvi = new ListViewItem();
            lvi.Tag = v;
            lvi.Text = n;
            lvi.SubItems.Add(vso);
            metaListView.Items.Add(lvi);
        }

        private void browserMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("iexplore", _status.ReblogOrSelf().Url);
        }

        private void copyLinkMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(_status.ReblogOrSelf().Url);
        }

        private void attachmentsBox_ItemActivate(object sender, EventArgs e)
        {
            // it would be nice if we could display this in our own viewer, but
            // PictureBox kinda sucks and doesn' do PNG on Compact Framework...
            // and we get OutOfMemory exceptions like crazy if we try anyways
            var attachment = attachmentsBox.SelectedItems.FirstOrDefault();
            if (attachment != null)
            {
                var url = string.IsNullOrEmpty(attachment.LocalUrl) ? attachment.RemoteUrl : attachment.LocalUrl;
                Process.Start("iexplore", url);
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // TODO: handle URLs, as we could dispatch to a form instead

            if (e.Url.Scheme.StartsWith("http"))
                e.Cancel = true;
        }

        private void replyMenuItem_Click(object sender, EventArgs e)
        {
            var cf = new ComposeForm(_ac, _status);
            cf.Show();
        }

        private void metaListView_ItemActivate(object sender, EventArgs e)
        {
            if (metaListView.SelectedIndices.Count > 0)
            {
                var lvi = metaListView.Items[metaListView.SelectedIndices[0]];
                var match = lvi.Tag;
                // i wish i had pattern matching here!
                if (match is Types.Application)
                {
                    var app = (Types.Application)match;
                    Process.Start("iexplore", app.Website);
                }
                else if (match is Types.Tag)
                {
                    var tag = (Types.Tag)match;
                    var tf = new TimelineForm(_ac, tag.Name);
                    tf.Show();
                }
                // TODO: AccountForm
                else if (match is Types.Mention)
                {
                    var mention = (Types.Mention)match;
                    var af = new AccountForm(_ac, mention);
                    af.Show();
                }
                else if (match is Types.Account)
                {
                    var account = (Types.Account)match;
                    var af = new AccountForm(_ac, account);
                    af.Show();
                }
            }
        }

        private void boostMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _status = _status.HasReblogged.Coerce() ? _status.Unreblog(_ac) : _status.Reblog(_ac);
                boostMenuItem.Checked = _status.ReblogOrSelf().HasReblogged.Coerce();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Boosting");
            }
        }

        private void favMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _status = _status.HasFavourited.Coerce() ? _status.Unfavourite(_ac) : _status.Favourite(_ac);
                favMenuItem.Checked = _status.ReblogOrSelf().HasFavourited.Coerce();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Favouriting");
            }
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStatusInPlace();
            SetForUI(_status);
        }

        private void threadBox_ItemActivate(object sender, EventArgs e)
        {
            var status = threadBox.SelectedItems.FirstOrDefault();
            if (status != null &&
                (status.Id != _status.Id ||
                status.Id != _status.ReblogOrSelf().Id))
            {
                var tf = new TootForm(_ac, status);
                tf.Show();
            }
        }

        private void pinMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _status = _status.Pinned.Coerce() ? _status.Unpin(_ac) : _status.Pin(_ac);
                pinMenuItem.Checked = _status.Pinned.Coerce();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Pinning");
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var toUse = _status.ReblogOrSelf();
                toUse.Delete(_ac);
                Close();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Deleting");
            }
        }

        private void muteConvMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _status = _status.Muted.Coerce() ? _status.Unmute(_ac) : _status.Mute(_ac);
                muteConvMenuItem.Checked = _status.Muted.Coerce();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Muting Conversation");
            }
        }
    }
}