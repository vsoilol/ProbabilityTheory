using Common.Models.Inputs;

namespace Common.Calculators
{
    public class CorrectedSampleVarianceCalculator : ICalculator<decimal, CorrectedSampleVarianceInput>
    {
        /// <summary>
        /// Исправленная выборочная дисперсия
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal Calculate(CorrectedSampleVarianceInput value)
        {
            var correctedSampleVariance = (decimal)value.ValuesCount / (value.ValuesCount - 1) * value.SampleVariance;
            return correctedSampleVariance;
        }
    }
}