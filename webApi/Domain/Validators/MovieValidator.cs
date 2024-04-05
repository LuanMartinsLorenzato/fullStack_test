using FluentValidation;
using webApi.Domain.Entities;

namespace webApi.Domain.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
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