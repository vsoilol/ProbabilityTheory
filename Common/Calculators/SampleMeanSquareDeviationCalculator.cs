using System;

namespace Common.Calculators
{
    public class SampleMeanSquareDeviationCalculator : ICalculator<decimal, decimal>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Sample Variance</param>
        /// <returns></returns>
        public decimal Calculate(decimal value)
        {
            var sampleMeanSquareDeviation = (decimal)Math.Pow((double)value, 0.5);
            return sampleMeanSquareDeviation;
        }
    }
}