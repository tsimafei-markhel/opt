using System;

namespace opt.DataModel
{
    /// <summary>
    /// Possible types of an adequacy criterion
    /// </summary>
    public enum AdequacyCriterionType
    {
        /// <summary>
        /// User-defined residual (requires external user-provided calc module)
        /// </summary>
        /// <remarks>TBD. Low priority</remarks>
        UserDefined,

        /// <summary>
        /// (Fmath - Fexp)^2
        /// </summary>
        DifferenceInSquare,

        /// <summary>
        /// |Fmath - Fexp|
        /// </summary>
        AbsoluteDifference,

        /// <summary>
        /// |(Fmath - Fexp) / Fexp|
        /// </summary>
        AbsoluteDifferenceNormalized
    }
}