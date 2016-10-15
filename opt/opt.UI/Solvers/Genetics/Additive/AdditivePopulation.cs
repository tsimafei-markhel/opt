using System;

namespace opt.Solvers.Genetics.Additive
{
    public class AdditivePopulation : Population<AdditiveIndividual>
    {
        public new AdditiveIndividual this[int index]
        {
            get
            {
                if (base._units.ContainsKey(index))
                {
                    return (AdditiveIndividual)base._units[index];
                }
                else
                {
                    throw new ArgumentException("There is no unit with such number in the population");
                }
            }
        }
    }
}