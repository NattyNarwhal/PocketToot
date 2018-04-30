using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public class TootListViewItemCollection : TypedListViewItemCollection<Types.Status>
    {
        internal TootListViewItemCollection(TootListView parent)
            : base(parent)
        {
        }

        protected override ListViewItem CreateListViewItem(PocketToot.Types.Status item)
        {
            var lvi = new ListViewItem();
            lvi.Tag = item;
            var toUse = item.ReblogOrSelf();
            var title = string.IsNullOrEmpty(toUse.ContentWarning)
                ? HtmlUtility.ToPlainText(toUse.Content)
                : "CW: " + toUse.ContentWarning;
            lvi.Text = string.Format("{0}{1}: {2}",
                item.ContainedReblog != null ? "RT " : "",
                toUse.Account.AccountId,
                title);
            return lvi;
        }
    }
}
