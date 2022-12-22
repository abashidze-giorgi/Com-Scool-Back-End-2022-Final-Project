using FluentValidation;
using Domain.Interfaces;

namespace Domain.Validators
{
    public class LoanValidator : AbstractValidator<ILoan>
    {
        public LoanValidator()
        {
            RuleFor(x => x.Currency).NotNull().WithMessage("Currency can't be empty");

            RuleFor(x => x.Status).IsInEnum().WithMessage("Wrong loan status")
                .NotNull().WithMessage("Status can't be empty");

            RuleFor(x => x.Type).IsInEnum().WithMessage("Wrong loan type")
                .NotNull().WithMessage("Type can't be empty");

            RuleFor(x => x.Amount).NotNull().WithMessage("Amount can't be empty")
                .GreaterThan(0).WithMessage("Amount must be num and between 1000 - 150 000");

            RuleFor(x => x.Period).InclusiveBetween(3, 72).WithMessage("Period must be between 3 -72 months.")
                .NotNull().WithMessage("Period can't be null");

        }
    }
}
