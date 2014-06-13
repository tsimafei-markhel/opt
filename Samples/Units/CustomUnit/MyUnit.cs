using opt.Units;

namespace Units.CustomUnit
{
    // UnitBase class is a good choice for deriving custom unit types from

    public class MyUnit : UnitBase, IMyUnit
    {
        public string Description { get; private set; }

        public MyUnit(string name, string symbol, string description) :
            base(name, symbol)
        {
            Description = description;
        }
    }
}