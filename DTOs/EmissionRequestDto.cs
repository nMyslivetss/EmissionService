

namespace EmissionService.DTOs
{
    public class EmissionRequestDto
    {
        public required List<string> CustomerName { get; set; }
        public required List<long> CustomerId { get; set; }
        public List<long>? FacilityId { get; set; }
        public List<string>? FacilityCode { get; set; }
        public List<string>? Commodity { get; set; }
        public required DateTime PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
    }
}
