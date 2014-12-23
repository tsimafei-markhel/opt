using System.Diagnostics.CodeAnalysis;

namespace opt.DataModel
{
    /// <summary>
    /// Possible relation between some entity and its value
    /// </summary>
    public enum Relation
    {
        /// <summary>
        /// ==
        /// </summary>
        Equal,

        /// <summary>
        /// &lt;
        /// </summary>
        Less,

        /// <summary>
        /// &gt;
        /// </summary>
        Greater,

        /// <summary>
        /// &gt;=
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// &lt;=
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "LessOr",
            Justification = "Correct math sign name is 'less'")]
        LessOrEqual,

        /// <summary>
        /// !=
        /// </summary>
        NotEqual
    }
}