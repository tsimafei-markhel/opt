using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace opt.Units
{
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable",
        Justification = "Instances of this class are not supposed to be serialized.")]
    public class UnitConversionDictionary<TValue> : Dictionary<String, UnitConversion<TValue>>, IUnitConversionProvider<TValue>
    {
        public virtual UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            string key = BuildKey(fromUnit, toUnit);
            if (ContainsKey(key))
            {
                return this[key];
            }

            return null;
        }

        public virtual void Add(IUnit fromUnit, IUnit toUnit, UnitConversion<TValue> conversion)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            if (conversion == null)
            {
                throw new ArgumentNullException("conversion");
            }

            string key = BuildKey(fromUnit, toUnit);
            Add(key, conversion);
        }

        public virtual Boolean Contains(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            string key = BuildKey(fromUnit, toUnit);
            return ContainsKey(key);
        }

        public virtual Boolean Remove(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            string key = BuildKey(fromUnit, toUnit);
            return Remove(key);
        }

        public virtual Boolean TryGetValue(IUnit fromUnit, IUnit toUnit, out UnitConversion<TValue> conversion)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            string key = BuildKey(fromUnit, toUnit);
            return TryGetValue(key, out conversion);
        }

        protected virtual String BuildKey(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            return fromUnit.Name + toUnit.Name;
        }
    }
}