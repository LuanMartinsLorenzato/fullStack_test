using FluentValidation;

namespace webApi.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Campo obrigatório");
        }

    }
}