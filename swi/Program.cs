using Microsoft.Extensions.DependencyInjection;

namespace swi;

public class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IFileReader, FileReader>()
            .AddTransient<IFileWriter, FileWriter>()
            .AddTransient<ICalculatorService, CalculatorService>()
            .AddTransient<ICalculationContext, CalculationContext>()
            .AddTransient<ICalculationStrategy, AdditionStrategy>()
            .AddTransient<ICalculationStrategy, MultiplicationStrategy>()
            .AddTransient<ICalculationStrategy, SubtractionStrategy>()
            .AddTransient<ICalculationStrategy, SquareRootStrategy>()
            .BuildServiceProvider();

        var calculatorService = serviceProvider.GetRequiredService<ICalculatorService>();
        calculatorService.Run("input.json", "output.txt");

        Console.WriteLine("Obliczenia zakończone, wyniki zapisano do output.txt");
    }
}
