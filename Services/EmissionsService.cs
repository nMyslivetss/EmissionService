using EmissionService.Data;
using EmissionService.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmissionService.Services
{
    public class EmissionsServices : IEmissionsService
    {
        private readonly EmissionDbContext _context;

        public EmissionsServices(EmissionDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmissionResponseDto>> GetEmissionsAsync(EmissionRequestDto request)
        {
            var query = _context.EmissionRecords.AsQueryable();

            // Filter by CustomerName
            if (request.CustomerName?.Any() ?? false)
                query = query.Where(e => request.CustomerName.Contains(e.Customer));

            // Filter by CustomerId
            if (request.CustomerId?.Any() ?? false)
                query = query.Where(e => request.CustomerId.Contains(e.CustomerId));

            // Filter by PeriodStart
            if (request.PeriodStart != null)
            {
                var periodStart = request.PeriodStart;
                query = query.Where(e => e.Month.Year > periodStart.Year ||
                                         (e.Month.Year == periodStart.Year && e.Month.Month >= periodStart.Month));
            }

            // Filter by PeriodEnd
            if (request.PeriodEnd.HasValue)
            {
                var periodEnd = request.PeriodEnd.Value;
                query = query.Where(e => e.Month.Year < periodEnd.Year ||
                                         (e.Month.Year == periodEnd.Year && e.Month.Month <= periodEnd.Month));
            }

            // Filter by FacilityId
            if (request.FacilityId?.Any() ?? false)
                query = query.Where(e => request.FacilityId.Contains(e.FacilityId.Value));

            // Filter by FacilityCode
            if (request.FacilityCode?.Any() ?? false)
                query = query.Where(e => request.FacilityCode.Contains(e.FacilityCode));

            // Execute the request
            var emissions = await query.Select(e => new EmissionResponseDto
            {
                Customer = e.Customer,
                CustomerId = e.CustomerId,
                FacilityId = e.FacilityId,
                FacilityCode = e.FacilityCode,
                Commodity = e.Commodity,
                Month = e.Month,

                // Logic for Scope
                Scope = request.Commodity != null && request.Commodity.Any()
                        ? (e.Commodity == "Natural Gas" || e.Commodity == "Propane") ? 1 :
                          (e.Commodity == "Electricity" || e.Commodity == "Steam") ? 2 : (int?)null
                        : (int?)null,

                // Logic for Location-Based data
                LocationBasedProfile1 = e.LocationBasedEmissions != null ? e.LocationBasedProfile1 : null,
                LocationBasedProfile2 = e.LocationBasedEmissions != null ? e.LocationBasedProfile2 : null,
                LocationBasedProfile3 = e.LocationBasedEmissions != null ? e.LocationBasedProfile3 : null,
                LocationBasedEmissions = e.LocationBasedEmissions != null ? new EmissionValuesDto
                {
                    CO2 = e.LocationBasedEmissions.CO2,
                    CO2e = e.LocationBasedEmissions.CO2e,
                    CH4 = e.LocationBasedEmissions.CH4,
                    N2O = e.LocationBasedEmissions.N2O
                } : null,

                // Logic for Market-Based data
                MarketBasedProfile1 = e.MarketBasedEmissions != null ? e.MarketBasedProfile1 : null,
                MarketBasedProfile2 = e.MarketBasedEmissions != null ? e.MarketBasedProfile2 : null,
                MarketBasedProfile3 = e.MarketBasedEmissions != null ? e.MarketBasedProfile3 : null,
                MarketBasedEmissions = e.MarketBasedEmissions != null ? new EmissionValuesDto
                {
                    CO2 = e.MarketBasedEmissions.CO2,
                    CO2e = e.MarketBasedEmissions.CO2e,
                    CH4 = e.MarketBasedEmissions.CH4,
                    N2O = e.MarketBasedEmissions.N2O
                } : null
            }).ToListAsync();

            return emissions;
        }
    }
}       
