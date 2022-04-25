using Newtonsoft.Json;

namespace MySqlJsonTest;

public class SampleJson
{
    [JsonProperty("int_value")]
    public int IntValue { get; set; }
}