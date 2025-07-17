using EventTicketSystem.Repository;
using EventTicketSystem.Entity;
using EventTicketSystem.Factory;

namespace EventTicketSystem.Service;

public class DiscountService
{
    private readonly DiscountRepository _discountRepository;
    private readonly DiscountFactory _discountFactory;

    public DiscountService(DiscountRepository discountRepository, DiscountFactory discountFactory)
    {
        _discountRepository = discountRepository;
        _discountFactory = discountFactory;
    }

    public Discount InsertDiscount(string discountName, decimal percentage, bool firstPurchaseOnly)
    {
        var discount = _discountFactory.Create(discountName, percentage, firstPurchaseOnly);
        return _discountRepository.InsertDiscount(discount);
    }

    public void DeleteDiscount(int discountId)
    {
        _discountRepository.DeleteDiscount(discountId);
    }

    public List<Discount> GetAllDiscount()
    {
        return _discountRepository.GetAllDiscount();
    }

    public decimal? GetMatchedDiscountRate(bool isBirthday, bool isFirstPurchase, bool isStudent, bool isLastWeek)
    {
        var discounts = _discountRepository.GetAllDiscount();

        var filterDiscounts = discounts.Where(d =>
            (isBirthday && d.DiscountName.ToLower().Contains("doğum günü")) ||
            (isFirstPurchase && d.DiscountName.ToLower().Contains("ilk sipariş")) ||
            (isStudent && d.DiscountName.ToLower().Contains("öğrenci")) ||
            (isLastWeek && d.DiscountName.ToLower().Contains("son hafta")));

        return filterDiscounts
            .OrderByDescending(d => d.Percentage)
            .FirstOrDefault()?.Percentage;
    }
}