using EventTicketSystem.Data;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Repository;
public class DiscountRepository
{
    private readonly AppDbContext _context;

    public DiscountRepository(AppDbContext context)
    {
        _context = context;
    }

    public Discount InsertDiscount(Discount discount)
    {
        _context.Discounts.Add(discount);
        _context.SaveChanges();
        return discount;
    }

    public void DeleteDiscount(int discountId)
    {
        var discount = _context.Discounts.FirstOrDefault(d => d.DiscountId == discountId);
        if (discount != null)
        {
            _context.Discounts.Remove(discount);
            _context.SaveChanges();
        }
    }
    public List<Discount> GetAllDiscount()
    {
        return _context.Discounts.ToList();
    }
}