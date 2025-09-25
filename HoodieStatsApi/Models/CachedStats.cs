namespace HoodieStatsApi.Models;

public class CachedStats
{
    public List<Player> Players { get; set; } = new();
    public ServerStats ServerStats { get; set; } = new();
    public double TotalMoney { get; set; }
    public int PlayerCount { get; set; }
}