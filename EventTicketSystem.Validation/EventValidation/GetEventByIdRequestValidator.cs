using EventTicketSystem.Dto.Request.EventRequest;
using FluentValidation;

public class GetEventByIdRequestValidator : AbstractValidator<GetEventByIdRequest>
{
    public GetEventByIdRequestValidator()
    {
        RuleFor(x => x.EventId)
            .GreaterThan(0).WithMessage("Event ID 0'dan büyük olmalı");
    }
}
