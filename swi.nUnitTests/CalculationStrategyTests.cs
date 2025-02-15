namespace swi.nUnitTests;

public class CalculationStrategyTests
{
    [Test]
    public void AdditionStrategy_ShouldAddTwoNumbers()
    {
        var strategy = new AdditionStrategy();
        var result = strategy.Calculate(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void SubtractionStrategy_ShouldSubtractTwoNumbers()
    {
        var strategy = new SubtractionStrategy();
        var result = strategy.Calculate(10, 3);
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void MultiplicationStrategy_ShouldMultiplyTwoNumbers()
    {
        var strategy = new MultiplicationStrategy();
        var result = strategy.Calculate(5, 6);
        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    public void SquareRootStrategy_ShouldCalculateSquareRoot()
    {
        var strategy = new SquareRootStrategy();
        var result = strategy.Calculate(16, null);
        Assert.That(result, Is.EqualTo(4));
    }
}