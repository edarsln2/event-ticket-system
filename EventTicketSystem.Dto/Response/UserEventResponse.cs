
namespace EventTicketSystem.Dto.Response
{
    public class UserEventResponse
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string EventName { get; set; }
        public string EventCategory { get; set; }
        public DateTime EventStartDate { get; set; }
        public string EventLocation { get; set; }
    }
}
