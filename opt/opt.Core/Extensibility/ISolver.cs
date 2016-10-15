using opt.DataModel;

// TODO: Add XML comments.

// Putting this to the 'opt' namespace (not 'opt.Extensibility') because
// it will be used across the solution - no need to add one more non-obvious using.
namespace opt
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OptimizationMethodResult Solve(Model model);
    }
}