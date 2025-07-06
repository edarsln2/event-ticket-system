
namespace EventTicketSystem.Dto.Response
{
    public class GetEventListResponse
    {
        public int EventId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int AvailableCapacity { get; set; }
    }
}
