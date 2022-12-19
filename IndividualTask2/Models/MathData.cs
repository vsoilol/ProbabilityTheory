using System.Collections.Generic;
using Common.Models;

namespace IndividualTask2.Models
{
    public class MathData
    {
        public StatisticalData[] Values { get; init; }
        
        public EmpiricalFunction[] EmpiricalFunctionValues { get; init; }
        
        /// <summary>
        /// Выборочное среднее
        /// </summary>
        public decimal SampleAverage { get; init; }

        /// <summary>
        /// Выборочная дисперсия
        /// </summary>
        public decimal SampleVariance { get; init; }

        /// <summary>
        /// Выборочное среднее квадратическое отклонение
        /// </summary>
        public decimal SampleMeanSquareDeviation { get; init; }

        /// <summary>
        /// Исправленная выборочная дисперсия
        /// </summary>
        public decimal CorrectedSampleVariance { get; init; }

        /// <summary>
        /// Исправленное выборочное среднее квадратическое отклонение
        /// </summary>
        public decimal CorrectedSampleMeanSquareDeviation { get; init; }

        /// <summary>
        /// Размах вариации
        /// </summary>
        public decimal VariationScope { get; init; }

        /// <summary>
        /// Мода
        /// </summary>
        public decimal Mode { get; init; }

        /// <summary>
        /// Медиана
        /// </summary>
        public decimal Median { get; init; }
    }
}