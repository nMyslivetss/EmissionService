namespace EmissionService.Models
{
    public class EmissionRecord
    {
        public int Id { get; set; }
        public required string Customer { get; set; }
        public long CustomerId { get; set; }
        public long? FacilityId { get; set; }
        public string? FacilityCode { get; set; }
        public string? Commodity { get; set; }
        public DateTime Month { get; set; }
        public int? Scope { get; set; }

        public string? LocationBasedProfile1 { get; set; }
        public string? LocationBasedProfile2 { get; set; }
        public string? LocationBasedProfile3 { get; set; }

        public int? LocationBasedEmissionsId { get; set; }
        public EmissionValues? LocationBasedEmissions { get; set; }

        public string? MarketBasedProfile1 { get; set; }
        public string? MarketBasedProfile2 { get; set; }
        public string? MarketBasedProfile3 { get; set; }

        public int? MarketBasedEmissionsId { get; set; }
        public EmissionValues? MarketBasedEmissions { get; set; }
    }
}
