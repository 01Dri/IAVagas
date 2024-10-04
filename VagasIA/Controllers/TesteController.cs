using Microsoft.AspNetCore.Mvc;
using VagasIA.Interfaces;
using VagasIA.Models;

namespace VagasIA.Controllers;

[Route("teste")]
public class TesteController : ControllerBase
{
    private readonly IGeminiGenerator _generator;

    public TesteController(IGeminiGenerator generator)
    {
        _generator = generator;
    }

    [HttpPost]
    public async Task<IActionResult> Teste([FromBody] PromptRequest request)
    {
        var response = await _generator.GetTips(request.Prompt);
        return Ok(response);
    }
}