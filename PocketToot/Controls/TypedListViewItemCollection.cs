using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PocketToot
{
    public abstract class TypedListViewItemCollection<T> : IList<T> where T : class
    {
        IBaseListView _parent;

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

        internal TypedListViewItemCollection(IBaseListView parent)
        {
            _parent = parent;
        }

        protected virtual ListViewItem CreateListViewItem(T item)
        {
            var lvi = new ListViewItem();
            lvi.Tag = item;
            lvi.Text = item.ToString();
            return lvi;
        }

        #region IList<Status> Members

        public int IndexOf(T item)
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

        public void Insert(int index, T item)
        {
            var lvi = CreateListViewItem(item);
            BaseItems.Insert(index, lvi);
        }

        public void RemoveAt(int index)
        {
            BaseItems.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return (T)BaseItems[index].Tag;
            }
            set
            {
                var lvi = CreateListViewItem(value);
                BaseItems[index] = lvi;
            }
        }

        #endregion

        #region ICollection<Status> Members

        public void Add(T item)
        {
            var lvi = CreateListViewItem(item);
            BaseItems.Add(lvi);
        }

        public void Clear()
        {
            BaseItems.Clear();
        }

        public bool Contains(T item)
        {
            return BaseItemsEnumerable.Any(x => x.Tag == item);
        }

        public void CopyTo(T[] array, int arrayIndex)
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

        public bool Remove(T item)
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

        public IEnumerator<T> GetEnumerator()
        {
            return BaseItemsEnumerable.Select(x => (T)x.Tag).GetEnumerator();
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
