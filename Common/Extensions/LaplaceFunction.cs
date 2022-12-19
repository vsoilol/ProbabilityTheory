using System;
using MathNet.Numerics.Integration;

namespace Common.Extensions
{
    public class LaplaceFunction
    {
        public static decimal Calculate(decimal t)
        {
            double integralResult = SimpsonRule.IntegrateComposite(x => Math.Exp(-Math.Pow(x, 2) / 2), 0.0, (double)t, 1000);
            decimal result = (decimal)integralResult / (decimal)Math.Pow(2 * Math.PI, 0.5);
            return result;
        }

        public static decimal GetFunctionArgument(decimal functionValue, decimal step = 0.01m)
        {
            var t = 0.0m;
            var currentFunctionValue = Calculate(t);
            t += step;
            var nextFunctionValue = Calculate(t);

            while (functionValue >= nextFunctionValue || functionValue <= currentFunctionValue)
            {
                currentFunctionValue = nextFunctionValue;
                t += step;
                nextFunctionValue = Calculate(t);
            }

            return t;
        }
    }
}