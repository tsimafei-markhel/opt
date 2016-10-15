using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using opt.DataModel;

// TODO: Add XML comments
// TODO: Search for better distance calc algorithms, naive ones may be too time and resource consuming
// TODO: Implement FindDistance(Dictionary<TId, TVal>, Dictionary<TId, TVal>, DistanceType) method and reuse it in IdealPointSolver

namespace opt.Helpers
{
    public static class DistanceHelper
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "firstPointCoordinates",
            Justification = "Will be fixed once the method is implemented")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "secondPointCoordinates",
            Justification = "Will be fixed once the method is implemented")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "distanceToCalculate",
            Justification = "Will be fixed once the method is implemented")]
        public static double FindDistance<TId, TValue>(IDictionary<TId, TValue> firstPointCoordinates, IDictionary<TId, TValue> secondPointCoordinates, DistanceType distanceToCalculate)
        {
            // TODO: Removed SuppressMessage attributes once the method is implemented
            throw new NotImplementedException();
        }

        public static double FindDistance(IList<double> firstPointCoordinates, IList<double> secondPointCoordinates, DistanceType distanceToCalculate)
        {
            if (firstPointCoordinates == null)
            {
                throw new ArgumentNullException("firstPointCoordinates");
            }

            if (secondPointCoordinates == null)
            {
                throw new ArgumentNullException("secondPointCoordinates");
            }

            if (firstPointCoordinates.Count() != secondPointCoordinates.Count())
            {
                throw new ArgumentException("Coordinate collections of both points should be the same size");
            }

            if (firstPointCoordinates.Contains(double.NaN) ||
                firstPointCoordinates.Contains(double.NegativeInfinity) ||
                firstPointCoordinates.Contains(double.PositiveInfinity))
            {
                throw new ArgumentOutOfRangeException("firstPointCoordinates", "Coordinates must be represented by valid floating point numbers");
            }

            if (secondPointCoordinates.Contains(double.NaN) ||
                secondPointCoordinates.Contains(double.NegativeInfinity) ||
                secondPointCoordinates.Contains(double.PositiveInfinity))
            {
                throw new ArgumentOutOfRangeException("secondPointCoordinates", "Coordinates must be represented by valid floating point numbers");
            }

            switch (distanceToCalculate)
            {
                case DistanceType.Euclidean:
                    return FindEuclideanDistance(firstPointCoordinates, secondPointCoordinates);

                case DistanceType.Manhattan:
                    return FindManhattanDistance(firstPointCoordinates, secondPointCoordinates);

                default:
                    throw new InvalidDataException(distanceToCalculate.ToString() + " is not supported");
            }
        }

        private static double FindEuclideanDistance(IList<double> firstPointCoordinates, IList<double> secondPointCoordinates)
        {
            double result = 0.0;
            for (int i = 0; i < firstPointCoordinates.Count(); i++)
            {
                result += Math.Pow(firstPointCoordinates[i] - secondPointCoordinates[i], 2);
            }

            return Math.Sqrt(result);
        }

        private static double FindManhattanDistance(IList<double> firstPointCoordinates, IList<double> secondPointCoordinates)
        {
            double result = 0.0;
            for (int i = 0; i < firstPointCoordinates.Count(); i++)
            {
                result += Math.Abs(firstPointCoordinates[i] - secondPointCoordinates[i]);
            }

            return result;
        }
    }
}