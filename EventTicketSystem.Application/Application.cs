using EventTicketSystem.Service;
using EventTicketSystem.Dto.Request;
using EventTicketSystem.Dto.Response;
using EventTicketSystem.Application.ResponseGenerators;
using EventTicketSystem.Entity;
using EventTicketSystem.Infrastructure;

namespace EventTicketSystem.Application
{
    public class EventApplication
    {
        private readonly EventService _eventService;
        private readonly UserService _userService;
        private readonly PurchaseService _purchaseService;

        public EventApplication(EventService eventService, UserService userService, PurchaseService purchaseService)
        {
            _eventService = eventService;
            _userService = userService;
            _purchaseService = purchaseService;
        }

        public InsertEventResponse InsertEvent(InsertEventRequest request)
        {
            var insertEvent = _eventService.InsertEvent(request.Category, request.Name, request.StartDate, request.EndDate, request.Location, request.Price,request.TotalCapacity);
            return EventResponseGenerator.ToInsertEventResponse(insertEvent);
        }
        
        public void DeleteEvent(int eventId)
        {
            _eventService.DeleteEvent(eventId);
        }

        public GetEventByIdResponse GetEventById(int eventId)
        {
            var evnt = _eventService.GetEventById(eventId);
            return EventResponseGenerator.ToGetEventByIdResponse(evnt);
        }

        public List<GetEventListResponse> GetEventList()
        {
            var events = _eventService.GetEventList();
            return EventResponseGenerator.ToGetEventListResponse(events);
        }

        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            var registerUser = _userService.RegisterUser(request.UserName, request.Email, request.Password);
            return UserResponseGenerator.ToRegisterUserResponse(registerUser);
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request)
        {
            var user = _userService.GetUserById(request.UserId);
            var evnt = _eventService.SellTicket(request.EventId, request.Quantity);
            var purchase = _purchaseService.PurchaseTicket(request.UserId, request.EventId, request.Quantity, evnt.Price);
            return PurchaseResponseGenerator.ToPurchaseTicketResponse(purchase);
        }

        public List<UserEventResponse> GetUserEvents(UserEventRequest request)
        { 
            var user = _userService.GetUserById(request.UserId);
            var purchases = _purchaseService.GetUserPurchases(request.UserId);
            return PurchaseResponseGenerator.ToUserEventResponse(purchases);
        }
    }
}






