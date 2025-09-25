using HoodieStatsApi.Models;

namespace HoodieStatsApi.Interfaces
{
    public interface IDataService
    {
        Task<CachedStats?> GetStatsAsync();
    }
}
