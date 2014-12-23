using System;
using opt.DataModel;

namespace opt.Drafter.DataModel
{
    /// <summary>
    /// Represents a storage for object model entities. Is used to generate OPT model 
    /// of an object by promoting some of the constants to parameters and promoting 
    /// some of the criteria to constraints
    /// </summary>
    public sealed class ModelDraft : ICloneable
    {
        /// <summary>
        /// Gets a collection of <see cref="PromotableConstant"/>
        /// </summary>
        public NamedModelEntityCollection<PromotableConstant> PromotableConstants { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="PromotableCriterion"/>
        /// </summary>
        public NamedModelEntityCollection<PromotableCriterion> PromotableCriteria { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="ModelDraft"/>
        /// </summary>
        public ModelDraft()
        {
            PromotableConstants = new NamedModelEntityCollection<PromotableConstant>();
            PromotableCriteria = new NamedModelEntityCollection<PromotableCriterion>();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ModelDraft"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            return new ModelDraft()
            {
                PromotableConstants = (NamedModelEntityCollection<PromotableConstant>)PromotableConstants.Clone(),
                PromotableCriteria = (NamedModelEntityCollection<PromotableCriterion>)PromotableCriteria.Clone(),
            };
        }
    }
}