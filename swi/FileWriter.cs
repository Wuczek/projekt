namespace swi;

public class FileWriter : IFileWriter
{
    public void WriteResults(string fileName, Dictionary<string, double> results)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in results)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Błąd zapisu do pliku: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
            throw;
        }
    }
}
