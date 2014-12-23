using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class CriterionExtension
    {
        public static string GetDescription(this Criterion criterion)
        {
            return "Идентификатор переменной: " + criterion.VariableIdentifier +
                   "\nТип: " + CriterionTypeManager.GetCriterionTypeName(criterion.Type) +
                   "\nВесовой коэффициент: " + criterion.Weight.ToString();
        }
    }
}