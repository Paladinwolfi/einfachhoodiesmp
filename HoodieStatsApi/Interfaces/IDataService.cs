using HoodieStatsApi.Models;

namespace HoodieStatsApi.Interfaces
{
    public interface IDataService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<ServerStats?> GetServerStatsAsync();
    }
}
