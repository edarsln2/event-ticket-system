namespace EventTicketSystem.Dto.Request.PurchaseRequest
{
    public class PurchaseTicketWithLoginRequest : RequestBase
    {
        public int EventId { get; set; }
        public int Quantity { get; set; }

        public override bool LoginRequired => true;
    }
}


