﻿using EventTicketSystem.Dto.Request.EventRequest;
using FluentValidation;

public class DeleteEventRequestValidator : AbstractValidator<DeleteEventRequest>
{
    public DeleteEventRequestValidator()
    {
        RuleFor(x => x.EventId)
            .GreaterThan(0).WithMessage("Event ID 0'dan büyük olmalı");
    }
}


