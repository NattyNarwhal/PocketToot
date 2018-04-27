using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    // TODO: pivot this and TLV into a TypedSingleColumnListView
    public class AccountListView : SingleColumnListView, IBaseListView
    {
        public AccountListView()
            : base()
        {
            Items = new AccountListViewItemCollection(this);
        }

        // TODO: see the TODO on IBaseListView
        public ListView.ListViewItemCollection BaseItems
        {
            get
            {
                return base.Items;
            }
        }

        public new AccountListViewItemCollection Items
        {
            get;
            private set;
        }

        public IEnumerable<Types.Account> SelectedItems
        {
            get
            {
                foreach (int i in SelectedIndices)
                {
                    yield return Items[i];
                }
            }
        }
    }
}
