using HoodieStatsApi.Data;
using HoodieStatsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HoodieStatsApi.Services
{
    public class StatsUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMemoryCache _cache;
        private readonly ILogger<StatsUpdateService> _logger;
        private const string CacheKey = "cached_stats";

        public StatsUpdateService(IServiceProvider serviceProvider, IMemoryCache cache, ILogger<StatsUpdateService> logger)
        {
            _serviceProvider = serviceProvider;
            _cache = cache;
            _logger = logger;
        }
        
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("StatsUpdateService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var snapshotDb = scope.ServiceProvider.GetRequiredService<SnapshotDbContext>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }
            
            
            
        }
    }   
}