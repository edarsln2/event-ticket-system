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

        public Purchase PurchaseTicket(int? userId, int eventId, int quantity, decimal price)
        {
            var purchase = _purchaseFactory.CreatePurchase(userId, eventId, quantity, price);
            return _purchaseRepository.PurchaseTicket(purchase);
        }

        public List<Purchase> GetUserPurchases(int userId)
        {
            return _purchaseRepository.GetPurchasesByUserId(userId);
        }

        public bool IsFirstPurchase(int userId)
        {
            return _purchaseRepository.IsFirstPurchase(userId);
        }
    }
}
