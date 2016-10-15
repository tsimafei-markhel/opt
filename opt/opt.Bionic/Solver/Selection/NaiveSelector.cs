using System;
using System.Collections.Generic;
using System.Linq;
using opt.Bionic.DataModel;
using opt.DataModel;
using opt.Helpers;

namespace opt.Bionic.Solver
{
    public sealed class NaiveSelector : ISelector
    {
        public IEnumerable<Individual> Select(Population population, Criterion fitnessFunction, uint selectionCap)
        {
            if (population == null)
            {
                throw new ArgumentNullException("population");
            }

            if (fitnessFunction == null)
            {
                throw new ArgumentNullException("fitnessFunction");
            }

            List<Individual> activeIndividuals = population.Where(ind => ind.Value.IsActive).Select(ind => ind.Value).ToList();

            if (activeIndividuals.Count <= selectionCap)
            {
                return activeIndividuals;
            }

            List<SortableDouble> sortedIndividuals = activeIndividuals.Select<Individual, SortableDouble>(
                    e => new SortableDouble() { Direction = fitnessFunction.SortDirection, Id = e.Id, Value = e.FitnessValue }
                ).ToList();
            sortedIndividuals.Sort();

            List<Individual> individuals = new List<Individual>();
            if (sortedIndividuals.Count <= selectionCap)
            {
                foreach (SortableDouble entity in sortedIndividuals)
                {
                    individuals.Add(population[entity.Id]);
                }
            }
            else
            {
                for (int i = 0; i < selectionCap; i++)
                {
                    individuals.Add(population[sortedIndividuals[i].Id]);
                }
            }

            return individuals;
        }

        public Individual SelectOne(Individual first, Individual second, Criterion fitnessFunction)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (fitnessFunction == null)
            {
                throw new ArgumentNullException("fitnessFunction");
            }

            if (double.IsNaN(first.FitnessValue))
            {
                throw new ArgumentException("Fitness value is NaN", "first");
            }

            if (double.IsNaN(second.FitnessValue))
            {
                throw new ArgumentException("Fitness value is NaN", "second");
            }

            if (double.IsInfinity(first.FitnessValue))
            {
                throw new ArgumentException("Fitness value is infinity", "first");
            }

            if (double.IsInfinity(second.FitnessValue))
            {
                throw new ArgumentException("Fitness value is infinity", "second");
            }

            bool isFirstBetter = 
                Comparer.IsFirstValueBetter(first.FitnessValue, second.FitnessValue, fitnessFunction.Type);
            return isFirstBetter ? first : second;
        }
    }
}