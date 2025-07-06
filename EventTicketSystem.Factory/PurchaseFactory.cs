using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class PurchaseFactory
    {
        public Purchase CreatePurchase(int userId, int eventId, int quantity, decimal eventPrice)
        {
            return new Purchase
            {
                UserId = userId,
                EventId = eventId,
                Quantity = quantity,
                TotalPrice = quantity * eventPrice,
                PurchaseDate = DateTime.UtcNow
            };
        }

    }
}

