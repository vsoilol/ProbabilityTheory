using System;
using System.Linq;
using Common.Models.Inputs;

namespace Common.Calculators
{
    public class SampleVarianceCalculator : ICalculator<decimal, SampleVarianceInput>
    {
        public decimal Calculate(SampleVarianceInput value)
        {
            var valuesCount = value.Values.Sum(_ => _.Count);
            var sampleAverageSquared = (decimal)Math.Pow((double)value.SampleAverage, 2);
            var someSum = (decimal)value.Values.Sum(_ => Math.Pow((double)_.Value, 2) * _.Count);

            var sampleVariance = (1 / (decimal)valuesCount) * someSum - sampleAverageSquared;
            return sampleVariance;
        }
    }
}