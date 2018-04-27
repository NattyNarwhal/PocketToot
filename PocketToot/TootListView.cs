using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    // could be nicer
    public class TootListView : SingleColumnListView, IBaseListView
    {
        public TootListView()
            : base()
        {
            Items = new TootListViewItemCollection(this);
        }

        // TODO: see the TODO on IBaseListView
        public ListView.ListViewItemCollection BaseItems
        {
            get
            {
                return base.Items;
            }
        }

        public new TootListViewItemCollection Items
        {
            get;
            private set;
        }

        public IEnumerable<Types.Status> SelectedItems
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
