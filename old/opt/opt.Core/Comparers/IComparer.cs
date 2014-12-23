using System;
using System.Diagnostics.CodeAnalysis;

// Putting this to the 'opt' namespace because
// it will be used across the solution - no need to add one more non-obvious using.
namespace opt
{
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes",
        Justification = "Design requires exactly three type parameters")]
    public interface IComparer<TRelation, TLeft, TRight>
    {
        Boolean Compare(TRelation relation, TLeft leftValue, TRight rightValue);
    }
}