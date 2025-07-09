using FluentValidation;
using EventTicketSystem.Dto.Request.PurchaseRequest;

namespace EventTicketSystem.Validation.PurchaseValidation
{
    public class PurchaseTicketWithLoginRequestValidator : AbstractValidator<PurchaseTicketWithLoginRequest>
    {
        public PurchaseTicketWithLoginRequestValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("En az 1 bilet alınmalıdır.");
        }
    }
}
