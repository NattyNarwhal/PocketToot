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
    public partial class FavouritesForm : Form
    {
        ApiClient _ac;
        long? _before, _after;

        public FavouritesForm()
        {
            InitializeComponent();
        }

        public FavouritesForm(ApiClient ac)
            : this()
        {
            _ac = ac;

            RefreshTimeline(false, null, null);
        }

        public void RefreshTimeline(bool insertAbove, long? before, long? after)
        {
            statusListView.BeginUpdate();
            try
            {
                var page = TimelineUtils.GetFavourites(_ac, before, after);

                //Text = string.Format("Current {0} {1} Page {2} {3}",
                //    _before ?? -1, _after ?? -1, page.Before ?? -1, page.After ?? -1);

                // the logic here goes: set initial ones, then because IDs seem
                // to be non-linear, only bump before if we're using before (et
                // vice versa) - this way, the other one isn't overwritten by
                // a lesser/greater value due to pagination logic
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
                        statusListView.Items.Insert(posWhenAbove++, status);
                    else
                        statusListView.Items.Add(status);
                }
            }
            catch (Exception e)
            {
                ErrorDispatcher.ShowError(e, "Loading Favourites");
            }
            finally
            {
                statusListView.EndUpdate();
                statusListView.ItemWidth = -1;
            }
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTimeline(true, null, _after);
        }

        private void showMoreMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTimeline(false, _before, null);
        }

        private void unfavMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var s in statusListView.SelectedItems)
            {
                try
                {
                    s.Unfavourite(_ac);
                    statusListView.Items.Remove(s);
                }
                catch (Exception ex)
                {
                    ErrorDispatcher.ShowError(ex, "Unfavouriting");
                }
            }
        }
    }
}