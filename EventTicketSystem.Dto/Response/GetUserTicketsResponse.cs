namespace EventTicketSystem.Dto.Response
{
    public class GetUserTicketsResponse
    {
        public int PurchaseId { get; set; }
        public string EventName { get; set; } 
        public DateTime EventDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
