namespace swi;

public class SquareRootStrategy : ICalculationStrategy
{
    public double Calculate(double value1, double? value2) => Math.Sqrt(value1);
    public string GetOperator() => "sqrt";

}
