using MovieRental.Domain.Entities.Film;
using System.Threading.Tasks;

namespace MovieRental.Domain.Adapters.Repositories
{
    public interface IFilmRepositoryAdapter
    {
        Task<Film> CreateAsync(Film newFilm);

    }
}
