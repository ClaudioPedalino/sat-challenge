using FluentValidation;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(35);

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(70);

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(70);

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(21);

            RuleFor(x => x.UserType)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Must(BeValidUserType).WithMessage("The given UserType doesn´t match with any valid UserType");

            RuleFor(x => x.Money)
                .GreaterThan(0);
        }

        private bool BeValidUserType(UserType type) => type switch
        {
            UserType.Normal => true,
            UserType.SuperUser => true,
            UserType.Premium => true,
            _ => false,
        };
    }
}
