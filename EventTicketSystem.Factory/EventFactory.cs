using EventTicketSystem.Entity;
using EventTicketSystem.Dto.Request;

namespace EventTicketSystem.Factory
{
    public class EventFactory
    {
        public Event CreateEvent(InsertEventRequest request)
        {
            return new Event
            {
                EventCategory = request.EventCategory,
                EventName = request.EventName,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                Price = request.Price,
                TotalCapacity = request.TotalCapacity,
                TicketSold = 0
            };
        }
    }
}

//namespace EventTicketSystem.Factory
//{
//    public class EventFactory
//    {
//        private readonly IMapper _mapper;

//        public EventFactory(IMapper mapper)
//        {
//            _mapper = mapper;
//        }

//        public Event CreateEvent(InsertEventRequest request)
//        {
//            return _mapper.Map<Event>(request);
//        }
//    }
//}
