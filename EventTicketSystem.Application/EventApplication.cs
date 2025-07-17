using EventTicketSystem.Service;
using EventTicketSystem.Application.ResponseGenerators;
using EventTicketSystem.Dto.Request.EventRequest;
using EventTicketSystem.Dto.Response.EventResponse;

public class EventApplication
{
    private readonly EventService _eventService;

    public EventApplication(EventService eventService)
    {
        _eventService = eventService;
    }

    public InsertEventResponse InsertEvent(InsertEventRequest request)
    {
        var evnt = _eventService.InsertEvent(request.Category, request.Name, request.StartDate, request.EndDate, request.Location, request.Price, request.TotalCapacity);
        return EventResponseGenerator.ToInsertEventResponse(evnt);
    }

    public void DeleteEvent(DeleteEventRequest request)
    {
        _eventService.DeleteEvent(request.EventId);
    }

    public GetEventByIdResponse GetEventById(GetEventByIdRequest request)
    {
        var evnt = _eventService.GetEventById(request.EventId);
        return EventResponseGenerator.ToGetEventByIdResponse(evnt);
    }

    public List<GetEventListResponse> GetEventList(GetEventListRequest request)
    {
        var events = _eventService.GetEventList();
        return EventResponseGenerator.ToGetEventListResponse(events);
    }
}
