namespace Common.Models.Inputs
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="N">Общее число испытаний</param>
    /// <param name="M">Число появлений события</param>
    /// <param name="Y">Заданная надёжность</param>
    public record IntervalEstimationByRelativeFrequencyInput(int N, int M, double Y);
}