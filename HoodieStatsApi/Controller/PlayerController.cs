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

        [HttpGet("stats")]
        public async Task<ActionResult<CachedStats>> GetStats()
        {
            var stats = await _dataService.GetStatsAsync();
            if (stats == null) return NotFound();
            return Ok(stats);
        }
    }
}
