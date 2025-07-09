using EventTicketSystem.Entity;
using System.Diagnostics;

namespace EventTicketSystem.Factory
{
    public class PurchaseFactory
    {
        public Purchase CreatePurchase(int? userId, int eventId, int quantity, decimal price)
        {
            return new Purchase
            {
                UserId = userId,
                EventId = eventId,
                Quantity = quantity,
                TotalPrice = quantity * price,
                PurchaseDate = DateTime.UtcNow
            };
        }

    }
}

