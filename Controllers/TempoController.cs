using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempoDeJogoAPI.Data;
using TempoDeJogoAPI.Models;

namespace TempoDeJogoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TempoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TempoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("salvar")]
    public async Task<IActionResult> SalvarTempo([FromBody] TempoDeJogoRequest request)
    {
        if (request.UsuarioId <= 0 || request.Tempo < 0)
            return BadRequest(new { mensagem = "UsuarioId e Tempo devem ser válidos." });

        var novoTempo = new TempoDeJogo
        {
            UsuarioId = request.UsuarioId,
            Tempo = request.Tempo
        };

        _context.TemposDeJogo.Add(novoTempo);
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Tempo salvo com sucesso!", id = novoTempo.Id });
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> InserirTempoENota([FromBody] TempoNotaRequest request)
    {
        if (request.UsuarioId <= 0 || request.Tempo < 0 || request.Nota < 0 || request.Nota > 10)
            return BadRequest(new { mensagem = "UsuarioId, Tempo e Nota devem ser válidos. Nota deve estar entre 0 e 10." });

        var novoRegistro = new TempoDeJogo
        {
            UsuarioId = request.UsuarioId,
            Tempo = request.Tempo,
            Nota = request.Nota
        };

        _context.TemposDeJogo.Add(novoRegistro);
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Dados inseridos com sucesso!", id = novoRegistro.Id });
    }

    [HttpDelete("retirar/{id}")]
    public async Task<IActionResult> RetirarTempoENota(int id)
    {
        var registro = await _context.TemposDeJogo.FindAsync(id);

        if (registro == null)
            return NotFound(new { mensagem = "Registro não encontrado." });

        _context.TemposDeJogo.Remove(registro);
        await _context.SaveChangesAsync();

        return Ok(new { mensagem = "Registro removido com sucesso!" });
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarTempos()
    {
        var tempos = await _context.TemposDeJogo
            .AsNoTracking()
            .ToListAsync();
        return Ok(tempos);
    }
}

public record TempoDeJogoRequest(int UsuarioId, int Tempo);
public record TempoNotaRequest(int UsuarioId, int Tempo, int Nota);