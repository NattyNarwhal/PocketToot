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

        const string STATUS_ROUTE_TEMPLATE = "/api/v1/statuses/{0}/{1}";

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

            // too expensive atm
            // UpdateStatusInPlace();

            SetForUI(_status);

            tabControl1.SelectedIndex = 0;
        }

        public void UpdateStatusInPlace()
        {
            // TODO: do this async
            // try to fetch refreshed status or fall back on given param
            try
            {
                var newStatusJson = _ac.Get(FormatStatusRoute());
                var newStatus = JsonUtility.MaybeDeserialize<Types.Status>(newStatusJson);
                _status = newStatus;
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
            if (status.Reblog != null)
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
            try
            {
                threadBox.BeginUpdate();

                var contextJson = _ac.Get(FormatStatusRoute("context"));
                var context = JsonUtility.MaybeDeserialize<Types.Context>(contextJson);

                threadBox.Items.Clear();
                foreach (var s in context.Ancestors.Concat(context.Descendants))
                {
                    threadBox.Items.Add(s);
                }
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Reconstructing Thread");
            }
            finally
            {
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

        string FormatStatusRoute()
        {
            return string.Format("/api/v1/statuses/{0}", _status.Id);
        }

        string FormatStatusRoute(string statusEndpoint)
        {
            return FormatStatusRoute(statusEndpoint, true);
        }

        string FormatStatusRoute(string statusEndpoint, bool useReblogged)
        {
            var status = useReblogged ? _status.ReblogOrSelf() : _status;
            return string.Format(STATUS_ROUTE_TEMPLATE, status.Id, statusEndpoint);
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
                    var tf = new TimelineForm(_ac, tag.ToString(), TimelineForm.TAG_TIMELINE_ROUTE_PREFIX + tag.Name);
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
                var toUse = _status.ReblogOrSelf();
                var endpoint = toUse.HasReblogged.Coerce() ? "unreblog" : "reblog";
                var s = _ac.SendUrlencoded(FormatStatusRoute(endpoint), "POST", null);
                _status = JsonUtility.MaybeDeserialize<Types.Status>(s);
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
                var toUse = _status.ReblogOrSelf();
                var endpoint = toUse.HasFavourited.Coerce() ? "unfavourite" : "favourite";
                var s = _ac.SendUrlencoded(FormatStatusRoute(endpoint), "POST", null);
                _status = JsonUtility.MaybeDeserialize<Types.Status>(s);
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
            if (status != null)
            {
                var tf = new TootForm(_ac, status);
                tf.Show();
            }
        }

        private void pinMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var toUse = _status.ReblogOrSelf();
                var endpoint = toUse.Pinned.Coerce() ? "unpin" : "pin";
                var s = _ac.SendUrlencoded(FormatStatusRoute(endpoint), "POST", null);
                _status = JsonUtility.MaybeDeserialize<Types.Status>(s);
                pinMenuItem.Checked = _status.ReblogOrSelf().Pinned.Coerce();
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
                var s = _ac.SendUrlencoded(FormatStatusRoute(), "DELETE", null);
                Close();
            }
            catch (Exception ex)
            {
                ErrorDispatcher.ShowError(ex, "Deleting");
            }
        }
    }
}