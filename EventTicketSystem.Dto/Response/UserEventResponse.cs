
namespace EventTicketSystem.Dto.Response
{
    public class UserEventResponse
    {
        public int PurchaseId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
