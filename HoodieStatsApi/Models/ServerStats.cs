namespace HoodieStatsApi.Models;

public class ServerStats
{
    public int Id { get; set; }
    public double ServerEconomy { get; set; }
    public double ServerPlaytime { get; set; }
    public double ServerPlayers { get; set; }
    public double ServerKills { get; set; }
    public double ServerDeaths { get; set; }
    public double ServerBlocksMined { get; set; }
    public double ServerBlocksBroken { get; set; }
}