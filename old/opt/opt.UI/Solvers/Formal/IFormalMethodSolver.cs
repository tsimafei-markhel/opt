using opt.DataModel;

namespace opt.Solvers.Formal
{
    public interface IFormalMethodSolver
    {
        FormalMethodResult FindDecision(Model model);
    }
}