using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PocketToot
{
    public class AccountListViewItemCollection: TypedListViewItemCollection<Types.Account>
    {
        internal AccountListViewItemCollection(AccountListView parent)
            : base(parent)
        {
        }
    }
}
