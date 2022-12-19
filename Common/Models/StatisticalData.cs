namespace Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Value">Значение из таблицы</param>
    /// <param name="Count">Сколько раз данное значение встречается в ряде</param>
    /// <param name="Frequency">Относительная частота</param>
    public record StatisticalData(decimal Value, int Count, decimal Frequency) : StatisticalDataWithoutFrequency(Value, Count);
}