using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class Contents
{
    [JsonPropertyName("parts")]
    public List<Parts> Parts { get; set; }
}