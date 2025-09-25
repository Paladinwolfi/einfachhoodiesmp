namespace HoodieStatsApi.Interfaces
{
    public interface IStatsService
    {
        Task<double> GetTotalPlaytimeAsync();
    }
}
