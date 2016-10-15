using System.Collections.Generic;
using opt.Bionic.DataModel;
using opt.DataModel;

namespace opt.Bionic.Solver
{
    public interface IBreeder
    {
        IEnumerable<Individual> Breed(
            Population parentPopulation,
            NamedModelEntityCollection<Parameter> attributes,
            uint attributeDeviationPercent,
            uint maxIndividualDescendants,
            uint generationNumber);
    }
}