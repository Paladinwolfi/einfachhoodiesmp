using System.ComponentModel.DataAnnotations;

namespace HoodieStatsApi.Models;

public class Player
{
    [Key] public int Id { get; set; }
    public string UUID { get; set; } = "";
    public string Name { get; set; } = "";
    public int Playtime { get; set; }

//TODO an Datenbank anpassen
}