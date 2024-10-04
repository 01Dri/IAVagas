using System.Text.Json.Serialization;

namespace VagasIA.Models.Gemini;

public class GeminiPromptResponse
{
    [JsonPropertyName("candidates")]
    public List<CandidatesResponse> Candidates { get; set; }
}