using System;
using Common.Calculators;
using Common.Models.Inputs;

namespace IntervalAssessmentPracticalTask
{
    public record Task14Data(double Y, int N, int M);

    public class Task14 : ITask
    {
        private readonly IntervalEstimationByRelativeFrequencyCalculator _calculator = new();

        public void CalculateTask()
        {
            var data = new Task14Data(0.99, 250, 32);

            var result = _calculator
                .Calculate(new IntervalEstimationByRelativeFrequencyInput(data.N, data.M, data.Y));

            Console.WriteLine($"{result.LeftBorder} < p < {result.RightBorder}");
        }
    }
}