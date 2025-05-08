using Microsoft.EntityFrameworkCore;
using TempoDeJogoAPI.Models;

namespace TempoDeJogoAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TempoDeJogo> TemposDeJogo { get; set; }
}
