namespace swi;

public interface IFileReader
{
    public Dictionary<string, CalculationRequest> ReadJson(string fileName);
}