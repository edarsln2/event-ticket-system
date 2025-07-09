using EventTicketSystem.Dto.Request.EventRequest;
using EventTicketSystem.Dto.Request.PurchaseRequest;
using EventTicketSystem.Dto.Request.UserRequest;
using EventTicketSystem.Validation.PurchaseValidation;

public static class ActionStorage
{
    public record ActionDefinition(Type ApplicationType, string MethodName, Type? MethodParamType, string Description, Type? ValidationType);

    public static readonly Dictionary<string, ActionDefinition> Actions = new()
    {
        { "InsertEvent", new(typeof(EventApplication), "InsertEvent", typeof(InsertEventRequest), "Yeni etkinlik ekler", typeof(InsertEventRequestValidator))},
        { "DeleteEvent", new(typeof(EventApplication), "DeleteEvent", typeof(int), "Etkinliği siler", null )},
        { "GetEventById", new(typeof(EventApplication), "GetEventById", typeof(int), "Etkinlik detayını getirir", null)},
        { "GetEventList", new(typeof(EventApplication), "GetEventList", null, "Tüm etkinlikleri listeler", null)},

        { "RegisterUser", new(typeof(UserApplication), "RegisterUser", typeof(RegisterUserRequest), "Yeni kullanıcı kaydı yapar", typeof(RegisterUserRequestValidator))},
        { "Login", new(typeof(UserApplication), "Login", typeof(LoginRequest), "Login olur ve JWT token alır", typeof(LoginRequestValidator))},
        
        { "PurchaseTicketWithLogin", new(typeof(PurchaseApplication),"PurchaseTicketWithLogin", typeof(PurchaseTicketWithLoginRequest), "Token ile bilet alınır", typeof(PurchaseTicketWithLoginRequestValidator))},
        { "PurchaseTicketAsGuest", new(typeof(PurchaseApplication), "PurchaseTicketAsGuest", typeof(PurchaseTicketAsGuestRequest), "Misafir bilet satın alır", typeof(PurchaseTicketAsGuestRequestValidator))},
        { "GetUserPurchases", new(typeof(PurchaseApplication), "GetUserPurchases", null, "Kullanıcının satın aldığı biletleri getirir", null) }
    };
}
