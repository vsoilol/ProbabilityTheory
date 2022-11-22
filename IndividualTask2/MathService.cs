using System;
using System.Collections.Generic;
using System.Linq;
using IndividualTask2.Models;

namespace IndividualTask2
{
    public class MathService
    {
        //private MathData _mathData;

        public MathData CalculateAllNeededData(int[] numbers)
        {
            MathData _mathData = new MathData
            {
                Numbers = numbers.OrderBy(_ => _).ToArray()
            };
            
            _mathData.Values = CalculateStatisticalData(numbers);
            /*_mathData.Values = new StatisticalData[]
            {
                new StatisticalData(-0.5m, 1, 0),
                new StatisticalData(-0.4m, 2, 0),
                new StatisticalData(-0.2m, 1, 0),
                new StatisticalData(0, 1, 0),
                new StatisticalData(0.2m, 1, 0),
                new StatisticalData(0.6m, 1, 0),
                new StatisticalData(0.8m, 1, 0),
                new StatisticalData(1, 1, 0),
                new StatisticalData(1.2m, 2, 0),
                new StatisticalData(1.5m, 1, 0),
            };*/

            var length = _mathData.Values.Sum(_ => _.Count);
            
            _mathData.EmpiricalFunctionValues = CalculateMathFunctionValues(_mathData.Values);
            _mathData.SampleAverage = CalculateSampleAverage(length, _mathData.Values);
            _mathData.SampleVariance =
                CalculateSampleVariance(length, _mathData.Values, _mathData.SampleAverage);
            _mathData.SampleMeanSquareDeviation = CalculateSampleMeanSquareDeviation(_mathData.SampleVariance);
            _mathData.CorrectedSampleVariance =
                CalculateCorrectedSampleVariance(length, _mathData.SampleVariance);
            _mathData.CorrectedSampleMeanSquareDeviation =
                CalculateCorrectedSampleMeanSquareDeviation(_mathData.CorrectedSampleVariance);
            
            _mathData.VariationScope = CalculateVariationScope(_mathData.Numbers);
            _mathData.Mode = CalculateMode(_mathData.Values);
            _mathData.Median = CalculateMedian(_mathData.Numbers);
            return _mathData;
        }

        private IReadOnlyList<StatisticalData> CalculateStatisticalData(int[] numbers)
        {
            return numbers
                .OrderBy(_ => _)
                .GroupBy(_ => _)
                .Select(_ => new { Value = _.Key, Count = _.Count() })
                .Select(_ => new StatisticalData(_.Value, _.Count, _.Count / (decimal)100))
                .ToList();
        }

        private IReadOnlyList<EmpiricalFunction> CalculateMathFunctionValues(IReadOnlyList<StatisticalData> values)
        {
            return values
                .Take(values.Count - 1)
                .Select((_, index) =>
                    new EmpiricalFunction(values[index].Value, values[index + 1].Value,
                        values.Take(index + 1).Sum(math => math.Frequency))).ToList();
        }

        private decimal CalculateSampleAverage(int valuesCount, IReadOnlyList<StatisticalData> values)
        {
            var sampleAverage = (1 / (decimal)valuesCount) * values.Sum(_ => _.Count * _.Value);
            return sampleAverage;
        }

        private decimal CalculateSampleVariance(int valuesCount, IReadOnlyList<StatisticalData> values,
            decimal sampleAverage)
        {
            var sampleAverageSquared = (decimal)Math.Pow((double)sampleAverage, 2);
            var someSum = (decimal)values.Sum(_ => Math.Pow((double)_.Value, 2) * _.Count);

            var sampleVariance = (1 / (decimal)valuesCount) * someSum - sampleAverageSquared;
            return sampleVariance;
        }

        private decimal CalculateSampleMeanSquareDeviation(decimal sampleVariance)
        {
            var sampleMeanSquareDeviation = (decimal)Math.Pow((double)sampleVariance, 0.5);
            return sampleMeanSquareDeviation;
        }

        private decimal CalculateCorrectedSampleVariance(int valuesCount, decimal sampleVariance)
        {
            var correctedSampleVariance = (decimal)valuesCount / (valuesCount - 1) * sampleVariance;
            return correctedSampleVariance;
        }

        private decimal CalculateCorrectedSampleMeanSquareDeviation(decimal correctedSampleVariance)
        {
            var correctedSampleMeanSquareDeviation = (decimal)Math.Pow((double)correctedSampleVariance, 0.5);
            return correctedSampleMeanSquareDeviation;
        }

        private int CalculateVariationScope(int[] numbers)
        {
            var variationScope = numbers.Last() - numbers[0];
            return variationScope;
        }

        private decimal CalculateMode(IReadOnlyList<StatisticalData> values)
        {
            var mode = values.OrderBy(_ => _.Frequency).Last().Value;
            return mode;
        }

        private decimal CalculateMedian(int[] numbers)
        {
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