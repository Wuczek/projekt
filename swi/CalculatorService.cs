namespace swi;

public class CalculatorService : ICalculatorService
{
    private readonly IFileReader _fileReader;
    private readonly IFileWriter _fileWriter;
    private readonly ICalculationContext _context;
    private readonly Dictionary<string, ICalculationStrategy> _strategies;

    public CalculatorService(IFileReader fileReader, IFileWriter fileWriter,
                             ICalculationContext context, IEnumerable<ICalculationStrategy> strategies)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
        _context = context;
        _strategies = strategies.ToDictionary(s => s.GetOperator(), s => s);
    }

    public void Run(string inputFilePath, string outputFilePath)
    {
        var operations = _fileReader.ReadJson(inputFilePath);
        Dictionary<string, double> results = new Dictionary<string, double>();

        foreach (var (key, request) in operations)
        {
            if (_strategies.TryGetValue(request.Operator, out var strategy))
            {
                _context.SetStrategy(strategy);
                double result = _context.ExecuteStrategy(request.Value1, request.Value2);
                results[key] = result;
            }
            else
            {
                Console.WriteLine($"Nieznana operacja: {request.Operator}");
            }
        }

        var sortedResults = results.OrderBy(r => r.Value).ToDictionary(r => r.Key, r => r.Value);

        _fileWriter.WriteResults(outputFilePath, sortedResults);
    }
}

