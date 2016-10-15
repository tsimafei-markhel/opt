using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers
{
    /// <summary>
    /// Mapping <see cref="AdequacyCriterionTypes"/> types and their associated set of delegated methods of solution
    /// </summary>
    /// <remarks>Implements Singleton pattern</remarks>
    /// <example>double result = ResidualCriterionsSolver.Instance[AdequacyCriterionType.SomeMethod](fMath, fExp);</example>
    public sealed class ResidualFunctionRegistry
    {
        /// <summary>
        /// Collection of solvers
        /// </summary>
        private readonly Dictionary<AdequacyCriterionType, Func<double, double, double>> solvers;

        private static ResidualFunctionRegistry instance;
        private static object syncRoot = new object();

        /// <summary>
        /// Gets solver function by adequacy criterion type
        /// </summary>
        /// <param name="key"><see cref="AdequacyCriterionType"/></param>
        /// <returns>Solver for the specified criterion type</returns>
        public Func<double, double, double> this[AdequacyCriterionType key]
        {
            get
            {
                return solvers[key];
            }
        }

        private ResidualFunctionRegistry()
        {
            solvers = new Dictionary<AdequacyCriterionType, Func<double, double, double>>();
            solvers.Add(AdequacyCriterionType.DifferenceInSquare, DifferenceInSquare);
            solvers.Add(AdequacyCriterionType.AbsoluteDifference, AbsoluteDifference);
            solvers.Add(AdequacyCriterionType.AbsoluteDifferenceNormalized, AbsoluteDifferenceNormalized);

            // TODO: Handle user-defined residual type properly
            solvers.Add(AdequacyCriterionType.UserDefined, null);
        }

        /// <summary>
        /// Gets instance of <see cref="ResidualFunctionRegistry"/>
        /// </summary>
        public static ResidualFunctionRegistry Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ResidualFunctionRegistry();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Calculate residual by (<paramref name="fMath"/> - <paramref name="fExp"/>)^2
        /// </summary>
        /// <returns>Calculated value</returns>
        private double DifferenceInSquare(double fMath, double fExp)
        {
            return Math.Pow(fMath - fExp, 2);
        }

        /// <summary>
        /// Calculate residual by |<paramref name="fMath"/> - <paramref name="fExp"/>|
        /// </summary>
        /// <returns>Calculated value</returns>
        private double AbsoluteDifference(double fMath, double fExp)
        {
            return Math.Abs(fMath - fExp);
        }

        /// <summary>
        /// Calculate residual by |(<paramref name="fMath"/> - <paramref name="fExp"/>) / <paramref name="fExp"/>|
        /// </summary>
        /// <returns>Calculated value</returns>
        /// <exception cref="ArgumentException">If <paramref name="fExp"/> equals 0</exception>
        private double AbsoluteDifferenceNormalized(double fMath, double fExp)
        {
            if (Math.Abs(0.0 - fExp) <= Double.Epsilon)
            {
                throw new ArgumentException("Experimental criterion value is 0. Please consider choosing another residual type.");
            }

            return Math.Abs((fMath - fExp) / fExp);
        }

    }
}