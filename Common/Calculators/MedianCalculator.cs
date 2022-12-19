using System.Linq;
using Common.Models;

namespace Common.Calculators
{
    public class MedianCalculator : ICalculator<decimal, StatisticalDataWithoutFrequency[]>
    {
        public decimal Calculate(StatisticalDataWithoutFrequency[] value)
        {
            var numbers = value.SelectMany(_ => Enumerable.Repeat(_.Value, _.Count).ToArray()).ToArray();
            
            int k;
            var numbersCount = numbers.Length;

            if (numbersCount % 2 != 0)
            {
                k = (numbersCount - 1) / 2;
                return numbers[k];
            }

            k = numbersCount / 2;
            var median = (numbers[k - 1] + numbers[k]) / (decimal)2;
            return median;
        }
    }
}