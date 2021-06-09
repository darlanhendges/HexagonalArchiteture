using FluentValidation;
using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Film.Validations;

namespace MovieRental.Domain.Entities.Film.CreateFilm.Specs
{
    public class FilmIsValidToCreateSpec : AbstractValidator<Entities.Film.Film>
    {

        public FilmIsValidToCreateSpec(IFilmRepositoryAdapter _filmRepositoryAdapter)
        {
            Include(new FilmIsValidSpec());
            Include(new FilmIdCategoryExistsValidation(_filmRepositoryAdapter));
        }
    }
}
