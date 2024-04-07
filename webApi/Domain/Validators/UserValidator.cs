using FluentValidation;
using webApi.Domain.Entities;

namespace webApi.Domain.Validators
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
        }

    }
}