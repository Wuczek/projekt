using Newtonsoft.Json;

namespace swi;

public class FileReader : IFileReader
{
    public Dictionary<string, CalculationRequest> ReadJson(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Plik wejściowy nie istnieje: {fileName}");
        }

        try
        {
            string jsonData = File.ReadAllText(fileName);
            var requests = JsonConvert.DeserializeObject<Dictionary<string, CalculationRequest>>(jsonData);

            if (requests == null)
            {
                throw new JsonException("Plik JSON jest pusty lub niepoprawny.");
            }

            return requests;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Błąd parsowania JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd odczytu pliku: {ex.Message}");
            throw;
        }
    }
}

