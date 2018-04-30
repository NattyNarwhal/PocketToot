using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace PocketToot
{
    public partial class TimelineForm : Form
    {
        ApiClient _ac;
        TimelineType _type;
        string _tagName;
        long? _before, _after;

        // init for designer/app launch (special because of special init)
        public TimelineForm()
        {
            InitializeComponent();

            var hostname = Settings.GetSetting("InstanceHostname", "");
            var token = Settings.GetSetting("InstanceToken", "");

            _ac = new ApiClient(hostname, token);

            SetTimeline(TimelineType.Home);
        }

        // init for tag/other timelines
        public TimelineForm(ApiClient client, TimelineType type)
        {
            InitializeComponent();

            _ac = client;

            SetTimeline(type);
        }

        public TimelineForm(ApiClient client, string tagName)
        {
            InitializeComponent();

            _ac = client;
            _tagName = tagName;

            SetTimeline(TimelineType.Tag);
        }

        // TODO: we should keep track of open windows to avoid getting a nest
        // of home/public timeline windows open... and perhaps keep the only
        // HTL window as the root one to avoid confusion
        // TODO: should be a property? tag case though
        protected void SetTimeline(TimelineType type)
        {
            _type = type;
            switch (type)
            {
                case TimelineType.Home:
                    Text = "Home Timeline";
                    break;
                case TimelineType.Local:
                    Text = "Local Timeline";
                    break;
                case TimelineType.Federated:
                    Text = "Federated Timeline";
                    break;
                case TimelineType.Tag:
                    Text = "#" + _tagName;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            while (string.IsNullOrEmpty(_ac.Hostname) || string.IsNullOrEmpty(_ac.Token))
            {
                ShowSettings();
                _ac.Hostname = Settings.GetSetting("InstanceHostname", "");
                _ac.Token = Settings.GetSetting("InstanceToken", "");
            }

            RefreshTimeline(true, false, null, null);
            statusListView.Focus();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var status = statusListView.SelectedItems.SingleOrDefault();
            if (status != null)
            {
                var tf = new TootForm(_ac, status);
                tf.Show();
            }
        }

        public void RefreshTimeline(bool clear, bool insertAbove, long? before, long? after)
        {
            statusListView.BeginUpdate();

            try
            {
                Paginated<Types.Status> page = null;

                switch (_type)
                {
                    case TimelineType.Home:
                        page = TimelineUtils.GetHomeTimeline(_ac, before, after);
                        break;
                    case TimelineType.Local:
                        page = TimelineUtils.GetPublicTimeline(_ac, true, false, before, after);
                        break;
                    case TimelineType.Federated:
                        page = TimelineUtils.GetPublicTimeline(_ac, false, false, before, after);
                        break;
                    case TimelineType.Tag:
                        page = Types.Tag.GetTimeline(_ac, _tagName, false, false, before, after);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                // TODO: handle cases where we can't just stretch IDs (like favs)
                if (_before.HasValue && page.Before.HasValue)
                    _before = Math.Min(_before.Value, page.Before.Value);
                else if (page.Before.HasValue)
                    _before = page.Before.Value;

                if (_after.HasValue && page.After.HasValue)
                    _after = Math.Max(_after.Value, page.After.Value);
                else if (page.After.HasValue)
                    _after = page.After.Value;

                if (clear)
                    statusListView.Items.Clear();

                var posWhenAbove = 0;
                foreach (var status in page.Items)
                {
                    if (insertAbove)
                        statusListView.Items.Insert(posWhenAbove++, status);
                    else
                        statusListView.Items.Add(status);
                }
            }
            catch (Exception e)
            {
                // let dispatch handle it
                ErrorDispatcher.ShowError(e, "Refreshing Timeline");
            }
            finally
            {
                statusListView.EndUpdate();
                ResizeColumn();
            }
        }

        public void ShowMore()
        {
            if (statusListView.Items.Count == 0)
            {
                RefreshTimeline(true, false, null, null);
                return;
            }

            RefreshTimeline(false, false, _before, null);
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            // this menu item now just pulls in new and doesnt replace
            if (statusListView.Items.Count == 0)
            {
                RefreshTimeline(true, false, null, null);
                return;
            }

            RefreshTimeline(false, true, null, _after);
        }

        public void ShowSettings()
        {
            var sf = new SettingsForm(_ac);
            sf.ShowDialog();
            // load new settings directly relevant to us
            _ac.Hostname = Settings.GetSetting("InstanceHostname", "");
            _ac.Token = Settings.GetSetting("InstanceToken", "");
            // we needed something to disambiguate with
            if (sf.DialogResult == DialogResult.Ignore)
            {
                try
                {
                    //var authorRoute = "/api/v1/accounts/search?q=calvin%40cronk.stenoweb.net";
                    //var authorJson = _ac.Get(authorRoute);
                    //var author = JsonUtility.MaybeDeserialize<List<Types.Account>>(authorJson).FirstOrDefault();
                    //if (author != null)
                    //{
                    //    var af = new AccountForm(_ac, author);
                    //    af.Show();
                    //}
                }
                catch (Exception e)
                {
                    ErrorDispatcher.ShowError(e, "Showing Author");
                }
            }
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        public void ResizeColumn()
        {
            statusListView.ItemWidth = -1;
        }

        private void composeMenuItem_Click(object sender, EventArgs e)
        {
            var cf = new ComposeForm(_ac);
            cf.Show();
        }

        private void publicTimelineMenuItem_Click(object sender, EventArgs e)
        {
            var tf = new TimelineForm(_ac, TimelineType.Federated);
            tf.Show();
        }

        private void localPublicTumelineMenuItem_Click(object sender, EventArgs e)
        {
            var tf = new TimelineForm(_ac, TimelineType.Local);
            tf.Show();
        }

        private void tagTimelineMenuItem_Click(object sender, EventArgs e)
        {
            var tag = Microsoft.VisualBasic.Interaction
                .InputBox("Enter a hashtag's name.",
                "View Hashtag Timeline", "", 0, 0);

            tag = tag.Trim().TrimStart('#').Trim();

            if (!string.IsNullOrEmpty(tag))
            {
                var tf = new TimelineForm(_ac, tag);
                tf.Show();
            }
        }

        private void showMoreMenuItem_Click(object sender, EventArgs e)
        {
            ShowMore();
        }
    }
}