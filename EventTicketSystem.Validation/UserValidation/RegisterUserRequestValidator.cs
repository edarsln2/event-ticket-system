using FluentValidation;
using EventTicketSystem.Dto.Request.UserRequest;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.").MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.")
            .MaximumLength(100).WithMessage("Email 100 karakteri geçemez.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı.")
            .Matches("[A-Z]").WithMessage("En az 1 büyük harf içermeli")
            .Matches("[a-z]").WithMessage("En az 1 küçük harf içermeli")
            .Matches("[0-9]").WithMessage("En az 1 rakam içermeli");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Doğum tarihi zorunludur.")
            .LessThan(DateTime.Now).WithMessage("Doğum tarihi bugünden küçük olmalıdır.");
    }
}
