using EventTicketSystem.Entity;
using EventTicketSystem.Factory;
using EventTicketSystem.Infrastructure;

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

        public Event InsertEvent(string category, string name, DateTime startDate, DateTime endDate, string location, decimal price, int totalCapacity)
        {
            var evnt = _eventFactory.CreateEvent(category, name, startDate, endDate, location, price, totalCapacity);
            return _eventRepository.InsertEvent(evnt);
        }

        public void DeleteEvent(int eventId)
        {
            var evnt = _eventRepository.GetEventById(eventId);
            if (evnt == null)
            {
                throw new Exception("Silinecek etkinlik bulunamadı.");
            }

            _eventRepository.DeleteEvent(evnt);
        }


        public Event GetEventById(int eventId)
        {
            var evnt = _eventRepository.GetEventById(eventId);
            if (evnt == null)
            {
                throw new Exception("Etkinlik bulunamadı.");
            }
            return evnt;
        }

        public List<Event> GetEventList()
        {
            return _eventRepository.GetEventList();
        }

        public Event SellTicket(int eventId, int quantity)
        {
            var evnt = GetEventById(eventId);

            if (evnt.AvailableCapacity < quantity)
            {
                throw new Exception("Yetersiz kapasite");
            }

            evnt.TicketSold += quantity;
            evnt.AvailableCapacity -= evnt.TotalCapacity - evnt.TicketSold;
            _eventRepository.UpdateTicketSold(evnt);
            return evnt;
        }
    }
}
