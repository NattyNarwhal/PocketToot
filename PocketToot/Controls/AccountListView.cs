using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public class AccountListView : TypedSingleColumnListView<Types.Account>
    {
        public AccountListView()
            : base()
        {
            Items = new AccountListViewItemCollection(this);
        }
    }
}
