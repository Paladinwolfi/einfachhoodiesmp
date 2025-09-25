using System.Data.SqlTypes;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HoodieStatsApi.Services;

public class StatsService : IStatsService
{

    private readonly AppDbContext _db;

    public StatsService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<double> GetTotalPlaytimeAsync()
    {
        return await _db.Players.SumAsync(p => p.Playtime);
    }
}