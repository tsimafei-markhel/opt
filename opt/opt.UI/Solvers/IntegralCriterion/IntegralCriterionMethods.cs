using System;

namespace opt.Solvers.IntegralCriterion
{

    public enum IntegralCriterionMethods
    {
        AdditiveCriterion,
        AdditiveCriterionWithUtilityFunction,
        MultiplicativeCriterion,
        MultiplicativeCriterionWithUtilityFunction,
        MinimaxMethod
    }

    public abstract class IntegralCriterionMethodsManager
    {
        public static string GetIntegralCriterionMethodName(IntegralCriterionMethods method)
        {
            switch (method)
            {
                case IntegralCriterionMethods.AdditiveCriterion:
                    return "Аддитивный критерий";
                case IntegralCriterionMethods.AdditiveCriterionWithUtilityFunction:
                    return "Аддитивный критерий с учетом функции полезности";
                case IntegralCriterionMethods.MultiplicativeCriterion:
                    return "Мультипликативный критерий";
                case IntegralCriterionMethods.MultiplicativeCriterionWithUtilityFunction:
                    return "Мультипликативный критерий с учетом функции полезности";
                case IntegralCriterionMethods.MinimaxMethod:
                    return "Метод минимакса";
            }

            throw new ArgumentException("Параметр 'method' метода 'opt.Classes.IntegralCriterionMethodsManager.GetIntegralCriterionMethodName' имеет недопустимое значение: " + method);
        }
    }
}