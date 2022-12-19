using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class SampleAverageCalculator : ICalculator<decimal, StatisticalDataWithoutFrequency[]>
    {
        public decimal Calculate(StatisticalDataWithoutFrequency[] value)
        {
            var valuesCount = value.Sum(_ => _.Count);
            var sampleAverage = (1 / (decimal)valuesCount) * value.Sum(_ => _.Count * _.Value);
            return sampleAverage;
        }
    }
}