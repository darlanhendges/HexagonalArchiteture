using MovieRental.Domain.Entities.Film.Validations;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.Validations
{
    public class FilmNameIsnotEmptyValidationTests
    {
        public readonly string DESCRIPTION = "DESCRIÇÃO VALIDA PORQUE TEM MUITOS CARACTERES......";
        public readonly int CATEGORYID = 100;

        [Fact]
        public void ValidateName_Empty_ReturnFalse()
        {
            // Arrange
            var validation = new FilmNameIsnotEmptyValidation();
            var film = new Domain.Entities.Film.Film("", DESCRIPTION, CATEGORYID);

            // Act
            var result = validation.Validate(film);

            // Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public void ValidateName_CharactersNotEnough_ReturnFalse()
        {
            // Arrange
            var validation = new FilmNameIsnotEmptyValidation();
            var film = new Domain.Entities.Film.Film(" teste insu", DESCRIPTION, CATEGORYID);

            // Act
            var result = validation.Validate(film);

            // Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public void ValidateName_CharactersEnough_ReturnTrue()
        {
            // Arrange
            var validation = new FilmNameIsnotEmptyValidation();
            var film = new Domain.Entities.Film.Film(" Nome valido porque tem mais d", DESCRIPTION, CATEGORYID);

            // Act
            var result = validation.Validate(film);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
