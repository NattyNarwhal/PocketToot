using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public interface IBaseListView
    {
        // TODO: Being an interface demands we make this member public, which
        // I don't like, but it'd require an abstract class, so...
        ListView.ListViewItemCollection BaseItems { get; }
    }
}
