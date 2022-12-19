using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class ModeCalculator : ICalculator<decimal, StatisticalData[]>
    {
        public decimal Calculate(StatisticalData[] value)
        {
            var mode = value.OrderBy(_ => _.Frequency).Last().Value;
            return mode;
        }
    }
}