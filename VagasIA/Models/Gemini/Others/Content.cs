using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class Content
{
    [JsonPropertyName("parts")]
    public List<Parts> Parts { get; set; }
}