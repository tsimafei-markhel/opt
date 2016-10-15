using System;
using System.Collections.Generic;
using System.Linq;
using opt.DataModel;

// TODO: Add XML comments
// TODO: Review algorithm
// TODO: Exception text???

namespace opt.Helpers
{
    public static class LinearCorrelationHelper
    {
        private static readonly Dictionary<int, Dictionary<double, double>> significanceTable = new Dictionary<int, Dictionary<double, double>>()
            {
                {1, new Dictionary<double, double>()   { {0.10, 0.988}, {0.05, 0.997}, {0.02, 0.9995}, {0.01, 0.9999}, {0.001, 0.99999}}},
                {2, new Dictionary<double, double>()   { {0.10, 0.900}, {0.05, 0.950}, {0.02, 0.980},  {0.01, 0.990},  {0.001, 0.999}}},
                {3, new Dictionary<double, double>()   { {0.10, 0.805}, {0.05, 0.878}, {0.02, 0.934},  {0.01, 0.959},  {0.001, 0.991}}},
                {4, new Dictionary<double, double>()   { {0.10, 0.729}, {0.05, 0.811}, {0.02, 0.882},  {0.01, 0.971},  {0.001, 0.974}}},
                {5, new Dictionary<double, double>()   { {0.10, 0.669}, {0.05, 0.755}, {0.02, 0.833},  {0.01, 0.875},  {0.001, 0.951}}},
                {6, new Dictionary<double, double>()   { {0.10, 0.621}, {0.05, 0.707}, {0.02, 0.789},  {0.01, 0.834},  {0.001, 0.928}}},
                {7, new Dictionary<double, double>()   { {0.10, 0.582}, {0.05, 0.666}, {0.02, 0.750},  {0.01, 0.798},  {0.001, 0.898}}},
                {8, new Dictionary<double, double>()   { {0.10, 0.549}, {0.05, 0.632}, {0.02, 0.715},  {0.01, 0.765},  {0.001, 0.872}}},
                {9, new Dictionary<double, double>()   { {0.10, 0.521}, {0.05, 0.602}, {0.02, 0.685},  {0.01, 0.735},  {0.001, 0.847}}},
                {10, new Dictionary<double, double>()  { {0.10, 0.497}, {0.05, 0.576}, {0.02, 0.658},  {0.01, 0.708},  {0.001, 0.823}}},
                {11, new Dictionary<double, double>()  { {0.10, 0.476}, {0.05, 0.553}, {0.02, 0.634},  {0.01, 0.684},  {0.001, 0.801}}},
                {12, new Dictionary<double, double>()  { {0.10, 0.457}, {0.05, 0.532}, {0.02, 0.612},  {0.01, 0.661},  {0.001, 0.780}}},
                {13, new Dictionary<double, double>()  { {0.10, 0.441}, {0.05, 0.514}, {0.02, 0.592},  {0.01, 0.641},  {0.001, 0.760}}},
                {14, new Dictionary<double, double>()  { {0.10, 0.426}, {0.05, 0.497}, {0.02, 0.574},  {0.01, 0.623},  {0.001, 0.742}}},
                {15, new Dictionary<double, double>()  { {0.10, 0.412}, {0.05, 0.482}, {0.02, 0.558},  {0.01, 0.606},  {0.001, 0.725}}},
                {16, new Dictionary<double, double>()  { {0.10, 0.400}, {0.05, 0.468}, {0.02, 0.542},  {0.01, 0.590},  {0.001, 0.708}}},
                {17, new Dictionary<double, double>()  { {0.10, 0.389}, {0.05, 0.456}, {0.02, 0.529},  {0.01, 0.575},  {0.001, 0.693}}},
                {18, new Dictionary<double, double>()  { {0.10, 0.378}, {0.05, 0.444}, {0.02, 0.515},  {0.01, 0.561},  {0.001, 0.679}}},
                {19, new Dictionary<double, double>()  { {0.10, 0.369}, {0.05, 0.433}, {0.02, 0.503},  {0.01, 0.549},  {0.001, 0.665}}},
                {20, new Dictionary<double, double>()  { {0.10, 0.360}, {0.05, 0.423}, {0.02, 0.492},  {0.01, 0.537},  {0.001, 0.652}}},
                {21, new Dictionary<double, double>()  { {0.10, 0.352}, {0.05, 0.413}, {0.02, 0.482},  {0.01, 0.526},  {0.001, 0.640}}},
                {22, new Dictionary<double, double>()  { {0.10, 0.344}, {0.05, 0.404}, {0.02, 0.472},  {0.01, 0.515},  {0.001, 0.629}}},
                {23, new Dictionary<double, double>()  { {0.10, 0.337}, {0.05, 0.396}, {0.02, 0.462},  {0.01, 0.505},  {0.001, 0.618}}},
                {24, new Dictionary<double, double>()  { {0.10, 0.330}, {0.05, 0.388}, {0.02, 0.453},  {0.01, 0.496},  {0.001, 0.607}}},
                {25, new Dictionary<double, double>()  { {0.10, 0.323}, {0.05, 0.381}, {0.02, 0.445},  {0.01, 0.487},  {0.001, 0.597}}},
                {26, new Dictionary<double, double>()  { {0.10, 0.317}, {0.05, 0.374}, {0.02, 0.437},  {0.01, 0.479},  {0.001, 0.588}}},
                {27, new Dictionary<double, double>()  { {0.10, 0.311}, {0.05, 0.367}, {0.02, 0.430},  {0.01, 0.471},  {0.001, 0.579}}},
                {28, new Dictionary<double, double>()  { {0.10, 0.306}, {0.05, 0.361}, {0.02, 0.423},  {0.01, 0.463},  {0.001, 0.570}}},
                {29, new Dictionary<double, double>()  { {0.10, 0.301}, {0.05, 0.355}, {0.02, 0.416},  {0.01, 0.459},  {0.001, 0.562}}},
                {30, new Dictionary<double, double>()  { {0.10, 0.296}, {0.05, 0.349}, {0.02, 0.409},  {0.01, 0.449},  {0.001, 0.554}}},
                {40, new Dictionary<double, double>()  { {0.10, 0.257}, {0.05, 0.304}, {0.02, 0.358},  {0.01, 0.393},  {0.001, 0.490}}},
                {60, new Dictionary<double, double>()  { {0.10, 0.211}, {0.05, 0.250}, {0.02, 0.295},  {0.01, 0.325},  {0.001, 0.408}}},
                {120, new Dictionary<double, double>() { {0.10, 0.150}, {0.05, 0.178}, {0.02, 0.210},  {0.01, 0.232},  {0.001, 0.294}}},
                // All other values greater than 120:
                {121, new Dictionary<double, double>() { {0.10, 0.073}, {0.05, 0.087}, {0.02, 0.103},  {0.01, 0.114},  {0.001, 0.146}}}
            };

