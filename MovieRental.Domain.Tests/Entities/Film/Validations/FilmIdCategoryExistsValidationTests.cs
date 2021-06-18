using Moq;
using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Category;
using MovieRental.Domain.Entities.Film.Validations;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.Validations
{
    public class FilmIdCategoryExistsValidationTests
    {
        private const string NAME_VALID = "iusdiu uihuuhas uhdauhadsuhdasuhadsuiia";
        private const string DESCRIPTION_VALID = "iusdiu uihuuhas uhdauhadsuhdasuhadsuiia uhdauhadsuhdasuhadsuiiauhdauhadsuhdasuhadsuiia";
        private const int CATEGORY_VALID = 1;
        private const int CATEGORY_INVALID = 0;
        private FilmIdCategoryExistsValidation _filmIdCategoryExistsValidation;

        [Fact]
        public async void ValidationIDCategory_Incorrect_ReturnFalse()
        {
            // arrange
            var film = new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION_VALID, CATEGORY_INVALID);
            var moqRepository = new Moq.Mock<ICategoryRepositoryAdapter>(MockBehavior.Strict);
            moqRepository.Setup(m => m.GetCategoryById(It.IsAny<int>())).ReturnsAsync(() => null);

            // Act
            _filmIdCategoryExistsValidation = new FilmIdCategoryExistsValidation(moqRepository.Object);
            var result = await _filmIdCategoryExistsValidation.ValidateAsync(film);

            // Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public async void ValidationIDCategory_Incorrect_ReturnTrue()
        {
            // arrange
            var film = new Domain.Entities.Film.Film(NAME_VALID, DESCRIPTION_VALID, CATEGORY_VALID);
            var moqRepository = new Moq.Mock<ICategoryRepositoryAdapter>(MockBehavior.Strict);
            moqRepository.Setup(m => m.GetCategoryById(It.IsAny<int>())).ReturnsAsync(() => new Category(CATEGORY_VALID, DESCRIPTION_VALID));

            // Act
            _filmIdCategoryExistsValidation = new FilmIdCategoryExistsValidation(moqRepository.Object);
            var result = await _filmIdCategoryExistsValidation.ValidateAsync(film);

            // Assert
            Assert.True(result.IsValid);
            Assert.True(result.Errors.Count == 0);
        }

    }
}
