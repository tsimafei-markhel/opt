using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opt.Units
{
    public interface IUnitConverter<TValue>
    {
        TValue Convert(IUnit fromUnit, IUnit toUnit, TValue value);
    }
}