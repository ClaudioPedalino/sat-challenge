using FluentValidation;
using Sat.Recruitment.Application.Commands;

namespace Sat.Recruitment.Application.Validators
{
    public class CreateAuthUserCommandValidator : AbstractValidator<RegisterAuthUserCommand>
    {
        public CreateAuthUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(70);
        }
    }
}
