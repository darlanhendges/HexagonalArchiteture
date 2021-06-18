namespace MovieRental.Domain.Tests.Entities.Film.CreateFilm
{
    public class CreateFilmCommandHandlerTests
    {
        //private const string NAME_VALID = "name VALIDO NOME VALIDO NOME VALIDO NOME VALIDO NOME VALIDO ";
        //private const string DESCRIPTION_VALID = "DESCRIPTION VALIDO DESCRIPTION VALIDO DESCRIPTION VALIDO DESCRIPTION VALIDO ";
        //private const int CATEGORYID_VALID = 10;

        //private CreateFilmCommandHandler _handler;
        //private Domain.Entities.Film.Film _filmValid = new Domain.Entities.Film.Film("Darlan Hendges HendgesHendges", "Descrição Descrição Descrição Descrição Descrição Descrição ", 1);

        //[Fact]
        //public async void Create_Film_Async_ReturnTrue()
        //{
        //    // Arrange
        //    //_filmValid.LoadId(100);

        //    //var filmRepositoryAdapterMoq = new Moq.Mock<IFilmRepositoryAdapter>(MockBehavior.Strict);
        //    //filmRepositoryAdapterMoq.Setup(fr => fr.CreateAsync(new Domain.Entities.Film.Film())).ReturnsAsync(new Domain.Entities.Film.Film());
        //    //var target = filmRepositoryAdapterMoq.Object;

        //    //var retorn = await target.CreateAsync(new Domain.Entities.Film.Film()); 


        //    //var categoryRepositoryAdapterMoq = new Moq.Mock<ICategoryRepositoryAdapter>();
        //    //categoryRepositoryAdapterMoq.Setup(c => c.GetCategoryById(It.IsAny<int>())).ReturnsAsync(new Category());

        //    //var request = new CreateFilmCommand(NAME_VALID, DESCRIPTION_VALID, CATEGORYID_VALID);

        //    //// Act
        //    //_handler = new CreateFilmCommandHandler(target, categoryRepositoryAdapterMoq.Object);
        //    //var response = await _handler.Handle(request, new CancellationToken());

        //    //// Assert
        //    //Assert.True(request.IsValid());
        //    //Assert.True(response.IsValid);
        //    //Assert.Empty(response.Errors);
        //    //Assert.True(response.Result.Id > 0);
        //    //Assert.True(response.Result.CreatedAt != DateTime.MinValue);
        //}

        //[Theory]
        //[InlineData("Nome invalido")]
        //[InlineData("")]
        //[InlineData("   ")]
        //[InlineData(null)]
        //public async Task Create_Film_Async_NameInvalid_ReturnFalse(string nameInvalid)
        //{
        //    var request = new CreateFilmCommand(nameInvalid, DESCRIPTION_VALID, CATEGORYID_VALID);

        //    var response = await _handler.Handle(request, new CancellationToken());
        //    Assert.False(response.IsValid);
        //    Assert.True(response.Errors.Count() > 0);
        //}


        //[Theory]
        //[InlineData("Description invalid")]
        //[InlineData("")]
        //[InlineData("   ")]
        //[InlineData(null)]
        //public async Task Create_Film_Async_DescriptionInvalid_ReturnFalse(string descriptionInvalid)
        //{
        //    var request = new CreateFilmCommand(NAME_VALID, descriptionInvalid, CATEGORYID_VALID);

        //    var response = await _handler.Handle(request, new CancellationToken());
        //    Assert.False(response.IsValid);
        //    Assert.True(response.Errors.Count() > 0);
        //}
    }
}
