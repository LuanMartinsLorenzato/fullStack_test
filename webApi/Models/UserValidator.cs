using FluentValidation;

namespace webApi.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Nome");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Email");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Senha");

            RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Role");
        }

    }
}