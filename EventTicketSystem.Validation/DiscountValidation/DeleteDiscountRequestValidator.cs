using EventTicketSystem.Dto.Request.DiscountRequest;
using FluentValidation;

namespace EventTicketSystem.Validation.DiscountValidation
{
    public class DeleteDiscountRequestValidator : AbstractValidator<DeleteDiscountRequest>
    {
        public DeleteDiscountRequestValidator() 
        {
            RuleFor(x => x.DiscountId)
                .GreaterThan(0).WithMessage("Discount ID 0'dan büyük olmalı");
        }
    }

}
