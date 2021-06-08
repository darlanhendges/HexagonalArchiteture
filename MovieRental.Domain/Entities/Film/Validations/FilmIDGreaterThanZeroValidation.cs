using FluentValidation;
using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmIDGreaterThanZeroValidation : AbstractValidator<Entities.Film.Film>
    {
        public FilmIDGreaterThanZeroValidation()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage(Globalization.IdFilmIsInvalid());
        }
    }
}
