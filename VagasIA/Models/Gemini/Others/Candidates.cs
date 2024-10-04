using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class Candidates
{
    [JsonPropertyName("content")]
    public List<Contents> Content { get; set; }
}