using EventTicketSystem.Entity;

namespace EventTicketSystem.Factory
{
    public class EventFactory
    {
        public Event CreateEvent(string eventCategory, string eventName, DateTime startDate, DateTime endDate, string location, decimal price, int totalCapacity)
        {

            return new Event
            {
                EventCategory = eventCategory,
                EventName = eventName,
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
