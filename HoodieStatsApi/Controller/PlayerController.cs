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

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _dataService.GetPlayersAsync();
            return Ok(players);
        }
    }
}
