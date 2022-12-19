using System;

namespace Common.Calculators
{
    public class CorrectedSampleMeanSquareDeviationCalculator : ICalculator<decimal, decimal>
    {
        /// <summary>
        /// Исправленное выборочное среднее квадратическое отклонение
        /// </summary>
        /// <param name="value">Corrected Sample Variance (Исправленная выборочная дисперсия)</param>
        /// <returns></returns>
        public decimal Calculate(decimal value)
        {
            var correctedSampleMeanSquareDeviation = (decimal)Math.Pow((double)value, 0.5);
            return correctedSampleMeanSquareDeviation;
        }
    }
}