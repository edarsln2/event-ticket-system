using EventTicketSystem.Dto.Request;
using EventTicketSystem.Entity;
using EventTicketSystem.Factory;
using EventTicketSystem.Repository;
using Microsoft.EntityFrameworkCore;

namespace EventTicketSystem.Service
{
    public class EventService
    {
        private readonly EventRepository _repositoryEvent;
        private readonly EventFactory _factoryEvent;

        public EventService(EventRepository repositoryEvent, EventFactory factoryEvent)
        {
            _repositoryEvent = repositoryEvent;
            _factoryEvent = factoryEvent;
        }

        public Event InsertEvent(InsertEventRequest request)
        {
            var evnt = _factoryEvent.CreateEvent(request);
            return _repositoryEvent.InsertEvent(evnt);
        }

        public void DeleteEvent(int eventId)
        {
            var existingEvent = _repositoryEvent.GetEventById(eventId);

            if (existingEvent == null)
            {
                throw new InvalidOperationException("Silinecek etkinlik bulunamadı.");
            }

            _repositoryEvent.DeleteEvent(eventId);
        }

        public List<Event> GetEventList()
        {
            return _repositoryEvent.GetEventList();
        }

        public Event GetEventById(int eventId)
        {
            var evnt = _repositoryEvent.GetEventById(eventId);

            if (evnt == null)
            {
                throw new InvalidOperationException("Etkinlik bulunamadı.");
            }

            return evnt;
        }

        public void SellTickets(int eventId, int quantity)
        {
            var evnt = GetEventById(eventId);
            evnt.SellTickets(quantity);
            _repositoryEvent.UpdateCapacity(evnt);
        }

        public bool IsEventActive(int eventId)
        {
            var evnt = GetEventById(eventId);
            return evnt.StartDate <= DateTime.Now && evnt.EndDate >= DateTime.Now;
        }

        public int GetAvailableCapacity(int eventId)
        {
            var evnt = GetEventById(eventId);
            return evnt.TotalCapacity - evnt.TicketSold;
        }
    }
}