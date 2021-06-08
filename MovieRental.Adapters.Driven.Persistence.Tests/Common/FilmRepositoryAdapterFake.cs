using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Film;
using System;
using System.Threading.Tasks;

namespace MovieRental.Adapters.Driven.Persistence.Tests.Common
{
    public class FilmRepositoryAdapterFake : IFilmRepositoryAdapter
    {
        public Task<Film> CreateAsync(Film newFilm)
        {
            newFilm.LoadId(new Random().Next(100000));
            return Task.FromResult(newFilm);
        }
    }
}
