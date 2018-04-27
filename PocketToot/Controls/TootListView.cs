using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    // could be nicer
    public class TootListView : TypedSingleColumnListView<Types.Status>
    {
        public TootListView()
            : base()
        {
            Items = new TootListViewItemCollection(this);
        }
    }
}
