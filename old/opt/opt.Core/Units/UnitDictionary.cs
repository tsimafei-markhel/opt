using System;
using System.Collections.Generic;

namespace opt.Units
{
    public class UnitDictionary : Dictionary<String, IUnit>
    {
        public UnitDictionary()
        {
            // Add default one
            Add(Unit.Unitless);
        }

        public virtual void Add(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            Add(unit.Name, unit);
        }

        public virtual void Remove(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            Remove(unit.Name);
        }

        public virtual Boolean Contains(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            return ContainsKey(unit.Name);
        }
    }
}