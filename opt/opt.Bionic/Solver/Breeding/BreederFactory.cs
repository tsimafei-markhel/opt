
namespace opt.Bionic.Solver
{
    public static class BreederFactory
    {
        public static IBreeder CreateBreeder()
        {
            // Here be some logic on choosing and instantiating Breeders
            // For now, let's use naive breeder
            return new NaiveBreeder();
        }
    }
}