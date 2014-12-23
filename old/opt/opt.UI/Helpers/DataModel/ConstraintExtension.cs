using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class ConstraintExtension
    {
        public static string GetDescription(this Constraint constraint)
        {
            return "Идентификатор переменной: " + constraint.VariableIdentifier +
                   "\nЗнак: " + RelationManager.GetRelationName(constraint.ConstraintRelation) +
                   "\nЗначение: " + constraint.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
        }
    }
}