        public static Dictionary<TId, List<double>> FindCorrelationCoefficients(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.Criteria == null ||
                model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            if (model.Criteria.Count < 2)
            {
                throw new InvalidOperationException();
            }

            int activeExperimentsCount = model.Experiments.CountActiveExperiments();
            if (activeExperimentsCount < 3)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<Experiment> activeExperiments = model.Experiments.Values.Where(e => e.IsActive);

            Dictionary<TId, double> criterionMeans = new Dictionary<TId, double>(model.Criteria.Count);
            foreach (Criterion criterion in model.Criteria.Values)
            {
                double sum = Convert.ToDouble(activeExperiments.Sum(experiment => experiment.CriterionValues[criterion.Id]));
                criterionMeans[criterion.Id] = sum / activeExperimentsCount;
            }

            Dictionary<TId, List<double>> correlationCoefficients = new Dictionary<TId, List<double>>(model.Criteria.Count);
            foreach (Criterion firstCriterion in model.Criteria.Values)
            {
                correlationCoefficients[firstCriterion.Id] = new List<double>(model.Criteria.Count);
                foreach (Criterion secondCriterion in model.Criteria.Values)
                {
                    if (firstCriterion.Id == secondCriterion.Id)
                    {
                        correlationCoefficients[firstCriterion.Id].Add(1.0);
                    }
                    else
                    {
                        double covariance = 0.0;
                        double firstCriterionVariance = 0.0;
                        double secondCriterionVariance = 0.0;
                        foreach (Experiment experiment in activeExperiments)
                        {
                            double firstCriterionDifference = experiment.CriterionValues[firstCriterion.Id] - criterionMeans[firstCriterion.Id];
                            double secondCriterionDifference = experiment.CriterionValues[secondCriterion.Id] - criterionMeans[secondCriterion.Id];
                            covariance += firstCriterionDifference * secondCriterionDifference;
                            firstCriterionVariance += Math.Pow(firstCriterionDifference, 2);
                            secondCriterionVariance += Math.Pow(secondCriterionDifference, 2);
                        }

                        try
                        {
                            correlationCoefficients[firstCriterion.Id].Add(Math.Round(covariance / Math.Sqrt(firstCriterionVariance * secondCriterionVariance), 3, MidpointRounding.AwayFromZero));
                        }
                        catch (DivideByZeroException)
                        {
                            throw new ArgumentException("Не удалось вычислить коэффициент корреляции для критериев " + firstCriterion.Name + " и " + secondCriterion.Name + ". Деление на ноль");
                        }
                    }
                }
            }

            return correlationCoefficients;
        }

