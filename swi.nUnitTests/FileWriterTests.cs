namespace swi.nUnitTests;

public class FileWriterTests
{
    private readonly string _outputPath = "test_output.txt";

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_outputPath)) File.Delete(_outputPath);
    }

    [Test]
    public void WriteResults_ShouldWriteCorrectlyToFile()
    {
        var writer = new FileWriter();
        var results = new Dictionary<string, double>
            {
                { "obj1", 5 },
                { "obj2", 10 }
            };

        writer.WriteResults(_outputPath, results);

        Assert.That(File.Exists(_outputPath), Is.True);
        var content = File.ReadAllText(_outputPath);
        Assert.Multiple(() =>
        {
            Assert.That(content, Does.Contain("obj1: 5"));
            Assert.That(content, Does.Contain("obj2: 10"));
        });
    }
}
