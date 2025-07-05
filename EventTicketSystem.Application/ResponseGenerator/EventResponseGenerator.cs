using EventTicketSystem.Dto.Response;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Application.ResponseGenerators
{
    public static class EventResponseGenerator
    {
        public static InsertEventResponse ToInsertEventResponse(Event evnt)
        {
            return new InsertEventResponse
            {
                EventId = evnt.EventId
            };
        }

        public static GetEventByIdResponse ToGetEventByIdResponse(Event evnt)
        {
            return new GetEventByIdResponse
            {
                EventCategory = evnt.EventCategory,
                EventName = evnt.EventName,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                Location = evnt.Location,
                Price = evnt.Price,
                TotalCapacity = evnt.TotalCapacity,
                TicketSold = evnt.TicketSold,
                AvailableCapacity = evnt.TotalCapacity - evnt.TicketSold
            };
        }

        public static GetEventListResponse ToGetEventListResponse(Event evnt)
        {
            return new GetEventListResponse
            {
                EventId = evnt.EventId,
                EventCategory = evnt.EventCategory,
                EventName = evnt.EventName,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                Location = evnt.Location,
                Price = evnt.Price,
                AvailableCapacity = evnt.TotalCapacity - evnt.TicketSold
            };
        }
    }
}
