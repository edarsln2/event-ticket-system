using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class EventFactory
    {
        public Event CreateEvent(string category, string name, DateTime startDate, DateTime endDate, string location, decimal price, int totalCapacity)
        {

            return new Event
            {
                Category = category,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                Price = price,
                TotalCapacity = totalCapacity,
                TicketSold = 0,
                AvailableCapacity = totalCapacity,
            };
        }
    }
}
