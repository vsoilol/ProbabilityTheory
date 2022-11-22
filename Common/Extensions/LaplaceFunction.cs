using System;
using MathNet.Numerics.Integration;

namespace Common.Extensions
{
    public class LaplaceFunction
    {
        public static decimal Calculate(double t)
        {
            double integralResult = SimpsonRule.IntegrateComposite(x => Math.Exp(-Math.Pow(x, 2) / 2), 0.0, t, 1000);
            decimal result = (decimal)integralResult / (decimal)Math.Pow(2 * Math.PI, 0.5);
            return result;
        }
    }
}