using FluentValidation;
using Domain.Interfaces;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<IUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName can't be empty")
                .NotNull().WithMessage("UserName can't be empty")
                .Length(1, 50).WithMessage("UserName lenght must be 1 to 50 symbols");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name can't be empty")
                .NotNull().WithMessage("First Name can't be empty")
                .Length(1, 50).WithMessage("First Name lenght must be 1 to 50 symbols");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name can't be empty")
               .NotNull().WithMessage("Last Name can't be empty")
               .Length(1, 50).WithMessage("Last Name lenght must be 1 to 50 symbols");

            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can't be empty")
               .NotNull().WithMessage("Age can't be empty");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Wrong Email")
               .NotNull().WithMessage("Email can't be empty");

            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary can't be empty")
               .NotNull().WithMessage("Salary can't be empty");
        }
    }
}
