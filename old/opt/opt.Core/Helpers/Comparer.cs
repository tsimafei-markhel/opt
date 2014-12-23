using System;
using opt.DataModel;

namespace opt.Helpers
{
    /// <summary>
    /// Helper class, contains methods for comparing various values
    /// </summary>
    public static class Comparer
    {
        /// <summary>
        /// Checks whether <paramref name="firstValue"/> of the criterion is better than <paramref name="secondValue"/>
        /// of the same criterion with regard to the type of this criterion
        /// </summary>
        /// <param name="firstValue">First criterion value</param>
        /// <param name="secondValue">Second criterion value</param>
        /// <param name="criterionType">Type of this criterion</param>
        /// <returns>True if criterion is minimizing and <paramref name="firstValue"/> is lesser than <paramref name="secondValue"/> OR
        /// if criterion is maximizing and <paramref name="firstValue"/> is greater than <paramref name="secondValue"/></returns>
        public static bool IsFirstValueBetter(double firstValue, double secondValue, CriterionType criterionType)
        {
            switch (criterionType)
            {
                case CriterionType.Minimizing:
                    if (firstValue < secondValue)
                    {
                        return true;
                    }

                    break;

                case CriterionType.Maximizing:
                    if (firstValue > secondValue)
                    {
                        return true;
                    }

                    break;

                default:
                    throw new ArgumentException("Invalid criterion type");
            }

            return false;
        }

        /// <summary>
        /// Compares two <see cref="Double"/> values with regard to specified relation
        /// </summary>
        /// <param name="leftValue">Left value of an inequality</param>
        /// <param name="rightValue">Right value of an inequality</param>
        /// <param name="relation">Relation between <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// that should be checked</param>
        /// <returns>True if <paramref name="leftValue"/>, <paramref name="relation"/> and <paramref name="rightValue"/>
        /// form correct inequality (e.g. 3 >= 2)</returns>
        public static bool CompareValuesWithSign(double leftValue, double rightValue, Relation relation)
        {
            switch (relation)
            {
                case Relation.Equal:
                    if (Math.Abs(leftValue - rightValue) < double.Epsilon)
                    {
                        return true;
                    }

                    break;

                case Relation.Greater:
                    if (leftValue > rightValue)
                    {
                        return true;
                    }

                    break;

                case Relation.GreaterOrEqual:
                    if (leftValue >= rightValue)
                    {
                        return true;
                    }

                    break;

                case Relation.Less:
                    if (leftValue < rightValue)
                    {
                        return true;
                    }

                    break;

                case Relation.LessOrEqual:
                    if (leftValue <= rightValue)
                    {
                        return true;
                    }

                    break;

                case Relation.NotEqual:
                    if (Math.Abs(leftValue - rightValue) >= double.Epsilon)
                    {
                        return true;
                    }

                    break;

                default:
                    throw new ArgumentException("Unknown sign!");
            }

            return false;
        }
    }
}