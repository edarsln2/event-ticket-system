using EventTicketSystem.Dto.Request.DiscountRequest;
using EventTicketSystem.Dto.Request.EventRequest;
using EventTicketSystem.Dto.Request.PurchaseRequest;
using EventTicketSystem.Dto.Request.UserRequest;
using EventTicketSystem.Validation.PurchaseValidation;
using EventTicketSystem.Validation.DiscountValidation;
public static class ActionStorage
{
    public record ActionDefinition(Type ApplicationType, string MethodName, Type MethodParamType, string Description, Type? ValidationType, string? Role, bool LoginRequired);

    public static readonly Dictionary<string, ActionDefinition> Actions = new()
    {
        { "InsertEvent", new(typeof(EventApplication), "InsertEvent", typeof(InsertEventRequest), "Yeni etkinlik ekler", typeof(InsertEventRequestValidator), "admin", true)},
        { "DeleteEvent", new(typeof(EventApplication), "DeleteEvent", typeof(DeleteEventRequest), "Etkinliği siler", typeof(DeleteEventRequestValidator), "admin",true)},
        { "GetEventById", new(typeof(EventApplication), "GetEventById", typeof(GetEventByIdRequest), "Etkinlik detayını getirir", typeof(GetEventByIdRequestValidator), null, false)},
        { "GetEventList", new(typeof(EventApplication), "GetEventList", typeof(GetEventListRequest), "Tüm etkinlikleri listeler", null, null, false)},

        { "RegisterUser", new(typeof(UserApplication), "RegisterUser", typeof(RegisterUserRequest), "Yeni kullanıcı kaydı yapar", typeof(RegisterUserRequestValidator), null, false)},
        { "Login", new(typeof(UserApplication), "Login", typeof(LoginRequest), "Login olur ve JWT token alır", typeof(LoginRequestValidator), null, false)},
        
        { "PurchaseTicketWithLogin", new(typeof(PurchaseApplication), "PurchaseTicketWithLogin", typeof(PurchaseTicketWithLoginRequest), "Token ile bilet alınır", typeof(PurchaseTicketWithLoginRequestValidator), "admin", true)},
        { "PurchaseTicketAsGuest", new(typeof(PurchaseApplication), "PurchaseTicketAsGuest", typeof(PurchaseTicketAsGuestRequest), "Misafir bilet satın alır", typeof(PurchaseTicketAsGuestRequestValidator), null, false)},
        { "GetUserPurchases", new(typeof(PurchaseApplication), "GetUserPurchases", typeof(GetUserPurchasesRequest), "Kullanıcının satın aldığı biletleri getirir", null, null, true)},

        {"InsertDiscount", new(typeof(DiscountApplication), "InsertDiscount", typeof(InsertDiscountRequest), "İndirim oranı ekler", typeof(InsertDiscountRequestValidator), "admin", true)},
        {"DeleteDiscount", new(typeof(DiscountApplication), "DeleteDiscount", typeof(DeleteDiscountRequest), "İndirim siler", typeof(DeleteDiscountRequestValidator), "admin", true)},
        {"GetAllDiscount", new(typeof(DiscountApplication), "GetAllDiscount", typeof(GetAllDiscountRequest), "Yapılabilecek indirimleri listeler", null, "admin", true)}
    };
}
