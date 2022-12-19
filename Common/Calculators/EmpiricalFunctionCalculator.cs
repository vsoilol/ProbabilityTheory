using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class EmpiricalFunctionCalculator : ICalculator<EmpiricalFunction[], StatisticalData[]>
    {
        public EmpiricalFunction[] Calculate(StatisticalData[] value)
        {
            return value
                .Take(value.Length - 1)
                .Select((_, index) =>
                    new EmpiricalFunction(value[index].Value, value[index + 1].Value,
                        value.Take(index + 1).Sum(math => math.Frequency))).ToArray();
        }
    }
}