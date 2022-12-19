namespace Common.Models.Inputs
{
    public record SampleVarianceInput(StatisticalDataWithoutFrequency[] Values, decimal SampleAverage);
}