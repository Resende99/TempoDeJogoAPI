using TempoDeJogoAPI.Models;

namespace TempoDeJogoAPI.Models;

public class TempoDeJogo
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int Tempo { get; set; }
    public int Nota { get; set; } 
}