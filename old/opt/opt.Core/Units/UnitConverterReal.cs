using System;

namespace opt.Units
{
    public class UnitConverterReal : UnitConverterBase<Real>
    {
        public UnitConverterReal(Int32 capacity) :
            base(capacity)
        {
        }

        public UnitConverterReal() :
            this(0)
        {
        }
    }
}