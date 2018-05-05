using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public partial class NotificationsForm : Form
    {
        ApiClient _ac;
        long? _before, _after;

        public NotificationsForm()
        {
            InitializeComponent();
        }

        public NotificationsForm(ApiClient ac)
            : this()
        {
            _ac = ac;

            RefreshTimeline(false, null, null);
        }

        public void RefreshTimeline(bool insertAbove, long? before, long? after)
        {
            notificationListView.BeginUpdate();
            try
            {
                var page = Types.Notification.GetNotifications(_ac, before, after);

                // see FavouritesForm for logic behind this; should we use the
                // Min/Max version used by TimelineForm instead
                if (before == null && after == null)
                {
                    _before = page.Before;
                    _after = page.After;
                }
                else
                {
                    if (after != null)
                        _after = page.After;
                    if (before != null)
                        _before = page.Before;
                }

                var posWhenAbove = 0;
                foreach (var status in page.Items)
                {
                    if (insertAbove)
                        notificationListView.Items.Insert(posWhenAbove++, status);
                    else
                        notificationListView.Items.Add(status);
                }
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Loading Notifications");
            }
            finally
            {
                notificationListView.EndUpdate();
                notificationListView.ItemWidth = -1;
            }
        }

        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            Types.Notification.DismissAll(_ac);
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTimeline(true, null, _after);
        }

        private void showMoreMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTimeline(false, _before, null);
        }

        private void notificationListView_ItemActivate(object sender, EventArgs e)
        {
            var item = notificationListView.SelectedItems.FirstOrDefault();
            if (item != null)
            {
                if (item.Type == Types.Notification.FOLLOW)
                {
                    var af = new AccountForm(_ac, item.Account);
                    af.Show();
                }
                else
                {
                    var tf = new TootForm(_ac, item.Status);
                    tf.Show();
                }
            }
        }

        private void dismissSingleMenuItem_Click(object sender, EventArgs e)
        {
            var item = notificationListView.SelectedItems.FirstOrDefault();
            if (item != null)
            {
                item.Dismiss(_ac);
            }
        }
    }
}