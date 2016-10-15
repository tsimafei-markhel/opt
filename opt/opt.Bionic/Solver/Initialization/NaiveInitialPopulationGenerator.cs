using System;
using opt.Bionic.DataModel;
using opt.DataModel;

namespace opt.Bionic.Solver
{
    public sealed class NaiveInitialPopulationGenerator : IInitialPopulationGenerator
    {
        private readonly Random randomizer = new Random();

        public Population GenerateInitialPopulation(uint size, NamedModelEntityCollection<Parameter> attributes)
        {
            if (attributes == null)
            {
                throw new ArgumentNullException("attributes");
            }

            Population result = new Population();
            for (uint i = 0; i < size; i++)
            {
                Individual individual = new Individual(result.GetFreeConsequentId(), 0);
                GenerateAttributeValues(individual, attributes);
                result.Add(individual);
            }

            return result;
        }

        private void GenerateAttributeValues(Individual targetIndividual, NamedModelEntityCollection<Parameter> attributes)
        {
            foreach (Parameter attribute in attributes.Values)
            {
                if (attribute == null)
                {
                    throw new ArgumentException("One of the attributes in null");
                }

                double attributeValue = attribute.MinValue +
                    randomizer.NextDouble() * (attribute.MaxValue - attribute.MinValue);
                targetIndividual.AttributeValues.Add(attribute.Id, attributeValue);
            }
        }
    }
}