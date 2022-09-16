using FluentValidation;
using Payment.Domain.Entity;

namespace Payment.Domain.Validations
{
    public class PaymentInstituitionValidator : AbstractValidator<PaymentInstituition>
    {
        public PaymentInstituitionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não informado.");
        }
    }
}
