using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Entities.Film.CreateFilm;
using System;
using System.Threading.Tasks;
using Xunit;
using MovieRental.Adapters.Driven.Persistence.Tests.Common;
using System.Threading;
using System.Linq;

namespace MovieRental.Domain.Tests.Entities.Film.CreateFilm
{
    public class CreateFilmCommandHandlerTests
    {
        private const string NAME_VALID = "name VALIDO NOME VALIDO NOME VALIDO NOME VALIDO NOME VALIDO ";
        private const string DESCRIPTION_VALID = "DESCRIPTION VALIDO DESCRIPTION VALIDO DESCRIPTION VALIDO DESCRIPTION VALIDO ";
        private const int CATEGORYID_VALID = 10;

        private CreateFilmCommandHandler _handler;
        private Domain.Entities.Film.Film _filmValid = new Domain.Entities.Film.Film("Darlan Hendges HendgesHendges", "Descrição Descrição Descrição Descrição Descrição Descrição ", 1);


        public CreateFilmCommandHandlerTests()
        {
            _handler = new CreateFilmCommandHandler(new FilmRepositoryAdapterFake());
        }

        [Fact]
        public async Task Create_Film_Async_ReturnTrue()
        {
            
            var request = new CreateFilmCommand(NAME_VALID, DESCRIPTION_VALID, CATEGORYID_VALID);
            Assert.True(request.IsValid());

            var response = await _handler.Handle(request, new CancellationToken());

            Assert.True(response.IsValid);
            Assert.Empty(response.Errors);
            Assert.True(response.Result.Id > 0);
            Assert.True(response.Result.CreatedAt != DateTime.MinValue);
        }

        [Theory]
        [InlineData("Nome invalido")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task Create_Film_Async_NameInvalid_ReturnFalse(string nameInvalid)
        {
            var request = new CreateFilmCommand(nameInvalid, DESCRIPTION_VALID, CATEGORYID_VALID);

            var response = await _handler.Handle(request, new CancellationToken());
            Assert.False(response.IsValid);
            Assert.True(response.Errors.Count() > 0);
        }


        [Theory]
        [InlineData("Description invalid")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public async Task Create_Film_Async_DescriptionInvalid_ReturnFalse(string descriptionInvalid)
        {
            var request = new CreateFilmCommand(NAME_VALID, descriptionInvalid, CATEGORYID_VALID);

            var response = await _handler.Handle(request, new CancellationToken());
            Assert.False(response.IsValid);
            Assert.True(response.Errors.Count() > 0);
        }
    }
}
