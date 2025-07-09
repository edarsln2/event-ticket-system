using EventTicketSystem.Service;
using EventTicketSystem.Dto.Request;
using EventTicketSystem.Application.ResponseGenerators;
using EventTicketSystem.Dto.Request.PurchaseRequest;
using EventTicketSystem.Dto.Response.PurchaseResponse;
using EventTicketSystem.Infrastructure;
using System.Security.Claims;
using EventTicketSystem.Entity;

public class PurchaseApplication
{
    private readonly PurchaseService _purchaseService;
    private readonly EventService _eventService;
    private readonly UserService _userService;

    public PurchaseApplication(PurchaseService purchaseService, EventService eventService, UserService userService)
    {
        _purchaseService = purchaseService;
        _eventService = eventService;
        _userService = userService;
    }

    public PurchaseTicketResponse PurchaseTicketAsGuest(PurchaseTicketAsGuestRequest request)
    {
        var evnt = _eventService.SellTicket(request.EventId, request.Quantity);
        var purchase = _purchaseService.PurchaseTicket(null, evnt.EventId, request.Quantity, evnt.Price); 
        return PurchaseResponseGenerator.ToPurchaseTicketResponse(purchase);
    }

    public PurchaseTicketResponse PurchaseTicketWithLogin(PurchaseTicketWithLoginRequest request, ClaimsPrincipal user)
    {
        var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var evnt = _eventService.SellTicket(request.EventId, request.Quantity);
        var purchase = _purchaseService.PurchaseTicket(userId, evnt.EventId, request.Quantity, evnt.Price);
        return PurchaseResponseGenerator.ToPurchaseTicketResponse(purchase);
    }

    public List<UserPurchaseResponse> GetUserPurchases(ClaimsPrincipal user)
    {
        if (user?.Identity?.IsAuthenticated != true)
        {
            throw new Exception("Kullanıcı giriş yapmamış veya token geçersiz");
        }

        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new Exception("Geçerli kullanıcı kimliği bulunamadı");
        }

        var purchases = _purchaseService.GetUserPurchases(userId);
        return PurchaseResponseGenerator.ToUserPurchaseResponse(purchases);
    }
}
