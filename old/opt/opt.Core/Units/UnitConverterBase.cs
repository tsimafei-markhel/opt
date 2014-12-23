using System;
using System.Collections.Generic;

namespace opt.Units
{
    public abstract class UnitConverterBase<TValue>
    {
        protected readonly Dictionary<String, Func<IUnit, IUnit, TValue, TValue>> converters;

        protected UnitConverterBase(Int32 capacity)
        {
            converters = new Dictionary<string, Func<IUnit, IUnit, TValue, TValue>>(capacity);
        }

        protected UnitConverterBase() :
            this(0)
        {
        }

        public virtual void Add(IUnit from, IUnit to, Func<IUnit, IUnit, TValue, TValue> predicate)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            string key = ComputeKey(from, to);
            converters.Add(key, predicate);
        }

        public virtual void Remove(IUnit from, IUnit to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            string key = ComputeKey(from, to);
            converters.Remove(key);
        }

        public virtual Boolean Contains(IUnit from, IUnit to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            string key = ComputeKey(from, to);
            return converters.ContainsKey(key);
        }

        public virtual void Clear()
        {
            converters.Clear();
        }

        public virtual TValue Convert(IUnit from, IUnit to, TValue valueToConvert)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            string key = ComputeKey(from, to);
            Func<IUnit, IUnit, TValue, TValue> predicate = converters[key];
            return predicate(from, to, valueToConvert);
        }

        protected virtual String ComputeKey(IUnit from, IUnit to)
        {
            return from.Name + to.Name;
        }
    }
}