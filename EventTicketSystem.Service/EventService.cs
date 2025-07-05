using EventTicketSystem.Entity;
using EventTicketSystem.Factory;

namespace EventTicketSystem.Service
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;
        private readonly EventFactory _eventFactory;

        public EventService(EventRepository eventRepository, EventFactory eventFactory)
        {
            _eventRepository = eventRepository;
            _eventFactory = eventFactory;
        }

        public Event InsertEvent(string eventCategory, string eventName, DateTime startDate, DateTime endDate, string location, decimal price, int totalCapacity)
        {
            var evnt = _eventFactory.CreateEvent(eventCategory, eventName, startDate, endDate, location, price, totalCapacity);
            return _eventRepository.InsertEvent(evnt);
        }

        public void DeleteEvent(int eventId)
        {
            var evnt = GetEventByIdOrThrow(eventId);
            _eventRepository.DeleteEvent(evnt);
        }

        public Event? GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }

        public List<Event> GetEventList()
        {
            return _eventRepository.GetEventList();
        }

        public Event GetEventByIdOrThrow(int eventId)
        {
            var evnt = _eventRepository.GetEventById(eventId);
            if (evnt == null)
            {
                throw new Exception("Etkinlik bulunamadı.");
            }
            return evnt;
        }

        public Event SellTicket(int eventId, int quantity)
        {
            var evnt = GetEventByIdOrThrow(eventId);

            if (evnt.AvailableCapacity < quantity)
            {
                throw new Exception("Yetersiz kapasite");
            }

            evnt.TicketSold += quantity;
            evnt.AvailableCapacity -= quantity;
            _eventRepository.UpdateTicketSold(evnt);
            return evnt;
        }
    }
}
