using System.Collections.Generic;
using opt.Bionic.DataModel;
using opt.DataModel;

namespace opt.Bionic.Solver
{
    public interface ISelector
    {
        IEnumerable<Individual> Select(Population population, Criterion fitnessFunction, uint selectionCap);
        Individual SelectOne(Individual first, Individual second, Criterion fitnessFunction);
    }
}