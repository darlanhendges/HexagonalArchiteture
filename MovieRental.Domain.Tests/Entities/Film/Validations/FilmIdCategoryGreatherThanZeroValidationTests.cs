using MovieRental.Domain.Core.CrossCutting.Entities;
using MovieRental.Domain.Entities.Film.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.Validations
{
    public class FilmIdCategoryGreatherThanZeroValidationTests
    {
        private readonly string NAME_VALID = "NOME VALIDO DE 20 ";
        public readonly string DESCRIPTION = "DESCRIÇÃO VALIDA PORQUE TEM MUITOS CARACTERES......";

        [Fact]
        public void ValidateIdCategory_GreatherThanzero_ReturnFalse()
        {
            // Arrange
            var validation = new FilmIdCategoryGreatherThanZeroValidation();

            // Act
            var result = validation.Validate(new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION, 0));

            // Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.True(result.Errors[0].ErrorMessage.Equals(Globalization.CategoryInvalid()));
        }

        [Fact]
        public void ValidateIdCategory_GreatherThanzero_ReturnTrue()
        {
            // Arrange
            var validation = new FilmIdCategoryGreatherThanZeroValidation();

            // Act
            var result = validation.Validate(new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION, 10));

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}
