using System;
using System.Collections.Generic;

namespace opt.Units
{
    public class Unit : UnitBase
    {
        public ICollection<IPrefixedUnit> PrefixedUnits { get; private set; }

        public Unit(String name, String symbol) :
            base(name, symbol)
        {
            PrefixedUnits = new List<IPrefixedUnit>();
        }
    }
}