using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot.Controls
{
    public class NotificationListView : TypedSingleColumnListView<Types.Notification>
    {
        public NotificationListView()
            : base()
        {
            Items = new NotificationListViewItemCollection(this);
        }
    }
}
