using FluentValidation;
using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmIdCategoryGreatherThanZeroValidation : AbstractValidator<Entities.Film.Film>
    {
        public FilmIdCategoryGreatherThanZeroValidation()
        {
            RuleFor(x => x.IdCategory).GreaterThan(0).WithMessage(Globalization.CategoryInvalid());
        }
    }
}
