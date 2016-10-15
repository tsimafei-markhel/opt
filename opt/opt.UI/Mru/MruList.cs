using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace opt.UI.Mru
{
    internal sealed class MruList : IMruList
    {
        private Queue<MruItem> items;
        private int maxItems;

        public event Action<IMruList> Changed;

        public MruList(int maxItemsCount)
        {
            if (maxItemsCount < 1)
            {
                throw new ArgumentOutOfRangeException("maxItemsCount");
            }

            maxItems = maxItemsCount;
            items = new Queue<MruItem>(maxItemsCount);
        }

        public void Push(MruItem item, bool suppressChangedEvent)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (string.IsNullOrEmpty(item.FileName))
            {
                throw new ArgumentException("Incomplete MRU list item data.", "item");
            }

            items.Enqueue(item);
            if (items.Count > maxItems)
            {
                items.Dequeue();
            }

            if (!suppressChangedEvent)
            {
                OnChanged();
            }
        }

        public void Push(MruItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (string.IsNullOrEmpty(item.FileName))
            {
                throw new ArgumentException("Incomplete MRU list item data.", "item");
            }

            Push(item, false);
        }

        public void Clear()
        {
            items.Clear();

            OnChanged();
        }

        public void PruneObsolete()
        {
            Queue<MruItem> newItems = new Queue<MruItem>(maxItems);
            foreach (MruItem item in items)
            {
                if (File.Exists(item.FileName))
                {
                    newItems.Enqueue(item);
                }
            }

            items.Clear();
            items = newItems;

            OnChanged();
        }

        private void OnChanged()
        {
            Action<IMruList> temp = Changed;
            if (temp != null)
            {
                temp(this);
            }
        }

        public IEnumerator<MruItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}