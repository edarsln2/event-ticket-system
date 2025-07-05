using EventTicketSystem.Application;
using EventTicketSystem.Dto.Request;
using EventTicketSystem.Validation;

public static class ActionStorage
{
    public record ActionDefinition(Type ApplicationType, string MethodName, Type? MethodParamType, string Description, Type? ValidationType);

    public static readonly Dictionary<string, ActionDefinition> Actions = new()
    {
        { "InsertEvent", new(typeof(EventApplication), "InsertEvent", typeof(InsertEventRequest), "Yeni etkinlik ekler", typeof(InsertEventRequestValidator))},
        { "DeleteEvent", new(typeof(EventApplication), "DeleteEvent", typeof(int), "Etkinliği siler", null )},
        { "GetEventById", new(typeof(EventApplication), "GetEventById", typeof(int), "Etkinlik detayını getirir", null)},
        { "GetEventList", new(typeof(EventApplication), "GetEventList", null, "Tüm etkinlikleri listeler", null)},
        { "RegisterUser", new(typeof(EventApplication), "RegisterUser", typeof(RegisterUserRequest), "Yeni kullanıcı kaydı yapar", typeof(RegisterUserRequestValidator))},
        { "PurchaseTicket", new(typeof(EventApplication), "PurchaseTicket", typeof(PurchaseTicketRequest), "Etkinliğe bilet satın alır",typeof(PurchaseTicketRequestValidator))},
        { "GetUserEvents", new(typeof(EventApplication), "GetUserEvents", typeof(UserEventRequest), "Kullanıcının satın aldığı biletleri listeler", null)}
    };
}
