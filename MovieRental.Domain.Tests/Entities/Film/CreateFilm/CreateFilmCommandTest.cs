using MovieRental.Domain.Core.CrossCutting.Entities;
using MovieRental.Domain.Entities.Film.CreateFilm;
using System.Linq;
using Xunit;

namespace MovieRental.Domain.Tests.Entities.Film.CreateFilm
{
    public class CreateFilmCommandTest
    {
        private CreateFilmCommand _command;

        [Theory]
        [InlineData(" ", "    ", -10)]
        [InlineData(null, null, 0)]
        public void IsEverything_IsFalse(string name, string description, int category)
        {
            _command = new CreateFilmCommand(name, description, category);
            var isValid = _command.IsValid();

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Darlan", "Descrição valida", 10)]
        [InlineData("Suelen dos", "Descrição valida", 10)]
        [InlineData("", "Descrição valida", 10)]
        [InlineData(null, "Descrição valida", 10)]
        public void Name_LenghHaventEnough(string name, string description, int category)
        {
            _command = new CreateFilmCommand(name, description, category);
            var isValid = _command.IsValid();

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Nome válido Nome válido", "", 10)]
        [InlineData("Nome válido Nome válido", "                              ", 10)]
        public void Description_LenghHaventEnough(string name, string description, int category)
        {
            _command = new CreateFilmCommand(name, description, category);
            var isValid = _command.IsValid();

            Assert.False(isValid);
            Assert.True(_command.ValidationResult.Errors.Count > 0);
        }

        [Theory]
        [InlineData("Nome válido Nome válido", null, 10)]
        public void Description_NULL_IsFalse(string name, string description, int category)
        {
            _command = new CreateFilmCommand(name, description, category);
            var isValid = _command.IsValid();

            Assert.False(isValid);
            Assert.Single(_command.ValidationResult.Errors);
            Assert.Single(_command.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionIsEmpty())));
        }



    }
}
