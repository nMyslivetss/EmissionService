using EmissionService.DTOs;

namespace EmissionService.Services
{
    public interface IBackgroundEmissionsClient
    {
        Task<List<EmissionResponseDto>> GetEmissionsAsync(EmissionRequestDto request);
    }
}
