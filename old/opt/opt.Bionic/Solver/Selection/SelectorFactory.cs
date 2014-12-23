
namespace opt.Bionic.Solver
{
    public static class SelectorFactory
    {
        public static ISelector CreateSelector()
        {
            // Here be some logic on choosing and instantiating Selectors
            // For now, let's use naive selector
            return new NaiveSelector();
        }
    }
}