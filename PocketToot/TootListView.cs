using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    // could be nicer
    public class TootListView : ListView
    {
        ColumnHeader _header;

        public TootListView()
            : base()
        {
            Items = new TootListViewItemCollection(this);

            _header = new ColumnHeader();
            Columns.Add(_header);

            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.None;
            View = View.Details;
        }

        internal ListView.ListViewItemCollection BaseItems
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

        public int ItemWidth
        {
            get
            {
                return _header.Width;
            }
            set
            {
                _header.Width = value;
            }
        }
    }
}
