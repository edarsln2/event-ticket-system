
namespace EventTicketSystem.Dto.Request.PurchaseRequest
{
    public class GetUserPurchasesRequest : RequestBase
    {
        public override bool LoginRequired => true;
    }
}
