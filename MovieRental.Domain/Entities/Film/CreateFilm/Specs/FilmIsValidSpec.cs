using FluentValidation;
using MovieRental.Domain.Entities.Film.Validations;

namespace MovieRental.Domain.Entities.Film.CreateFilm.Specs
{
    public class FilmIsValidSpec : AbstractValidator<Entities.Film.Film>
    {
        public FilmIsValidSpec()
        {
            Include(new FilmNameIsnotEmptyValidation());
            Include(new FilmDescriptionIsValidValidation());
            Include(new FilmIdCategoryGreatherThanZeroValidation());
        }
    }
}
