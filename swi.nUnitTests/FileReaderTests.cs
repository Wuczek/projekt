using Newtonsoft.Json;

namespace swi.nUnitTests;

public class FileReaderTests
{
    private readonly string _validJsonPath = "valid.json";
    private readonly string _invalidJsonPath = "invalid.json";

    [SetUp]
    public void Setup()
    {
        File.WriteAllText(_validJsonPath, "{ \"obj1\": { \"operator\": \"add\", \"value1\": 2, \"value2\": 3 } }");
        File.WriteAllText(_invalidJsonPath, "invalid json content");
    }

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_validJsonPath)) File.Delete(_validJsonPath);
        if (File.Exists(_invalidJsonPath)) File.Delete(_invalidJsonPath);
    }

    [Test]
    public void ReadJson_ShouldReadValidJsonFile()
    {
        var reader = new FileReader();
        var result = reader.ReadJson(_validJsonPath);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result["obj1"].Operator, Is.EqualTo("add"));
    }

    [Test]
    public void ReadJson_ShouldThrowExceptionForInvalidJson()
    {
        var reader = new FileReader();
        Assert.Throws<JsonReaderException>(() => reader.ReadJson(_invalidJsonPath));
    }

    [Test]
    public void ReadJson_ShouldThrowFileNotFoundException()
    {
        var reader = new FileReader();
        Assert.Throws<FileNotFoundException>(() => reader.ReadJson("non_existing.json"));
    }
}