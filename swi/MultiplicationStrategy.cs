namespace swi;

public class MultiplicationStrategy : ICalculationStrategy
{
    public double Calculate(double value1, double? value2) => value1 * value2.GetValueOrDefault();
    public string GetOperator() => "mul";

}
