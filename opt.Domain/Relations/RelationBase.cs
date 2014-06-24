using System;

namespace opt.Relations
{
    public abstract class RelationBase : IRelation
    {
        public String Name { get; private set; }

        public String Symbol { get; private set; }

        protected RelationBase(String name, String symbol)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol");
            }

            Name = name;
            Symbol = symbol;
        }
    }
}