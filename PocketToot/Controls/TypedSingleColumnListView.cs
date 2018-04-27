using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public abstract class TypedSingleColumnListView<TType, TCollection> : SingleColumnListView, IBaseListView
        where TType : class
        where TCollection : TypedListViewItemCollection<TType>
    {
        public TypedSingleColumnListView()
            : base()
        {
            // Child must set Items
        }

        // TODO: see the TODO on IBaseListView
        public ListView.ListViewItemCollection BaseItems
        {
            get
            {
                return base.Items;
            }
        }

        public new TCollection Items
        {
            get;
            protected set;
        }

        public IEnumerable<TType> SelectedItems
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
