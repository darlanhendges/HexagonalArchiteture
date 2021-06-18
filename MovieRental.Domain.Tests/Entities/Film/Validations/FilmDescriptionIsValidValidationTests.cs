using MovieRental.Domain.Entities.Film.Validations;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.Validations
{
    public class FilmDescriptionIsValidValidationTests
    {
        private const string NAME_VALID = "iusdiu uihuuhas uhdauhadsuhdasuhadsuiia";
        private const int CATEGORY_VALID = 1;
        private Domain.Entities.Film.Film _film;
        private FilmDescriptionIsValidValidation _filmDescriptionIsValidValidation;

        public FilmDescriptionIsValidValidationTests()
        {
            _filmDescriptionIsValidValidation = new FilmDescriptionIsValidValidation();
        }

        [Theory]
        [InlineData("  ssss ")]
        [InlineData(" mnuitop opequena a")]
        [InlineData("     ")]
        [InlineData(null)]
        public void Description_IsInvalid_ReturnFalse(string description)
        {
            _film = new Domain.Entities.Film.Film(NAME_VALID, description, CATEGORY_VALID);

            var result = _filmDescriptionIsValidValidation.Validate(_film);

            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count > 0);
        }

    }
}
