using EventTicketSystem.Entity;
using EventTicketSystem.Repository;
using EventTicketSystem.Factory;

namespace EventTicketSystem.Service 
{
    public class PurchaseService
    {
        private readonly PurchaseRepository _purchaseRepository;
        private readonly PurchaseFactory _purchaseFactory;

        public PurchaseService(PurchaseRepository purchaseRepository, PurchaseFactory purchaseFactory)
        {
            _purchaseRepository = purchaseRepository;
            _purchaseFactory = purchaseFactory;
        }

        public Purchase PurchaseTicket(int user, int evnt, int quantity, decimal eventPrice)
        {
            var purchase = _purchaseFactory.CreatePurchase(user, evnt, quantity, eventPrice);
            return _purchaseRepository.PurchaseTicket(purchase);
        }

        public List<Purchase> GetUserPurchases(int userId)
        {
            return _purchaseRepository.GetPurchasesByUserId(userId);
        }
    }
}
