using System;

namespace opt.Solvers.Formal
{
    public enum FormalMethods
    {
        MaximalPower,
        IdealPoint,
        BinaryRelations
    }

    public static class FormalMethodsManager
    {
        public static string GetFormalMethodName(FormalMethods method)
        {
            switch (method)
            {
                case FormalMethods.BinaryRelations:
                    return "Метод бинарных отношений";

                case FormalMethods.IdealPoint:
                    return "Поиск точки с минимальным удалением от идеальной";

                case FormalMethods.MaximalPower:
                    return "Поиск точки с максимальной мощностью";

                default:
                    throw new ArgumentException("Параметр 'method' метода 'opt.Classes.FormalMethodsManager.GetFormalMethodName' имеет недопустимое значение: " + method);
            }
        }
    }
}