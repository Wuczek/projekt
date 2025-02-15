namespace swi;

public interface ICalculationStrategy
{
    double Calculate(double value1, double? value2);
    string GetOperator();
}
