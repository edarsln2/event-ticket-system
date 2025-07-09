using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Entity
{
    [Table("purchases")]
    public class Purchase
    {
        [Column("purchaseid")]
        public int PurchaseId { get; set; }

        [Column("userid")]
        public int? UserId { get; set; }

        [ForeignKey("Event")]
        [Column("eventid")]
        public int EventId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("totalprice")]
        public decimal TotalPrice { get; set; }

        [Column("purchasedate")]
        public DateTime PurchaseDate { get; set; }
    }
}
