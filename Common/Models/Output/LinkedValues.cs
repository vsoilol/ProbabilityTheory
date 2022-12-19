namespace Common.Models.Output
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SampleAverage">Выборочное среднее</param>
    /// <param name="SampleMeanSquareDeviation">Выборочное среднее квадратическое отклонение</param>
    /// <param name="CorrectedSampleVariance">Исправленная выборочная дисперсия</param>
    /// <param name="CorrectedSampleMeanSquareDeviation">Исправленное выборочное среднее квадратическое отклонение</param>
    /// <param name="SampleVariance">Выборочная дисперсия</param>
    public record LinkedValues(decimal SampleAverage, decimal SampleMeanSquareDeviation,
        decimal CorrectedSampleVariance, decimal CorrectedSampleMeanSquareDeviation, decimal SampleVariance);
}