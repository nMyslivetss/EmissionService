using EmissionService.DTOs;
using EmissionService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmissionService.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2/emissions")]
    public class EmissionsControllerV2 : ControllerBase
    {
        private readonly IBackgroundEmissionsClient _backgroundEmissionsClient;
        public EmissionsControllerV2(IBackgroundEmissionsClient backgroundEmissionsClient)
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
