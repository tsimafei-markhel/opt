using opt.Bionic.DataModel;
using opt.DataModel;

namespace opt.Bionic.Solver
{
    public interface IInitialPopulationGenerator
    {
        Population GenerateInitialPopulation(uint size, NamedModelEntityCollection<Parameter> attributes);
    }
}