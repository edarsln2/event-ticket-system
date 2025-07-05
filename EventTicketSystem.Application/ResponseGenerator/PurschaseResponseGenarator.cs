using EventTicketSystem.Dto.Response;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Application.ResponseGenerators
{
    public static class PurchaseResponseGenerator
    {
        public static PurchaseTicketResponse ToPurchaseTicketResponse(Purchase purchase)
        {
            return new PurchaseTicketResponse
            {
                PurchaseId = purchase.PurchaseId,
                EventId = purchase.EventId,
                TicketCount = purchase.Quantity,
                TotalPrice = purchase.TotalPrice,
                PurchaseDate = purchase.PurchaseDate
            };
        }

        public static UserEventResponse ToUserEventResponse(Purchase purchase)
        {
            return new UserEventResponse
            {
                PurchaseId = purchase.PurchaseId,
                PurchaseDate = purchase.PurchaseDate,
                Quantity = purchase.Quantity,
                TotalPrice = purchase.TotalPrice,
                EventName = purchase.Event.EventName,
                EventCategory = purchase.Event.EventCategory,
                EventStartDate = purchase.Event.StartDate,
                EventLocation = purchase.Event.Location,
            };
        }
    }
}
