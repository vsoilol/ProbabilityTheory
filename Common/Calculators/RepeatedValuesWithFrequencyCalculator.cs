using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class RepeatedValuesWithFrequencyCalculator : ICalculator<StatisticalData[], decimal[]>
    {
        public StatisticalData[] Calculate(decimal[] value)
        {
            return value
                .OrderBy(_ => _)
                .GroupBy(_ => _)
                .Select(_ => new { Value = _.Key, Count = _.Count() })
                .Select(_ => new StatisticalData(_.Value, _.Count, _.Count / (decimal)value.Length))
                .ToArray();
        }
    }
}