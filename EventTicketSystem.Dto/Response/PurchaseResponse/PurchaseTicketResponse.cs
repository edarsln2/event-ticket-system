namespace EventTicketSystem.Dto.Response.PurchaseResponse
{
    public class PurchaseTicketResponse
    {
        public int PurchaseId { get; set; }
        public int EventId { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
