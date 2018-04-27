using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public class AttachmentListViewItemCollection : TypedListViewItemCollection<Types.Attachment>
    {
        internal AttachmentListViewItemCollection(AttachmentListView parent)
            : base(parent)
        {
        }

        protected override System.Windows.Forms.ListViewItem CreateListViewItem(PocketToot.Types.Attachment item)
        {
            var url = string.IsNullOrEmpty(item.LocalUrl) ? item.RemoteUrl : item.LocalUrl;
            var text = string.IsNullOrEmpty(item.Description) ? url : item.Description;
            var lvi = new ListViewItem(text);
            lvi.Tag = item;
            switch (item.Type.ToLower())
            {
                case "image":
                    lvi.ImageIndex = 1;
                    break;
                case "gifv":
                case "video":
                    lvi.ImageIndex = 2;
                    break;
                case "unknown":
                default:
                    lvi.ImageIndex = 0;
                    break;
            }
            return lvi;
        }
    }
}
