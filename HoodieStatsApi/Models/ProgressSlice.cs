namespace HoodieStatsApi.Models;

public class ProgressSlice
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public double TotalMoney { get; set; }
    public int PlayerCount { get; set; }
    public string Hash { get; set; } = "";
}