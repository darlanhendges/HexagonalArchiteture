using MovieRental.Domain.Core.CrossCutting.Entities;
using System.Linq;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film
{
    public class FilmTests
    {
        public Domain.Entities.Film.Film CreateValidEntity() => new Domain.Entities.Film.Film(Faker.Name.First() + " " + Faker.Name.Last() + " " + Faker.Name.Last() + Faker.Name.First() + " " + Faker.Name.Last() + " " + Faker.Name.Last(), Faker.Lorem.Sentence(50), Faker.RandomNumber.Next(99999));

        [Theory]
        [InlineData(" ", "    ", -10)]
        [InlineData(" ", null, -10)]
        [InlineData(null, "    ", -10)]
        [InlineData(null, null, -10)]
        public void IsFalse(string name, string description, int categoryId)
        {
            var entity = new Domain.Entities.Film.Film(name, description, categoryId);
            Assert.False(entity.ValidationResult.IsValid);
        }

        [Theory]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", -10)]
        public void IsFalse_CategoryID_Invalid(string name, string description, int categoryId)
        {
            var entity = new Domain.Entities.Film.Film(name, description, categoryId);
            Assert.False(entity.ValidationResult.IsValid);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.CategoryInvalid())));
        }

        [Theory]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", 10, -1)]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", 10, 0)]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", 10, -1500)]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", 10, -1.5)]
        [InlineData("Darlan Hendges Válido", "Descricão valida porque tem muitos caracteres", 10, -2)]

        public void IsFalse_IdFilm_Invalid(string name, string description, int categoryId, int filmId)
        {
            var entity = new Domain.Entities.Film.Film(name, description, categoryId);
            entity.LoadId(filmId);

            Assert.False(entity.ValidationResult.IsValid);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.IdFilmIsInvalid())));
            Assert.Single(entity.ValidationResult.Errors);
        }

        [Theory]
        [InlineData("Pedro")]
        [InlineData("Pedro Afonso")]
        public void UpdateName_LowerThan20_IsFalse(string name)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadName(name);
            Assert.False(entity.ValidationResult.IsValid);
            Assert.Single(entity.ValidationResult.Errors);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.NameNeedHave20())));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("      ")]
        public void UpdateName_Empty_IsFalse(string name)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadName(name);

            Assert.False(entity.ValidationResult.IsValid);
            Assert.Equal(2, entity.ValidationResult.Errors.Count);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.NameNeedHave20())));
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.NameIsEmpty())));
        }

        [Theory]
        [InlineData(null)]
        public void UpdateName_Null_IsFalse(string name)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadName(name);

            Assert.False(entity.ValidationResult.IsValid);
            Assert.Single(entity.ValidationResult.Errors);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.NameIsEmpty())));
        }

        [Theory]
        [InlineData("Pedro Santos da Silva Alcantará")]
        public void UpdateName_GreatherThan20_IsTrue(string name)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadName(name);
            Assert.True(entity.ValidationResult.IsValid);
        }

        [Theory]
        [InlineData("Descrição")]
        [InlineData("Descrição ")]
        [InlineData(" ")]
        [InlineData("             ")]
        [InlineData(null)]
        public void IsFalse_UpdateDescription_Invalid(string description)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadDescription(description);
            Assert.False(entity.ValidationResult.IsValid);
        }

        [Theory]
        [InlineData(null)]
        public void IsFalse_UpdateDescription_Null_Invalid(string description)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadDescription(description);
            Assert.False(entity.ValidationResult.IsValid);
            Assert.Single(entity.ValidationResult.Errors);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionIsEmpty())));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("                            ")]
        public void IsFalse_UpdateDescription_StringEmpty_Invalid(string description)
        {
            var entity = CreateValidEntity();
            Assert.True(entity.ValidationResult.IsValid);

            entity.LoadDescription(description);
            Assert.False(entity.ValidationResult.IsValid);
            Assert.Equal(2, entity.ValidationResult.Errors.Count);
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionIsEmpty())));
            Assert.Single(entity.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionNeedHave30())));
        }
    }
}
