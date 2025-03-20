using EmissionService.DTOs;
using EmissionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmissionService.Controllers
{
    [ApiController]
    [Route("background/emissions")]
    public class BackgroundEmissionsController : ControllerBase
    {
        private readonly IEmissionsService _emissionsService;

        public BackgroundEmissionsController(IEmissionsService emissionsService)
        {
            _emissionsService = emissionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmissions([FromQuery] EmissionRequestDto request)
        {
            return Ok(await _emissionsService.GetEmissionsAsync(request));
        }
    }
}
