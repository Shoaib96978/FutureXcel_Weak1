using FutureXcel.Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FutureXcel.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;
        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }
        [HttpGet]
        [Route("health")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetHealth()
        {
            var response = await _healthService.CheckHealthAsync();
            return StatusCode((int)response.Status, response);
        }
    }
}
