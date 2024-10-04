using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class CandidatesResponse
{
    [JsonPropertyName("content")]
    public Content Content { get; set; } 
}