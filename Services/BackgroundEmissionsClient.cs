using EmissionService.DTOs;
using Microsoft.AspNetCore.WebUtilities;

namespace EmissionService.Services
{
    public class BackgroundEmissionsClient : IBackgroundEmissionsClient
    {
        private readonly HttpClient _httpClient;
        public BackgroundEmissionsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmissionResponseDto>> GetEmissionsAsync(EmissionRequestDto request)
        {
            var queryParams = new List<KeyValuePair<string, string?>>();

            if (request.PeriodStart != null)
                queryParams.Add(new KeyValuePair<string, string?>("PeriodStart", request.PeriodStart.ToString("o")));

            if (request.PeriodEnd.HasValue)
                queryParams.Add(new KeyValuePair<string, string?>("PeriodEnd", request.PeriodEnd.Value.ToString("o")));

            if (request.CustomerName?.Any() ?? false)
                queryParams.AddRange(request.CustomerName.Select(name => new KeyValuePair<string, string?>("CustomerName", name)));

            if (request.CustomerId?.Any() ?? false)
                queryParams.AddRange(request.CustomerId.Select(id => new KeyValuePair<string, string?>("CustomerId", id.ToString())));

            if (request.FacilityId?.Any() ?? false)
                queryParams.AddRange(request.FacilityId.Select(id => new KeyValuePair<string, string?>("FacilityId", id.ToString())));

            if (request.FacilityCode?.Any() ?? false)
                queryParams.AddRange(request.FacilityCode.Select(code => new KeyValuePair<string, string?>("FacilityCode", code)));

            if (request.Commodity?.Any() ?? false)
                queryParams.AddRange(request.Commodity.Select(c => new KeyValuePair<string, string?>("Commodity", c)));

            var url = QueryHelpers.AddQueryString("https://localhost:7168/background/emissions", queryParams);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var emissions = await response.Content.ReadFromJsonAsync<List<EmissionResponseDto>>();
            return emissions ?? new List<EmissionResponseDto>();
        }
    }
}
