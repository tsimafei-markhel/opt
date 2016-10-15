using System.Data;
using opt.DataModel;

// TODO: Add XML comments.

// Putting this to the 'opt' namespace (not 'opt.Extensibility') because
// it will be used across the solution - no need to add one more non-obvious using.
namespace opt
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResultTableFiller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="optimizationResult"></param>
        /// <returns></returns>
        DataTable FillDataTable(Model model, OptimizationMethodResult optimizationResult);
    }
}