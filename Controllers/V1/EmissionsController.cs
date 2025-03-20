using EmissionService.DTOs;
using EmissionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmissionService.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/emissions")]
    public class EmissionsController : ControllerBase
    {
        private readonly IBackgroundEmissionsClient _backgroundEmissionsClient;
        public EmissionsController(IBackgroundEmissionsClient backgroundEmissionsClient)
        {
            _backgroundEmissionsClient = backgroundEmissionsClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmissions([FromQuery] EmissionRequestDto request)
        {
            try
            {
                var emissions = await _backgroundEmissionsClient.GetEmissionsAsync(request);
                return Ok(emissions);
            }
            catch (HttpRequestException)
            {
                return StatusCode(502, "Error when calling the Background API");
            }
        }
    }
}
