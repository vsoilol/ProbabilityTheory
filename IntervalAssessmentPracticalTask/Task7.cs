using System;
using Common.Calculators;
using Common.Extensions;
using Common.Models;

namespace IntervalAssessmentPracticalTask
{
    public record Task7Data(int N, double Y, StatisticalDataWithoutFrequency[] Values);

    public class Task7 : ITask
    {
        private readonly LinkedValuesCalculator _linkedValuesCalculator = new();

        public void CalculateTask()
        {
            var data = GetData();

            var t = StudentDistribution.GetFunctionValue(data.Y, data.N);

            var linkedValues = _linkedValuesCalculator.Calculate(data.Values);
            var sampleAverage = linkedValues.SampleAverage;
            var correctedSampleMeanSquareDeviation = linkedValues.CorrectedSampleMeanSquareDeviation;

            var temp = (decimal)t * correctedSampleMeanSquareDeviation / (decimal)Math.Pow(data.N, 0.5);

            Console.WriteLine($"{sampleAverage - temp} < a < {sampleAverage + temp}");
        }

        private Task7Data GetData()
        {
            var n = 12;
            var y = 0.95;
            var values = new StatisticalDataWithoutFrequency[]
            {
                new(-0.5m, 1),
                new(-0.4m, 2),
                new(-0.2m, 1),
                new(0, 1),
                new(0.2m, 1),
                new(0.6m, 1),
                new(0.8m, 1),
                new(1, 1),
                new(1.2m, 2),
                new(1.5m, 1),
            };

            return new Task7Data(n, y, values);
        }
    }
}