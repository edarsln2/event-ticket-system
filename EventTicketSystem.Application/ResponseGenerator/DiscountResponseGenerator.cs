
using EventTicketSystem.Dto.Response.DiscountResponse;
using EventTicketSystem.Dto.Response.EventResponse;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Application.ResponseGenerator
{
    public class DiscountResponseGenerator
    {
        public static InsertDiscountResponse ToInsertDiscountResponse(Discount discount)
        {
            return new InsertDiscountResponse
            {
                DiscountId = discount.DiscountId
            };
        }

        public static List<GetAllDiscountResponse> ToGetAllDiscountResponse(List<Discount> discounts)
        {
            return discounts.Select(d => new GetAllDiscountResponse
            {
                DiscountId = d.DiscountId,
                DiscountName = d.DiscountName,
                Percentage = d.Percentage,
                FirstPurchaseOnly = d.FirstPurchaseOnly
            }).ToList();
        }
    }
}
