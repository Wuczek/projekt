namespace swi;

public class CalculationContext : ICalculationContext
{
    private ICalculationStrategy _strategy;

    public void SetStrategy(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public double ExecuteStrategy(double value1, double? value2)
    {
        return _strategy.Calculate(value1, value2);
    }
}