        public static Dictionary<TId, List<CorrelationType>> DetermineCorrelationSignificances(Model model, Dictionary<TId, List<double>> correlationCoefficients)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.Criteria == null ||
                model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            if (correlationCoefficients == null)
            {
                throw new ArgumentNullException("correlationCoefficients");
            }

            int activeExperimentsCount = model.Experiments.CountActiveExperiments();
            if (activeExperimentsCount < 3)
            {
                throw new InvalidOperationException();
            }

            Dictionary<TId, List<CorrelationType>> correlationSignificances = new Dictionary<TId, List<CorrelationType>>(model.Criteria.Count);
            Dictionary<double, double> significanceRow = FindSignificanceRow(activeExperimentsCount - 2);

            foreach (KeyValuePair<TId, List<double>> correlationRow in correlationCoefficients)
            {
                correlationSignificances[correlationRow.Key] = new List<CorrelationType>(model.Criteria.Count);
                for (int i = 0; i < correlationRow.Value.Count; i++)
                {
                    double actualCoefficient = correlationRow.Value[i];
                    double pValue = 0.0;
                    foreach (KeyValuePair<double, double> significance in significanceRow)
                    {
                        if (significance.Value >= actualCoefficient)
                        {
                            pValue = significance.Key;
                            break;
                        }
                    }

                    CorrelationType correlationType = CorrelationType.Correlated;
                    if (pValue >= 0.1)
                    {
                        correlationType = CorrelationType.ResultsNotSignificant;
                    }
                    else if (pValue < 0.1 && pValue > 0.001)
                    {
                        correlationType = CorrelationType.Correlated;
                    }
                    else if (pValue <= 0.001)
                    {
                        correlationType = CorrelationType.SignificantlyRelated;
                    }

                    correlationSignificances[correlationRow.Key].Add(correlationType);
                }
            }

            return correlationSignificances;
        }

        // TODO: Add linear interpolation
        private static Dictionary<double, double> FindSignificanceRow(int degreesOfFreedom)
        {
            if (degreesOfFreedom < 1)
            {
                throw new ArgumentOutOfRangeException("degreesOfFreedom");
            }

            if (significanceTable.ContainsKey(degreesOfFreedom))
            {
                return significanceTable[degreesOfFreedom];
            }

            if (degreesOfFreedom > 30 && degreesOfFreedom <= 40)
            {
                return significanceTable[40];
            }
            else if (degreesOfFreedom > 40 && degreesOfFreedom <= 60)
            {
                return significanceTable[60];
            }
            else if (degreesOfFreedom > 60 && degreesOfFreedom <= 120)
            {
                return significanceTable[120];
            }
            else
            {
                return significanceTable.Last().Value;
            }
        }
    }
}