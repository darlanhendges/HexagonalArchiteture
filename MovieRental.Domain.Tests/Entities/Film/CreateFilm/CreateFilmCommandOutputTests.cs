using MovieRental.Domain.Entities.Film.CreateFilm;
using System;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.CreateFilm
{
    public class CreateFilmCommandOutputTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(0)]
        public void CreateOutput_IsCorrect(int id)
        {
            var dateTime = DateTime.Now;

            var response = new CreateFilmCommandOutput(id, dateTime);
            Assert.Equal(response.Id, id);
            Assert.Equal(response.CreatedAt, dateTime);
        }

    }
}
