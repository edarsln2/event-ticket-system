using EventTicketSystem.Dto.Response.EventResponse;
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
                Category = evnt.Category,
                Name = evnt.Name,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                Location = evnt.Location,
                Price = evnt.Price,
                TotalCapacity = evnt.TotalCapacity,
                TicketSold = evnt.TicketSold,
                AvailableCapacity = evnt.AvailableCapacity
            };
        }

        public static List<GetEventListResponse> ToGetEventListResponse(List<Event> eventList)
        {
            return eventList.Select(evnt => new GetEventListResponse
            {
                EventId = evnt.EventId,
                Category = evnt.Category,
                Name = evnt.Name,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                Location = evnt.Location,
                Price = evnt.Price,
                AvailableCapacity = evnt.AvailableCapacity
            }).ToList();
        }
    }
}