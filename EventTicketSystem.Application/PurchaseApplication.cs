using EventTicketSystem.Service;
using EventTicketSystem.Dto.Response.PurchaseResponse;
using EventTicketSystem.Dto.Request.PurchaseRequest;
using EventTicketSystem.Application.ResponseGenerators;
using System.Security.Claims;
using EventTicketSystem.Entity;
public class PurchaseApplication
{
    private readonly PurchaseService _purchaseService;
    private readonly EventService _eventService;
    private readonly EmailSenderService _emailSenderService;
    private readonly DiscountService _discountService;
    private readonly UserService _userService;


    public PurchaseApplication(PurchaseService purchaseService, EventService eventService, EmailSenderService emailSenderService, DiscountService discountService, UserService userService)
    {
        _purchaseService = purchaseService;
        _eventService = eventService;
        _emailSenderService = emailSenderService;
        _discountService = discountService;
        _userService = userService;
    }

    public PurchaseTicketResponse PurchaseTicketWithLogin(PurchaseTicketWithLoginRequest request)
    {
        int userId = int.Parse(request.UserInfo.FindFirst(ClaimTypes.NameIdentifier).Value);
        string userEmail = request.UserInfo.FindFirst(ClaimTypes.Email).Value;
        DateTime birthDate = DateTime.ParseExact(request.UserInfo.FindFirst(ClaimTypes.DateOfBirth)!.Value,"yyyy-MM-dd",null);

        var evnt = _eventService.SellTicket(request.EventId, request.Quantity);

        bool isBirthday = _userService.IsBirthdayToday(birthDate);
        bool isStudent = _userService.IsStudent(birthDate);
        bool isFirstPurchase = _purchaseService.IsFirstPurchase(userId);
        bool isLastWeek = _eventService.IsEventInLastWeek(evnt.StartDate);

        decimal? discountRate = _discountService.GetMatchedDiscountRate(isBirthday, isStudent,isFirstPurchase, isLastWeek);

        decimal totalPrice = evnt.Price * request.Quantity;

        if (discountRate != null)
        {
            totalPrice -= totalPrice * (discountRate.Value / 100m);
        }

        var purchase = _purchaseService.PurchaseTicket(userId, evnt.EventId, request.Quantity, totalPrice);
        _emailSenderService.SendTicketEmail(userEmail, evnt.Name, request.Quantity, totalPrice);

        return PurchaseResponseGenerator.ToPurchaseTicketResponse(purchase);
    }

    public PurchaseTicketResponse PurchaseTicketAsGuest(PurchaseTicketAsGuestRequest request)
    {
        var evnt = _eventService.SellTicket(request.EventId, request.Quantity);
        var purchase = _purchaseService.PurchaseTicket(null, evnt.EventId, request.Quantity, evnt.Price);

        return PurchaseResponseGenerator.ToPurchaseTicketResponse(purchase);
    }

    public List<UserPurchaseResponse> GetUserPurchases(GetUserPurchasesRequest request)
    {
        int userId = int.Parse(request.UserInfo.FindFirst(ClaimTypes.NameIdentifier).Value);
        var purchases = _purchaseService.GetUserPurchases(userId);

        return PurchaseResponseGenerator.ToUserPurchaseResponse(purchases);
    }
}
