using Newtonsoft.Json;

namespace swi;
public class CalculationRequest
{
    [JsonProperty("operator")]
    public string Operator { get; set; }
    [JsonProperty("value1")]
    public double Value1 { get; set; }
    [JsonProperty("value2")]
    public double? Value2 { get; set; }

    public CalculationRequest(string operation, double value1, double? value2)
    {
        Operator = operation;
        Value1 = value1;
        Value2 = value2;
    }
}
