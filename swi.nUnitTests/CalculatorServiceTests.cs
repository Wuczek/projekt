using Moq;

namespace swi.nUnitTests;

public class CalculatorServiceTests
{
    private Mock<IFileReader> _fileReaderMock;
    private Mock<IFileWriter> _fileWriterMock;
    private Mock<ICalculationContext> _contextMock;
    private Dictionary<string, ICalculationStrategy> _strategies;

    [SetUp]
    public void Setup()
    {
        _fileReaderMock = new Mock<IFileReader>();
        _fileWriterMock = new Mock<IFileWriter>();
        _contextMock = new Mock<ICalculationContext>();

        _strategies = new Dictionary<string, ICalculationStrategy>
        {
            { "add", new AdditionStrategy() },
            { "sub", new SubtractionStrategy() },
            { "mul", new MultiplicationStrategy() },
            { "sqrt", new SquareRootStrategy() }
        };
    }

    [Test]
    public void Run_ShouldProcessOperationsCorrectly()
    {
        var inputFilePath = "input.json";
        var outputFilePath = "output.txt";

        var operations = new Dictionary<string, CalculationRequest>
            {
                { "obj1", new CalculationRequest("add", 2, 3) },
                { "obj2", new CalculationRequest("mul", 2, 5) }
            };

        _fileReaderMock.Setup(fr => fr.ReadJson(inputFilePath)).Returns(operations);
        _contextMock.Setup(c => c.ExecuteStrategy(2, 3)).Returns(5);
        _contextMock.Setup(c => c.ExecuteStrategy(2, 5)).Returns(10);

        var service = new CalculatorService(_fileReaderMock.Object, _fileWriterMock.Object, _contextMock.Object, _strategies.Values);

        service.Run(inputFilePath, outputFilePath);

        _fileWriterMock.Verify(fw => fw.WriteResults(outputFilePath, It.Is<Dictionary<string, double>>(r =>
            r["obj1"] == 5 && r["obj2"] == 10)), Times.Once);
    }
}
