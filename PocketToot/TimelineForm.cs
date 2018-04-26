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
        string _timelineRoute;

        // TODO: move these and others
        const string HOME_TIMELINE_ROUTE = "/api/v1/timelines/home";
        const string PUBLIC_TIMELINE_ROUTE = "/api/v1/timelines/public";
        public const string TAG_TIMELINE_ROUTE_PREFIX = "/api/v1/timelines/tag/";

        // init for designer/app launch
        public TimelineForm()
        {
            InitializeComponent();

            var hostname = Settings.GetSetting("InstanceHostname", "");
            var token = Settings.GetSetting("InstanceToken", "");

            _ac = new ApiClient(hostname, token);

            SetTimeline(HOME_TIMELINE_ROUTE, "Home Timeline");
        }

        // init for tag/other timelines
        public TimelineForm(ApiClient client, string route, string title)
        {
            InitializeComponent();

            _ac = client;

            SetTimeline(route, title);
        }

        // TODO: we should keep track of open windows to avoid getting a nest
        // of home/public timeline windows open... and perhaps keep the only
        // HTL window as the root one to avoid confusion
        protected void SetTimeline(string route, string title)
        {
            Text = title;
            _timelineRoute = route;

            if (route == PUBLIC_TIMELINE_ROUTE)
            {
                publicTimelineMenuItem.Checked = true;
                publicTimelineMenuItem.Enabled = false;
            }
            else if (route.StartsWith(TAG_TIMELINE_ROUTE_PREFIX))
            {
                tagTimelineMenuItem.Checked = true;
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

            RefreshTimeline();
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

        public void RefreshTimeline()
        {
            // TODO: some smart algorithm where we can splice in new statuses

            statusListView.BeginUpdate();

            try
            {
                var s = _ac.Get(_timelineRoute);
                var sl = JsonUtility.MaybeDeserialize<List<Types.Status>>(s);

                statusListView.Items.Clear();

                foreach (var status in sl)
                {
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

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTimeline();
        }

        public void ShowSettings()
        {
            var sf = new SettingsForm(_ac);
            sf.ShowDialog();
            // load new settings
            _ac.Hostname = Settings.GetSetting("InstanceHostname", "");
            _ac.Token = Settings.GetSetting("InstanceToken", "");
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
            var tf = new TimelineForm(_ac, PUBLIC_TIMELINE_ROUTE, "Federated Timeline");
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
                var tagRoute = string.Format("{0}{1}",
                    TAG_TIMELINE_ROUTE_PREFIX,
                    QueryString.EscapeUriDataStringRfc3986(tag));
                var tf = new TimelineForm(_ac, tagRoute, "#" + tag);
                tf.Show();
            }
        }
    }
}