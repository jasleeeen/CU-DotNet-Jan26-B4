using FluentValidation;
using FluentValidationDemo.DTOs;

namespace FluentValidationDemo
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Invalid User");

            RuleFor(x => x.ProductIds)
                .NotEmpty().WithMessage("Cart cannot be empty");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Invalid amount");
        }
    }
}