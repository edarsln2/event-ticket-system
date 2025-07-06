using FluentValidation;
using EventTicketSystem.Dto.Request;

public class InsertEventRequestValidator : AbstractValidator<InsertEventRequest>
{
    public InsertEventRequestValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Etkinlik kategorisi boş olamaz.")
            .MaximumLength(50).WithMessage("Etkinlik kategorisi 50 karakterden uzun olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Etkinlik adı boş olamaz.")
            .MaximumLength(100).WithMessage("Etkinlik adı 100 karakterden uzun olamaz."); 

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.")
            .LessThan(x => x.EndDate).WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.")
            .Must(date => date >= DateTime.Today.Date).WithMessage("Başlangıç tarihi bugünden önce olamaz."); 

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("Bitiş tarihi boş olamaz.")
            .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("Bitiş tarihi başlangıç tarihinden sonra veya eşit olmalıdır.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Etkinlik yeri boş olamaz.")
            .MaximumLength(300).WithMessage("Etkinlik yeri 500 karakterden uzun olamaz."); 

        RuleFor(x => x.TotalCapacity)
            .GreaterThan(0).WithMessage("Toplam kapasite 0'dan büyük olmalıdır.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Bilet fiyatı sıfırdan büyük olmalıdır.");
    }
}

