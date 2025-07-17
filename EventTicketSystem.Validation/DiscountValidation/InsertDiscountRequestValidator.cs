using EventTicketSystem.Dto.Request.DiscountRequest;
using FluentValidation;

namespace EventTicketSystem.Validation.DiscountValidation
{
    public class InsertDiscountRequestValidator : AbstractValidator<InsertDiscountRequest>
    {
        public InsertDiscountRequestValidator()
        {
            RuleFor(x => x.DiscountName)
                .NotEmpty().WithMessage("İndirim adı boş olamaz.")
                .MaximumLength(100).WithMessage("İndirim adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Percentage)
                .GreaterThan(0).WithMessage("Yüzde oranı sıfırdan büyük olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Yüzde oranı 100'den büyük olamaz.");

            RuleFor(x => x.FirstPurchaseOnly)
                .NotNull().WithMessage("İlk satın alma kontrolü belirtilmelidir.");
        }
    }
}
