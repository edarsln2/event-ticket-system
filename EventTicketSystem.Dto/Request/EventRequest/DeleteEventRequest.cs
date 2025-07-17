namespace EventTicketSystem.Dto.Request.EventRequest
{
    public class DeleteEventRequest : RequestBase
    {
        public int EventId { get; set; }

        public override bool LoginRequired => true;
    }
}
