using FluentValidation;
using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Film.Validations;

namespace MovieRental.Domain.Entities.Film.CreateFilm.Specs
{
    public class FilmIsValidToCreateSpec : AbstractValidator<Entities.Film.Film>
    {

        public FilmIsValidToCreateSpec(ICategoryRepositoryAdapter _categoryRepositoryAdapter)
        {
            Include(new FilmIsValidSpec());
            Include(new FilmIdCategoryExistsValidation(_categoryRepositoryAdapter));
        }
    }
}
