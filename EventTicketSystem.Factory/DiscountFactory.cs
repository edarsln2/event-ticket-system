using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class DiscountFactory
    {
        public Discount Create(string discountName, decimal percentage, bool firstPurchaseOnly)
        {
            return new Discount
            {
                DiscountName = discountName,
                Percentage = percentage,
                FirstPurchaseOnly = firstPurchaseOnly,
            };
        }
    }
}