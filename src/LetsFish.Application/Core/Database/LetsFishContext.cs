namespace LetsFish.Application.Core.Database;

public class LetsFishContext : DbContext
{
    public LetsFishContext(DbContextOptions<LetsFishContext> options) : base(options)  { }
    public DbSet<Captain> Captains { get; set; }
    public DbSet<Angler> Anglers { get; set; }
    public DbSet<Team> Teams { get; set; }
}