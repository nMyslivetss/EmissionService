using EmissionService.DTOs;

namespace EmissionService.Services
{
    public interface IEmissionsService
    {
        Task<List<EmissionResponseDto>> GetEmissionsAsync(EmissionRequestDto request);
    }
}
