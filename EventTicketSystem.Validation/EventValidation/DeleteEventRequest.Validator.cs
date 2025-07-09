using EventTicketSystem.Dto.Request.EventRequest;
using FluentValidation;

public class DeleteEventRequestValidator : AbstractValidator<DeleteEventRequest>
{
    private readonly EventRepository _eventRepository;

    public DeleteEventRequestValidator(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;

        RuleFor(x => x.EventId)
            .GreaterThan(0)
            .Must(id => _eventRepository.GetEventById(id) != null)
            .WithMessage("Etkinlik bulunamadı.");
    }
}
