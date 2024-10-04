using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class Parts
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

}