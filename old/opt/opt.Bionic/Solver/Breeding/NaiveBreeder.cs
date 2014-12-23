using System;
using System.Collections.Generic;
using System.Linq;
using opt.Bionic.DataModel;
using opt.Bionic.Helpers;
using opt.DataModel;

namespace opt.Bionic.Solver
{
    public sealed class NaiveBreeder : IBreeder
    {
        private readonly Random randomizer = new Random();

        public IEnumerable<Individual> Breed(
            Population parentPopulation,
            NamedModelEntityCollection<Parameter> attributes,
            uint attributeDeviationPercent,
            uint maxIndividualDescendants,
            uint generationNumber)
        {
            if (parentPopulation == null)
            {
                throw new ArgumentNullException("parentPopulation");
            }

            if (attributes == null)
            {
                throw new ArgumentNullException("attributes");
            }

            if (parentPopulation.Count == 0)
            {
                throw new ArgumentException("Parent population is empty, nothing to breed", "parentPopulation");
            }

            List<Individual> activeParents = parentPopulation.Where(ind => ind.Value.IsActive).Select(ind => ind.Value).ToList();
            if (activeParents.Count == 0)
            {
                throw new ArgumentException("No active individuals in parent population, nothing to breed", "parentPopulation");
            }

            List<Individual> descendants = new List<Individual>();
            // Need descendant counter for unique ID generation - BAD HACK
            int descendantsCount = 0;
            foreach (Individual parent in activeParents)
            {
                for (int i = 0; i < maxIndividualDescendants; i++)
                {
                    // TODO: Find a better way to assign new IDs to the descendants.
                    // Current 'descendantsCount' reveals int nature of the ID, which is bad
                    Individual descendant = CreateDescendant(parent, parentPopulation.GetFreeConsequentId() + descendantsCount, generationNumber, attributes, attributeDeviationPercent);
                    descendants.Add(descendant);

                    descendantsCount++;
                }
            }

            return descendants;
        }

        private Individual CreateDescendant(
            Individual parent,
            TId descendantId,
            uint generationNumber,
            NamedModelEntityCollection<Parameter> attributes,
            uint attributeDeviationPercent)
        {
            Individual descendant = new Individual(descendantId, generationNumber);
            foreach (Parameter attribute in attributes.Values)
            {
                descendant.AttributeValues.Add(attribute.Id, 
                    CreateAttributeValue(attribute, parent.AttributeValues[attribute.Id], attributeDeviationPercent));
            }

            return descendant;
        }

        private double CreateAttributeValue(Parameter attribute, double parentAttributeValue, uint attributeDeviationPercent)
        {
            Range attributeRange = RangeFactory.CreateRangeWithRestriction(parentAttributeValue, attributeDeviationPercent, attribute.MinValue, attribute.MaxValue);
            return attributeRange.MinValue + randomizer.NextDouble() * attributeRange.Length;
        }
    }
}