using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class GeminiPromptRequest
{
    [JsonPropertyName("contents")]
    public List<Contents> Contents { get; set; }
}