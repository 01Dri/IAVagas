using VagasIA.Models.Gemini;

namespace VagasIA.Interfaces;

public interface IGeminiGenerator
{
    Task<GeminiPromptResponse?> GetTips(string prompt);
}