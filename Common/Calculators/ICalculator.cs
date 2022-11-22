namespace Common.Calculators
{
    public interface ICalculator<out T, in TR>
    {
        T Calculate(TR value);
    }
}