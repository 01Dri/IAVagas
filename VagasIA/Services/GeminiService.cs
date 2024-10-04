using System.Text;
using System.Text.Json;
using VagasIA.Exceptions;
using VagasIA.Interfaces;
using VagasIA.Models.Gemini;

namespace VagasIA.Services;

public class GeminiService : IGeminiGenerator
{
    private readonly HttpClient _httpClient;

    public GeminiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GeminiPromptResponse?> GetTips(string prompt)
    {
        var geminiKey = Environment.GetEnvironmentVariable("GEMINI_KEY");
        if (string.IsNullOrEmpty(geminiKey)) throw new IAKeyException("API KEY Inválida!");
        var promptRequest = new GeminiPromptRequest()
        {
            Contents = new List<Contents>
            {
                new Contents()
                {
                    Parts = new List<Parts>
                    {
                        new Parts() { Text = prompt }
                    }
                }
            }
        };
        var promptRequestJson =  JsonSerializer.Serialize(promptRequest);
        var content = new StringContent(promptRequestJson, Encoding.UTF8, "application/json");
        try
        {
            var response = await _httpClient.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={geminiKey}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<GeminiPromptResponse>(responseData);
                return responseObject;
            }
        }
        catch (Exception ex)
        {
            throw new IAResponseException("Falha ao obter uma responda da IA, causa: " + ex.Message);
        }
        return null;
    }
}