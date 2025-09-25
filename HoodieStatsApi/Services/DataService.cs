using HoodieStatsApi.Data;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HoodieStatsApi.Services;

public class DataService : IDataService
{
    private readonly AppDbContext _db;
    private readonly IMemoryCache _cache;
    private readonly ILogger<DataService> _logger;
    private const string CacheKey = "cached_stats";

    
    public DataService(AppDbContext db, IMemoryCache cache, ILogger<DataService> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
        StartCacheUpdater();
    }
    private void StartCacheUpdater()
    {
        Task.Run(async () =>
        {
            while (true)
            {

                    var players = await _db.Players.ToListAsync();
                    var serverStats = await _db.ServerStats.FirstOrDefaultAsync();

                    var cachedStats = new CachedStats
                    {
                        Players = players,
                        ServerStats = serverStats ?? new ServerStats(),
                        TotalMoney = players.Sum(p => p.Playtime),
                        PlayerCount = players.Count
                    };

                    _cache.Set(CacheKey, cachedStats, TimeSpan.FromSeconds(35));

                    await Task.Delay(TimeSpan.FromSeconds(30));
            }
        });
    }
    
    public Task<CachedStats?> GetStatsAsync()
        => Task.FromResult(_cache.Get<CachedStats>(CacheKey));
}
    
