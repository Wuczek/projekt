namespace swi.nUnitTests;

public class CalculationContextTests
{
    [Test]
    public void ExecuteStrategy_ShouldUseCorrectStrategy()
    {
        var context = new CalculationContext();
        var strategy = new AdditionStrategy();
        context.SetStrategy(strategy);

        var result = context.ExecuteStrategy(10, 5);
        Assert.That(result, Is.EqualTo(15));
    }
}
