using System;
using System.Collections.Generic;
using opt.DataModel;
using opt.DataModel.New;

// TODO: Add XML comments.

// Putting this to the 'opt' namespace because
// it will be used across the solution - no need to add one more non-obvious using.
namespace opt
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParameterGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="valueCount"></param>
        /// <returns></returns>
        IEnumerable<RealValueDictionary> GenerateParameterValues(ParameterDictionary parameters, Int32 valueCount);
    }
}