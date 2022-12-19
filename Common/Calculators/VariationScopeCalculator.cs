using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class VariationScopeCalculator : ICalculator<decimal, StatisticalDataWithoutFrequency[]>
    {
        public decimal Calculate(StatisticalDataWithoutFrequency[] value)
        {
            var variationScope = value.Last().Value - value[0].Value;
            return variationScope;
        }
    }
}