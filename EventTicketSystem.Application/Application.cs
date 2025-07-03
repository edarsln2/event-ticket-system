using EventTicketSystem.Dto.Request;
using EventTicketSystem.Dto.Response;
using EventTicketSystem.Dto.Responses;
using EventTicketSystem.Service;

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
            var insertedEvent = _eventService.InsertEvent(request);

            return new InsertEventResponse
            {
                EventId = insertedEvent.EventId
            };
        }

        public void DeleteEvent(int eventId)
        {
            _eventService.DeleteEvent(eventId);
        }

        public GetEventByIdResponse GetEventById(int eventId)
        {
            var evnt = _eventService.GetEventById(eventId);

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
                AvailableTickets = evnt.TotalCapacity - evnt.TicketSold
            };
        }

        public List<GetEventListResponse> GetEventList()
        {
            var events = _eventService.GetEventList();

            return events.Select(e => new GetEventListResponse
            {
                EventId = e.EventId,
                EventCategory = e.EventCategory,
                EventName = e.EventName,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Location = e.Location,
                Price = e.Price,
                AvailableTickets = e.TotalCapacity - e.TicketSold
            }).ToList();
        }

        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            var insertedUser = _userService.RegisterUser(request);

            return new RegisterUserResponse
            {
                UserId = insertedUser.UserId,
            };
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request)
        {
            var user = _userService.GetUserById(request.UserId);

            var evnt = _eventService.GetEventById(request.EventId);

            if (!_eventService.IsEventActive(request.EventId))
            {
                throw new InvalidOperationException("Etkinlik aktif değil.");
            }

            if (_eventService.GetAvailableCapacity(request.EventId) < request.Quantity)
            {
                throw new InvalidOperationException("Yeterli kapasite yok.");
            }

            _eventService.SellTickets(request.EventId, request.Quantity);

            var purchase = _purchaseService.PurchaseTicket(user, evnt, request.Quantity);

            return new PurchaseTicketResponse
            {
                PurchaseId = purchase.PurchaseId,
                EventId = purchase.EventId,
                TicketCount = purchase.Quantity,
                TotalPrice = purchase.TotalPrice,
                PurchaseDate = purchase.PurchaseDate
            };
        }

        public List<UserEventResponse> GetUserEvents(UserEventRequest request)
        {
            var user = _userService.GetUserById(request.UserId); 

            var purchases = _purchaseService.GetUserPurchases(request.UserId); 

            return purchases.Select(p => new UserEventResponse
            {
                PurchaseId = p.PurchaseId,
                PurchaseDate = p.PurchaseDate,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice,
                EventId = p.Event.EventId,
                EventName = p.Event.EventName,
                EventCategory = p.Event.EventCategory,
                EventStartDate = p.Event.StartDate,
                EventEndDate = p.Event.EndDate,
                EventLocation = p.Event.Location,
                EventPrice = p.Event.Price
            }).ToList();
        }
    }
}
         






