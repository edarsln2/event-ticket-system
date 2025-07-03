using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Entity
{
    [Table("events")]
    public class Event
    {
        [Column("eventid")]
        public int EventId { get; set; }

        [Column("eventcategory")]
        public string EventCategory { get; set; }

        [Column("eventname")]
        public string EventName { get; set; }

        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Column("enddate")]
        public DateTime EndDate { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("totalcapacity")]
        public int TotalCapacity { get; set; }

        [Column("ticketsold")]
        public int TicketSold { get; set; }

        public void SellTickets(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Satılacak bilet adedi pozitif olmalı.");

            int availableCapacity = TotalCapacity - TicketSold;
            if (availableCapacity < quantity)
                throw new InvalidOperationException("Yeterli kapasite yok.");

            TicketSold += quantity;
        }
    }
}
