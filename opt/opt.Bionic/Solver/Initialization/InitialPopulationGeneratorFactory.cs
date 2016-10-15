
namespace opt.Bionic.Solver
{
    public static class InitialPopulationGeneratorFactory
    {
        public static IInitialPopulationGenerator CreateInitialPopulationGenerator()
        {
            // Here be some logic on choosing and instantiating Initial Population Generators
            // For now, let's use naive generator
            return new NaiveInitialPopulationGenerator();
        }
    }
}