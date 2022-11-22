namespace IndividualTask2.Models
{
    public record EmpiricalFunction(decimal LeftBorder, decimal RightBorder, decimal Value)
    {
        public override string ToString()
        {
            return $"Значение: {Value}, при {LeftBorder} < x <= {RightBorder}";
        }
    }
}