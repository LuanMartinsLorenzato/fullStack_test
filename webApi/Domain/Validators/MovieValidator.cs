using FluentValidation;
using webApi.Domain.Entities;

namespace webApi.Domain.Validators
{
    // Utilizei FluentValidation para as validações de campos obrigatórios.
    // AbstractValidator class base para utilizar os métodos de validação do FluentValidation.
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            // Cria uma validação onde Title deve conter algum valor.
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Titulo");

            RuleFor(x => x.Poster)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Poster");

            RuleFor(x => x.Released)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Lançamento");

            RuleFor(x => x.Runtime)
            .NotEmpty()
            .WithMessage("Campo obrigatório: Duração");
        }
    }
}