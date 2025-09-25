using HoodieStatsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoodieStatsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("totalplaytime")]
        public async Task<ActionResult<double>> GetTotalPlaytime()
        {
            var total = await _statsService.GetTotalPlaytimeAsync();
            return Ok(total);
        }
    }
}