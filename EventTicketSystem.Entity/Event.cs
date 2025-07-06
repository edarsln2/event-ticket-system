using System.ComponentModel.DataAnnotations.Schema;

namespace EventTicketSystem.Entity
{
    [Table("events")]
    public class Event
    {
        [Column("eventid")]
        public int EventId { get; set; }

        [Column("eventcategory")]
        public string Category { get; set; }

        [Column("eventname")]
        public string Name { get; set; }

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

        [Column("availablecapacity")]
        public int AvailableCapacity { get; set; }

    }
}
