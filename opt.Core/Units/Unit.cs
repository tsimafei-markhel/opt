using System;
using System.Collections.Generic;

namespace opt.Units
{
    public class Unit : UnitBase
    {
        public ICollection<IPrefixedUnit> PrefixedUnits { get; private set; }

        public Unit(string name, string symbol) :
            base(name, symbol)
        {
            PrefixedUnits = new List<IPrefixedUnit>();
        }
    }
}