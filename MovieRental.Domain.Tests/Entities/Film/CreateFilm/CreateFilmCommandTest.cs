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
        [InlineData(null,null, 0)]
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
        [InlineData("Nome válido Nome válido", null, 10)]
        public void Description_LenghHaventEnough(string name, string description, int category)
        {
            _command = new CreateFilmCommand(name, description, category);
            var isValid = _command.IsValid();

            Assert.False(isValid);

            if (!string.IsNullOrEmpty(description != null ? description.Trim() : description))
            {
                Assert.Single(_command.ValidationResult.Errors);
                Assert.Equal(Globalization.DescriptionNeedHave30(), _command.ValidationResult.Errors[0].ErrorMessage);
            }
            else if (description == null)
            {
                Assert.Single(_command.ValidationResult.Errors);
                Assert.Single(_command.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionIsEmpty())));
            }
            else
            {
                Assert.Equal(2, _command.ValidationResult.Errors.Count);
                Assert.Single(_command.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionIsEmpty())));
                Assert.Single(_command.ValidationResult.Errors.Where(e => e.ErrorMessage.Equals(Globalization.DescriptionNeedHave30())));
            }
        }



    }
}
