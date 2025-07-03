
namespace EventTicketSystem.Dto.Request
{
    public class InsertEventRequest
    {
        public string EventCategory { get; set; } 
        public string EventName { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } 
        public decimal Price { get; set; }
        public int TotalCapacity { get; set; }
        public int TicketSold { get; set; }
    }
}
