namespace EventTicketSystem.Dto.Response.PurchaseResponse
{
    public class UserPurchaseResponse
    {
        public int PurchaseId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
