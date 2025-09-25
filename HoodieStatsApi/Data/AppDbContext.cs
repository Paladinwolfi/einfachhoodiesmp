using Microsoft.EntityFrameworkCore;
using HoodieStatsApi.Models;

namespace HoodieStatsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  {}
    
    public DbSet<Player> Players => Set<Player>();
    public DbSet<ServerStats> ServerStats => Set<ServerStats>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Players Testdaten
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, UUID = "uuid-123", Name = "Steve", Playtime = 120 },
            new Player { Id = 2, UUID = "uuid-456", Name = "Alex", Playtime = 250 },
            new Player { Id = 3, UUID = "uuid-789", Name = "Herobrine", Playtime = 9999 }
        );

        // ServerStats Testdaten
        modelBuilder.Entity<ServerStats>().HasData(
            new ServerStats
            {
                Id = 1,
                ServerEconomy = 15000.50,
                ServerPlaytime = 3000,
                ServerPlayers = 150,
                ServerKills = 450,
                ServerDeaths = 380,
                ServerBlocksMined = 50000,
                ServerBlocksBroken = 42000
            }
        );

    }
}