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
    private const string PlayersKey = "players_cache";
    private const string ServerStatsKey = "serverstats_cache";

    
    public DataService(AppDbContext db, IMemoryCache cache, ILogger<DataService> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
        StartCacheUpdater();
    }
        
        
    public Task<List<Player>> GetPlayersAsync()
    {
        var players = _cache.Get<List<Player>>(PlayersKey);
        return Task.FromResult(players ?? new List<Player>());
    }

    public Task<ServerStats?> GetServerStatsAsync()
    {
        var stats = _cache.Get<ServerStats>(ServerStatsKey);
        return Task.FromResult(stats);
    }
    
    private void StartCacheUpdater()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    var players = await _db.Players.ToListAsync();
                    var stats = await _db.ServerStats.FirstOrDefaultAsync();

                    _cache.Set(PlayersKey, players, TimeSpan.FromSeconds(35));
                    if (stats != null)
                        _cache.Set(ServerStatsKey, stats, TimeSpan.FromSeconds(35));

                    _logger.LogInformation("Cache updated from DB.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating cache");
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        });
    }
}
    
