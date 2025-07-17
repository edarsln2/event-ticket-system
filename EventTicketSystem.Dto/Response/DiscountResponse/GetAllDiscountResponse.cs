
namespace EventTicketSystem.Dto.Response.DiscountResponse
{
    public class GetAllDiscountResponse
    {
        public int DiscountId { get; set; }

        public string DiscountName { get; set; }

        public decimal Percentage { get; set; }

        public string RoleRequirement { get; set; }

        public bool FirstPurchaseOnly { get; set; }
    }
}
