
namespace opt.Units
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Do not instantiate directly, use <see cref="Unit.Unitless"/> instead</remarks>
    public sealed class Unitless : UnitBase
    {
        internal Unitless() :
            base(string.Empty, string.Empty)
        {
        }
    }
}