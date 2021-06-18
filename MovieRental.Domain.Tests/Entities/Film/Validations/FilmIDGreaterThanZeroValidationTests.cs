using MovieRental.Domain.Core.CrossCutting.Entities;
using MovieRental.Domain.Entities.Film.Validations;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.Validations
{
    public  class FilmIDGreaterThanZeroValidationTests
    {
        private readonly string NAME_VALID = "NOME VALIDO DE 20 ";
        public readonly string DESCRIPTION = "DESCRIÇÃO VALIDA PORQUE TEM MUITOS CARACTERES......";
        public readonly int CATEGORYID = 100;

        [Fact]
        public void ValidateId_GreatherThanzero_ReturnFalse()
        {
            // Arrange
            var validation = new FilmIDGreaterThanZeroValidation();
            var film = new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION, CATEGORYID);
            film.LoadId(0);

            // Act
            var result = validation.Validate(film);

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.True(result.Errors[0].ErrorMessage.Equals(Globalization.IdFilmIsInvalid()));
        }

        [Fact]
        public void ValidateId_GreatherThanzero_ReturnTrue()
        {
            // Arrange
            var validation = new FilmIDGreaterThanZeroValidation();
            var film = new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION, CATEGORYID);
            film.LoadId(100);

            // Act
            var result = validation.Validate(film);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
