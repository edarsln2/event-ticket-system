using EventTicketSystem.Dto.Response.PurchaseResponse;
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

        public static List<UserPurchaseResponse> ToUserPurchaseResponse(List<Purchase> purchases)
        {
            return purchases.Select(p => new UserPurchaseResponse
            {
                PurchaseId = p.PurchaseId,
                EventId = p.EventId,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice
            }).ToList();
        }
    }
}
