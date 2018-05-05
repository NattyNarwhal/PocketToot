using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot.Controls
{
    public class NotificationListViewItemCollection : TypedListViewItemCollection<Types.Notification>
    {
        internal NotificationListViewItemCollection(NotificationListView parent)
            : base(parent)
        {
        }

        protected override ListViewItem CreateListViewItem(Types.Notification item)
        {
            var lvi = new ListViewItem();
            lvi.Tag = item;
            switch (item.Type)
            {
                case Types.Notification.MENTION:
                    lvi.Text = string.Format("{0} mentioned you",
                        item.Account.AccountId);
                    break;
                case Types.Notification.REBLOG:
                    lvi.Text = string.Format("{0} boosted your status"
                        , item.Account.AccountId);
                    break;
                case Types.Notification.FAVOURITE:
                    lvi.Text = string.Format("{0} liked your status",
                        item.Account.AccountId);
                    break;
                case Types.Notification.FOLLOW:
                    lvi.Text = string.Format("{0} followed you",
                        item.Account.AccountId);
                    break;
                default:
                    throw new Exception("Invalid type");
            }
            return lvi;
        }
    }
}
