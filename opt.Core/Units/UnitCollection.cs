using System;
using System.Collections;
using System.Collections.Generic;

namespace opt.Units
{
    public class UnitCollection : ICollection<IUnit>
    {
        private readonly Dictionary<String, IUnit> units = new Dictionary<String, IUnit>();

        public IUnit this[String key]
        {
            get
            {
                return units[key];
            }
        }

        public Int32 Count
        {
            get { return units.Count; }
        }

        public Boolean IsReadOnly
        {
            get { return false; }
        }

        public void Add(IUnit item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            units.Add(item.Name, item);
        }

        public void Clear()
        {
            units.Clear();
        }

        public Boolean Contains(IUnit item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return units.ContainsKey(item.Name);
        }

        public void CopyTo(IUnit[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public Boolean Remove(IUnit item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return units.Remove(item.Name);
        }

        public IEnumerator<IUnit> GetEnumerator()
        {
            return units.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)units.Values).GetEnumerator();
        }
    }
}