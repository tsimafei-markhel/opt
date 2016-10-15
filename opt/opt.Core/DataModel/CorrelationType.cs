
namespace opt.DataModel
{
    /// <summary>
    /// Type of the correlation between two entities
    /// </summary>
    public enum CorrelationType
    {
        /// <summary>
        /// Correlation is not significant and can be dropped
        /// </summary>
        ResultsNotSignificant,

        /// <summary>
        /// Two entities correlate
        /// </summary>
        Correlated,

        /// <summary>
        /// Weak correlation between two entities
        /// </summary>
        SignificantlyRelated
    }
}