using MovieRental.Adapters.Driven.Persistence.Tests.Common;
using MovieRental.Core.Application.UseCases.CreateFilmUseCase;
using MovieRental.Domain.Adapters.UseCases;
using Xunit;

namespace MovieRental.Core.Application.Tests.UseCases.CreateFilmUseCase
{
    public class CreateFilmUseCaseServiceTests
    {
        private ICreateFilmUseCaseServiceAdapter _createFilmUseCaseServiceAdapter;

        public CreateFilmUseCaseServiceTests()
        {
            _createFilmUseCaseServiceAdapter = new CreateFilmUseCaseHandler(new FilmRepositoryAdapterFake());
        }

        [Theory]
        [InlineData(" ", "    ", -10)]
        [InlineData(null, null, 0)]
        [InlineData(null, "", 0)]
        [InlineData("", "", -225)]
        [InlineData("", null, -225)]
        [InlineData(" ", null, -225)]
        public async void IsEverything_IsFalse(string name, string description, int category)
        {
            var response = await _createFilmUseCaseServiceAdapter.CreateFilmAsync(new Domain.Entities.Film.CreateFilm.CreateFilmCommand(name, description, category));
            Assert.False(response.IsValid);
        }

        [Theory]
        [InlineData("Darlan Hendges valdo", "Descriação bem válida Descriação bem válidaDescriação bem válidaDescriação bem válidaDescriação bem válidaDescriação bem válidaDescriação bem válida ", 220)]
        public async void IsEverything_True(string name, string description, int category)
        {
            var response = await _createFilmUseCaseServiceAdapter.CreateFilmAsync(new Domain.Entities.Film.CreateFilm.CreateFilmCommand(name, description, category));
            Assert.True(response.IsValid);
            Assert.NotEqual(0, response.Result.Id);
        }

    }
}
