using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    // not abstract; it would be useful on its own
    public class SingleColumnListView : ListView
    {
        ColumnHeader _header;

        public SingleColumnListView()
            : base()
        {
            _header = new ColumnHeader();
            Columns.Add(_header);

            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.None;
            View = View.Details;
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
