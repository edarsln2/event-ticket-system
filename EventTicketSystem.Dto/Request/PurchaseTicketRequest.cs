namespace EventTicketSystem.Dto.Request
{
    public class PurchaseTicketRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
    }
}


