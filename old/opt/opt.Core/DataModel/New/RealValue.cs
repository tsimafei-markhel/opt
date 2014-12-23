using System;
using opt.Units;

namespace opt.DataModel.New
{
    [Serializable]
    public class RealValue : IValue<Real, IUnit>
    {
        public Real Value { get; private set; }
        public IUnit Unit { get; private set; }

        public RealValue(Real value, IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            Value = value;
            Unit = unit;
        }

        public RealValue(Real value) :
            this(value, opt.Units.Unit.Unitless)
        {
        }

        public virtual Object MemberwiseClone()
        {
            return new RealValue(Value, Unit);
        }
    }
}