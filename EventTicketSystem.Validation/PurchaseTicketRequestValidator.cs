using FluentValidation;
using EventTicketSystem.Dto.Request;

namespace EventTicketSystem.Validation
{
    public class PurchaseTicketRequestValidator : AbstractValidator<PurchaseTicketRequest>
    {
        public PurchaseTicketRequestValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("En az 1 bilet alınmalıdır.");
        }
    }
}
