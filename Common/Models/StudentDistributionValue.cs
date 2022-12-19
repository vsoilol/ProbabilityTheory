using System.Collections.Generic;

namespace Common.Models
{
    public record StudentDistributionValue(double Y, Dictionary<int, double> Values);
}