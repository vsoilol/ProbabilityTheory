using System.Linq;
using Common.Calculators;
using Common.Models;
using Common.Models.Inputs;
using IndividualTask2.Models;

namespace IndividualTask2
{
    public class MathService
    {
        private readonly RepeatedValuesWithFrequencyCalculator _repeatedValuesWithFrequencyCalculator = new();

        private readonly EmpiricalFunctionCalculator _empiricalFunctionCalculator = new();
        private readonly SampleAverageCalculator _sampleAverageCalculator = new();
        private readonly SampleVarianceCalculator _sampleVarianceCalculator = new();

        private readonly SampleMeanSquareDeviationCalculator _sampleMeanSquareDeviationCalculator = new();

        private readonly CorrectedSampleVarianceCalculator _correctedSampleVarianceCalculator = new();

        private readonly CorrectedSampleMeanSquareDeviationCalculator _correctedSampleMeanSquareDeviationCalculator =
            new();

        private readonly VariationScopeCalculator _variationScopeCalculator = new();
        private readonly ModeCalculator _modeCalculator = new();
        private readonly MedianCalculator _medianCalculator = new();

        public MathData CalculateAllNeededData(decimal[] numbers)
        {
            var values = _repeatedValuesWithFrequencyCalculator.Calculate(numbers);

            /*values = new StatisticalData[]
            {
                new StatisticalData(102, 2, 0),
                new StatisticalData(104, 3, 0),
                new StatisticalData(108, 5, 0),
            };*/
            
            values = new StatisticalData[]
            {
                new StatisticalData(8, 6, 0),
                new StatisticalData(9, 3, 0),
                new StatisticalData(11, 1, 0),
            };

            /*values = new StatisticalData[]
            {
                new StatisticalData(12, 2, 0),
                new StatisticalData(14, 8, 0),
                new StatisticalData(15, 4, 0),
                new StatisticalData(16, 6, 0),
            };*/

            /*values = new StatisticalData[]
            {
                new StatisticalData(10, 2, 0),
                new StatisticalData(11, 3, 0),
                new StatisticalData(12, 4, 0),
                new StatisticalData(13, 1, 0),
            };*/

            /*values = new StatisticalData[]
            {
                new StatisticalData(1, 2, 0),
                new StatisticalData(3, 5, 0),
                new StatisticalData(4, 10, 0),
                new StatisticalData(6, 3, 0),
            };*/

            /*values = new StatisticalData[]
            {
                new StatisticalData(13, 10, 0),
                new StatisticalData(15, 20, 0),
                new StatisticalData(16, 5, 0),
                new StatisticalData(17, 15, 0),
            };*/

            /*values = new StatisticalData[]
            {
                new StatisticalData(156, 10, 0),
                new StatisticalData(160, 14, 0),
                new StatisticalData(164, 26, 0),
                new StatisticalData(168, 28, 0),
                new StatisticalData(172, 12, 0),
                new StatisticalData(176, 8, 0),
                new StatisticalData(180, 2, 0),
            };*/

            /*values = new StatisticalData[]
            {
                new StatisticalData(11, 4, 0),
                new StatisticalData(12, 19, 0),
                new StatisticalData(14, 20, 0),
                new StatisticalData(15, 7, 0),
            };*/
            
            /*values = new StatisticalData[]
            {
                new StatisticalData(14, 3, 0),
                new StatisticalData(18, 4, 0),
                new StatisticalData(19, 1, 0),
                new StatisticalData(20, 2, 0),
            };*/

            var empiricalFunctionValues = _empiricalFunctionCalculator.Calculate(values);
            var sampleAverage = _sampleAverageCalculator.Calculate(values);
            var sampleVariance = _sampleVarianceCalculator.Calculate(new SampleVarianceInput(values, sampleAverage));
            var sampleMeanSquareDeviation = _sampleMeanSquareDeviationCalculator.Calculate(sampleVariance);
            var correctedSampleVariance =
                _correctedSampleVarianceCalculator.Calculate(
                    new CorrectedSampleVarianceInput(values.Sum(_ => _.Count), sampleVariance));
            var correctedSampleMeanSquareDeviation =
                _correctedSampleMeanSquareDeviationCalculator.Calculate(correctedSampleVariance);
            var variationScope = _variationScopeCalculator.Calculate(values);
            var mode = _modeCalculator.Calculate(values);
            var median = _medianCalculator.Calculate(values);

            return new MathData
            {
                Values = values,
                EmpiricalFunctionValues = empiricalFunctionValues,
                SampleAverage = sampleAverage,
                SampleVariance = sampleVariance,
                SampleMeanSquareDeviation = sampleMeanSquareDeviation,
                CorrectedSampleVariance = correctedSampleVariance,
                CorrectedSampleMeanSquareDeviation = correctedSampleMeanSquareDeviation,
                VariationScope = variationScope,
                Mode = mode,
                Median = median
            };
        }
    }
}