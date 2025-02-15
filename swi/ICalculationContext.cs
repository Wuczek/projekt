namespace swi;

public interface ICalculationContext
{
    double ExecuteStrategy(double value1, double? value2);
    void SetStrategy(ICalculationStrategy strategy);
}