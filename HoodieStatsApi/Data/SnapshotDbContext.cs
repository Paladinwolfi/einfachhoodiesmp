using HoodieStatsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HoodieStatsApi.Data;

public class SnapshotDbContext : DbContext
{
    public SnapshotDbContext(DbContextOptions<SnapshotDbContext> options) : base(options) { }

    public DbSet<ProgressSlice> ProgressSlices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProgressSlice>()
            .HasKey(p => p.Id);
    }
}