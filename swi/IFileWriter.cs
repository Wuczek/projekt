namespace swi;

public interface IFileWriter
{
    public void WriteResults(string filePath, Dictionary<string, double> results);
}
