using EventTicketSystem.Dto.Request.PurchaseRequest;
using FluentValidation;

namespace EventTicketSystem.Validation.PurchaseValidation
{
    public class PurchaseTicketAsGuestRequestValidator : AbstractValidator<PurchaseTicketAsGuestRequest>
    {
        public PurchaseTicketAsGuestRequestValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.EventId)
                .GreaterThan(0).WithMessage("Etkinlik ID geçerli olmalıdır.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Satın alınacak bilet adedi 0'dan büyük olmalıdır.");
        }
    }
}
