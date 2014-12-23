using System;
using System.Collections.Generic;
using System.Linq;
using opt.Drafter.DataModel;
using opt.DataModel;

namespace opt.Drafter
{
    /// <summary>
    /// Helper, contains routines that convert <see cref="ModelDraft"/> into a normal <see cref="Model"/>
    /// </summary>
    public static class ModelDraftToModelConverter
    {
        /// <summary>
        /// Converts instance of <see cref="ModelDraft"/> into a new instance of <see cref="Model"/>
        /// </summary>
        /// <param name="modelDraft"><see cref="ModelDraft"/> instance to be converted</param>
        /// <returns>New instance of <see cref="Model"/> created based on the data from <paramref name="modelDraft"/></returns>
        public static Model Convert(ModelDraft modelDraft)
        {
            if (modelDraft == null)
            {
                throw new ArgumentNullException("modelDraft");
            }

            Model model = new Model();

            CopyParameters(modelDraft.PromotableConstants, model.Parameters);
            CopyCriteria(modelDraft.PromotableCriteria, model.Criteria);
            CopyConstraints(modelDraft.PromotableCriteria, model.FunctionalConstraints);

            return model;
        }

        private static void CopyParameters(NamedModelEntityCollection<PromotableConstant> source, NamedModelEntityCollection<Parameter> destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IEnumerable<Parameter> parameters = source.Values.Where(promotableConstant => promotableConstant.IsPromoted)
                                                             .Select(promotableConstant => promotableConstant.GetParameter());
            CopyEntities(parameters, destination);
        }

        private static void CopyCriteria(NamedModelEntityCollection<PromotableCriterion> source, NamedModelEntityCollection<Criterion> destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IEnumerable<Criterion> criteria = source.Values.Where(promotableCriterion => !promotableCriterion.IsPromoted)
                                                           .Select(promotableCriterion => promotableCriterion.GetCriterion());
            CopyEntities(criteria, destination);
        }

        private static void CopyConstraints(NamedModelEntityCollection<PromotableCriterion> source, NamedModelEntityCollection<Constraint> destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            IEnumerable<Constraint> constraints = source.Values.Where(promotableCriterion => promotableCriterion.IsPromoted)
                                                               .Select(promotableCriterion => promotableCriterion.GetConstraint());
            CopyEntities(constraints, destination);
        }

        private static void CopyEntities<TEntity>(IEnumerable<TEntity> source, NamedModelEntityCollection<TEntity> destination) where TEntity : NamedModelEntity
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            destination.Clear();
            foreach (TEntity entity in source)
            {
                destination.Add(entity);
            }
        }
    }
}