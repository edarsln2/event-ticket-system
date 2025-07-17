
namespace EventTicketSystem.Dto.Request.DiscountRequest
{
    public class InsertDiscountRequest : RequestBase
    {
        public string DiscountName { get; set; }

        public decimal Percentage { get; set; }

        public bool FirstPurchaseOnly { get; set; }

        public override bool LoginRequired => true;
    }
}
