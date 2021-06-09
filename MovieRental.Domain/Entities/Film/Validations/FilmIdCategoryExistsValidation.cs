using FluentValidation;
using MovieRental.Domain.Adapters.Repositories;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmIdCategoryExistsValidation : AbstractValidator<Entities.Film.Film>
    {
        private readonly IFilmRepositoryAdapter _filmRepositoryAdapter;
    
        public FilmIdCategoryExistsValidation(IFilmRepositoryAdapter filmRepositoryAdapter)
        {
            _filmRepositoryAdapter = filmRepositoryAdapter;
        }
    }
}
