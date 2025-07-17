using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Entity
{
    [Table("discounts")]
    public class Discount
    {
        [Column("discountid")]
        public int DiscountId { get; set; }

        [Column("discountname")]
        public string DiscountName { get; set; }

        [Column("percentage")]
        public decimal Percentage { get; set; }

        [Column("firstpurchaseonly")]
        public bool FirstPurchaseOnly { get; set; }
    }
}
