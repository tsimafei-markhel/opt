using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opt.Bionic.Helpers
{
    // TODO: Add various interfaces (see TId, for example), move to opt.Core,
    // reuse in Parameter
    public struct Range
    {
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public double Length { get; private set; }

        public Range(double minValue, double maxValue) : this()
        {
            if (double.IsNaN(minValue))
            {
                throw new ArgumentOutOfRangeException("minValue", "Value is NaN");
            }

            if (double.IsNaN(maxValue))
            {
                throw new ArgumentOutOfRangeException("maxValue", "Value is NaN");
            }

            // TODO: Think over handling 'min == max' case and ZeroRange
            if (minValue > maxValue)
            {
                throw new ArgumentException("Min value cannot be greater than max value");
            }

            MinValue = minValue;
            MaxValue = maxValue;
            Length = MaxValue - MinValue;
        }
    }

    public static class RangeFactory
    {
        public static Range CreateRange(double rangeMean, uint deviationPercent)
        {
            double min = double.NaN;
            double max = double.NaN;
            double deviationInterval = deviationPercent / 100.0;

            if (rangeMean >= 0)
            {
                min = rangeMean - deviationInterval * rangeMean;
                max = rangeMean + deviationInterval * rangeMean;
            }
            else
            {
                min = rangeMean + deviationInterval * rangeMean;
                max = rangeMean - deviationInterval * rangeMean;
            }

            return new Range(min, max);
        }

        public static Range CreateRangeWithRestriction(double rangeMean, uint deviationPercent, double allowedMin, double allowedMax)
        {
            double suggestedMin = double.NaN;
            double suggestedMax = double.NaN;
            double deviationInterval = deviationPercent / 100.0;

            if (rangeMean >= 0)
            {
                suggestedMin = rangeMean - deviationInterval * rangeMean;
                suggestedMax = rangeMean + deviationInterval * rangeMean;
            }
            else
            {
                suggestedMin = rangeMean + deviationInterval * rangeMean;
                suggestedMax = rangeMean - deviationInterval * rangeMean;
            }

            double realMin = suggestedMin;
            if (suggestedMin < allowedMin)
            {
                realMin = allowedMin;
            }

            double realMax = suggestedMax;
            if (suggestedMax > allowedMax)
            {
                realMax = allowedMax;
            }

            return new Range(realMin, realMax);
        }
    }
}