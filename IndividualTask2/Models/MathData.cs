using System.Collections.Generic;

namespace IndividualTask2.Models
{
    public class MathData
    {
        public int[] Numbers { get; set; }
        
        public IReadOnlyList<StatisticalData> Values { get; set; }
        
        public IReadOnlyList<EmpiricalFunction> EmpiricalFunctionValues { get; set; }
        
        /// <summary>
        /// Выборочное среднее
        /// </summary>
        public decimal SampleAverage { get; set; }

        /// <summary>
        /// Выборочная дисперсия
        /// </summary>
        public decimal SampleVariance { get; set; }

        /// <summary>
        /// Выборочное среднее квадратическое отклонение
        /// </summary>
        public decimal SampleMeanSquareDeviation { get; set; }

        /// <summary>
        /// Исправленная выборочная дисперсия
        /// </summary>
        public decimal CorrectedSampleVariance { get; set; }

        /// <summary>
        /// Исправленное выборочное среднее квадратическое отклонение
        /// </summary>
        public decimal CorrectedSampleMeanSquareDeviation { get; set; }

        /// <summary>
        /// Размах вариации
        /// </summary>
        public int VariationScope { get; set; }

        /// <summary>
        /// Мода
        /// </summary>
        public decimal Mode { get; set; }

        /// <summary>
        /// Медиана
        /// </summary>
        public decimal Median { get; set; }
    }
}