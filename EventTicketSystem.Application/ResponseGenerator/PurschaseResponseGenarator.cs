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

        public static List<UserEventResponse> ToUserEventResponse(List<Purchase> purchases)
        {
            return purchases.Select(p => new UserEventResponse
            {
                PurchaseId = p.PurchaseId,
                EventId = p.EventId,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice,
            }).ToList();
        }
    }
}
