using HoodieStatsApi.Data;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HoodieStatsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class PlayerController : ControllerBase
    {
        private readonly IDataService _dataService;

        public PlayerController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET /api/Player/stats/{playername}
        [HttpGet("stats/{playername}")]
        public async Task<ActionResult<CachedStats>> GetStats(string playername)
        {
            // Playername an den DataService weitergeben
            var stats = await _dataService.GetStatsAsync();

            if (stats == null) 
                return NotFound(); // Spieler nicht gefunden

            return Ok(stats);
        }
    }
}
