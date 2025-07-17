
namespace EventTicketSystem.Dto.Request.DiscountRequest
{
    public class DeleteDiscountRequest : RequestBase
    {
        public int DiscountId { get; set; }

        public override bool LoginRequired => true;
    }
}
