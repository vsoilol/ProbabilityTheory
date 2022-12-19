using System.Linq;
using Common.Models;
using Common.Models.Inputs;
using Common.Models.Output;

namespace Common.Calculators
{
    public class LinkedValuesCalculator : ICalculator<LinkedValues, StatisticalDataWithoutFrequency[]>
    {
        private readonly SampleAverageCalculator _sampleAverageCalculator = new();
        private readonly SampleVarianceCalculator _sampleVarianceCalculator = new();
        private readonly SampleMeanSquareDeviationCalculator _sampleMeanSquareDeviationCalculator = new();
        private readonly CorrectedSampleVarianceCalculator _correctedSampleVarianceCalculator = new();

        private readonly CorrectedSampleMeanSquareDeviationCalculator _correctedSampleMeanSquareDeviationCalculator =
            new();

        public LinkedValues Calculate(StatisticalDataWithoutFrequency[] value)
        {
            var valuesCount = value.Sum(_ => _.Count);
            var sampleAverage = _sampleAverageCalculator.Calculate(value);
            var sampleVariance = _sampleVarianceCalculator.Calculate(new SampleVarianceInput(value, sampleAverage));
            var sampleMeanSquareDeviation = _sampleMeanSquareDeviationCalculator.Calculate(sampleVariance);
            var correctedSampleVariance = _correctedSampleVarianceCalculator
                .Calculate(new CorrectedSampleVarianceInput(valuesCount, sampleVariance));
            var correctedSampleMeanSquareDeviation = _correctedSampleMeanSquareDeviationCalculator
                .Calculate(correctedSampleVariance);

            return new LinkedValues(sampleAverage, sampleMeanSquareDeviation, correctedSampleVariance,
                correctedSampleMeanSquareDeviation, sampleVariance);
        }
    }
}