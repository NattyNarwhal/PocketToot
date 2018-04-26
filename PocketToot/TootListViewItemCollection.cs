using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public class TootListViewItemCollection : IList<Types.Status>
    {
        TootListView _parent;

        ListView.ListViewItemCollection BaseItems
        {
            get
            {
                return _parent.BaseItems;
            }
        }

        IEnumerable<ListViewItem> BaseItemsEnumerable
        {
            get
            {
                return BaseItems.Cast<ListViewItem>();
            }
        }

        internal TootListViewItemCollection(TootListView parent)
        {
            _parent = parent;
        }

        static ListViewItem CreateListViewItem(Types.Status status)
        {
            var lvi = new ListViewItem();
            lvi.Tag = status;
            var toUse = status.ReblogOrSelf();
            var title = string.IsNullOrEmpty(toUse.ContentWarning)
                ? HtmlUtility.ToPlainText(toUse.Content)
                : "CW: " + toUse.ContentWarning;
            lvi.Text = string.Format("{0}{1}: {2}",
                status.Reblog != null ? "RT " : "",
                toUse.Account.AccountId,
                title);
            return lvi;
        }

        #region IList<Status> Members

        public int IndexOf(PocketToot.Types.Status item)
        {
            try
            {
                var lvi = BaseItemsEnumerable.Where(x => x.Tag == item).First();
                return BaseItems.IndexOf(lvi);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Insert(int index, PocketToot.Types.Status item)
        {
            var lvi = CreateListViewItem(item);
            BaseItems.Insert(index, lvi);
        }

        public void RemoveAt(int index)
        {
            BaseItems.RemoveAt(index);
        }

        public PocketToot.Types.Status this[int index]
        {
            get
            {
                return (Types.Status)BaseItems[index].Tag;
            }
            set
            {
                var lvi = CreateListViewItem(value);
                BaseItems[index] = lvi;
            }
        }

        #endregion

        #region ICollection<Status> Members

        public void Add(PocketToot.Types.Status item)
        {
            var lvi = CreateListViewItem(item);
            BaseItems.Add(lvi);
        }

        public void Clear()
        {
            BaseItems.Clear();
        }

        public bool Contains(PocketToot.Types.Status item)
        {
            return BaseItemsEnumerable.Any(x => x.Tag == item);
        }

        public void CopyTo(PocketToot.Types.Status[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return BaseItems.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(PocketToot.Types.Status item)
        {
            try
            {
                var lvi = BaseItemsEnumerable.Where(x => x.Tag == item).FirstOrDefault();
                if (lvi != null)
                {
                    BaseItems.Remove(lvi);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region IEnumerable<Status> Members

        public IEnumerator<PocketToot.Types.Status> GetEnumerator()
        {
            return BaseItemsEnumerable.Select(x => (Types.Status)x.Tag).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
