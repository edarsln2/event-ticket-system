using AutoMapper;
using EventTicketSystem.Dto.Request;
using EventTicketSystem.Dto.Response;
using EventTicketSystem.Dto.Responses;
using EventTicketSystem.Entity;


namespace EventTicketSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsertEventRequest, Event>();
            CreateMap<RegisterUserRequest, User>();
            CreateMap<Event, GetEventListResponse>();
            CreateMap<Event, GetEventByIdResponse>();
            CreateMap<Purchase, PurchaseTicketResponse>()
                .ForMember(dest => dest.TicketCount, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
        }
    }
}
