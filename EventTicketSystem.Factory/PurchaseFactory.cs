using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class PurchaseFactory
    {
        public Purchase CreatePurchase(User user, Event evnt, int quantity)
        {
            return new Purchase
            {
                UserId = user.UserId,
                EventId = evnt.EventId,
                Quantity = quantity,
                TotalPrice = evnt.Price * quantity,
                PurchaseDate = DateTime.UtcNow
            };
        }
    }
}

