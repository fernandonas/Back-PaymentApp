using FluentValidation;
using Payment.Domain.Entity;

namespace Payment.Domain.Validations
{
    public class PaymentTypeValidator : AbstractValidator<PaymentType>
    {
        public PaymentTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não informado.");
        }
    }
}