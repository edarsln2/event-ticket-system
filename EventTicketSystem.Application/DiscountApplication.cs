using EventTicketSystem.Service;
using EventTicketSystem.Application.ResponseGenerator;
using EventTicketSystem.Dto.Request.DiscountRequest;
using EventTicketSystem.Dto.Response.DiscountResponse;
using EventTicketSystem.Dto.Request.EventRequest;

public class DiscountApplication
{
    private readonly DiscountService _discountService;

    public DiscountApplication(DiscountService discountService)
    {
        _discountService = discountService;
    }

    public InsertDiscountResponse InsertDiscount(InsertDiscountRequest request)
    {
        var discount = _discountService.InsertDiscount(request.DiscountName, request.Percentage, request.FirstPurchaseOnly);
        return DiscountResponseGenerator.ToInsertDiscountResponse(discount);
    }

    public void DeleteDiscount(DeleteDiscountRequest request)
    {
        _discountService.DeleteDiscount(request.DiscountId);
    }

    public List<GetAllDiscountResponse> GetAllDiscount(GetAllDiscountRequest request)
    {
        var discount = _discountService.GetAllDiscount();
        return DiscountResponseGenerator.ToGetAllDiscountResponse(discount);
    }
}