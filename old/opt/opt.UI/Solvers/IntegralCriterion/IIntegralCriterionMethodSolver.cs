using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.IntegralCriterion
{
    public interface IIntegralCriterionMethodSolver
    {
        IntegralCriterionMethodResult FindDecision(Model model);

        IntegralCriterionMethodResult FindDecisionWithUtilityFunction(
            Model model,
            Dictionary<TId, UtilityFunction> uFunctions);
    }
}