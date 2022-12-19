using System;
using Common.Extensions;
using Common.Models.Inputs;
using Common.Models.Output;

namespace Common.Calculators
{
    /// <summary>
    /// Оценка вероятности биномиального распределения по относительной частоте
    /// </summary>
    public class IntervalEstimationByRelativeFrequencyCalculator :
        ICalculator<IntervalEstimation, IntervalEstimationByRelativeFrequencyInput>
    {
        public IntervalEstimation Calculate(IntervalEstimationByRelativeFrequencyInput value)
        {
            var t = LaplaceFunction.GetFunctionArgument((decimal)value.Y / 2);
            var w = value.M / (double)value.N;

            return value.N > 100
                ? CalculateWhenMoreThenHundred(value.N, t, w)
                : CalculateWhenLessThenHundred(value.N, t, w);
        }

        private IntervalEstimation CalculateWhenLessThenHundred(int n, decimal t, double w)
        {
            var onePart = n / (Math.Pow((double)t, 2) + n);
            var secondPart = (double)t * Math.Pow(w * (1 - w) / n + Math.Pow((double)t / (2 * n), 2), 0.5);

            var p1 = (decimal)(onePart * (Math.Pow(w, 2) + (Math.Pow((double)t, 2) / (2 * n)) - secondPart));
            var p2 = (decimal)(onePart * (Math.Pow(w, 2) + (Math.Pow((double)t, 2) / (2 * n)) + secondPart));

            return new IntervalEstimation(p1, p2);
        }

        private IntervalEstimation CalculateWhenMoreThenHundred(int n, decimal t, double w)
        {
            var onePart = t * (decimal)Math.Pow((double)(w * (1 - w) / n), 0.5);

            var p1 = (decimal)w - onePart;
            var p2 = (decimal)w + onePart;

            return new IntervalEstimation(p1, p2);
        }
    }
}