using FluentValidation;
using EventTicketSystem.Dto.Request.UserRequest;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter girmelisiniz.");
    }
}
