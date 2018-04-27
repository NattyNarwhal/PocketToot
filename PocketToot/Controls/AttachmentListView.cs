using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public class AttachmentListView : TypedSingleColumnListView<Types.Attachment>
    {
        public AttachmentListView()
            : base()
        {
            Items = new AttachmentListViewItemCollection(this);
        }

        // HACK: We can't put this in ctor or VS crashes hard
        public void SetUpImageList()
        {
            var _sil = new ImageList();
            _sil.Images.Add(Properties.Resources.AttachmentUnknown);
            _sil.Images.Add(Properties.Resources.AttachmentPicture);
            _sil.Images.Add(Properties.Resources.AttachmentVideo);
            SmallImageList = _sil;
        }
    }
}
