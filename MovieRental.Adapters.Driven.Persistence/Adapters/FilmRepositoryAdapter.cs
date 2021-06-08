using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Film;
using System;
using System.Threading.Tasks;

namespace MovieRental.Adapters.Driven.Persistence.Adapters
{
    public class FilmRepositoryAdapter : IFilmRepositoryAdapter
    {
        public Task<Film> CreateAsync(Film newFilm)
        {
            throw new NotImplementedException();
        }
    }
}
