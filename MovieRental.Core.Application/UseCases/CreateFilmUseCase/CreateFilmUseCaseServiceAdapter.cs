using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Adapters.UseCases;
using MovieRental.Domain.Core.Messaging.Commands;
using MovieRental.Domain.Entities.Film;
using MovieRental.Domain.Entities.Film.CreateFilm;
using System.Threading.Tasks;

namespace MovieRental.Core.Application.UseCases.CreateFilmUseCase
{
    public class CreateFilmUseCaseHandler : ICreateFilmUseCaseServiceAdapter
    {
        private readonly IFilmRepositoryAdapter _filmAdapterRepository;

        public CreateFilmUseCaseHandler(IFilmRepositoryAdapter filmAdapterRepository)
        {
            _filmAdapterRepository = filmAdapterRepository;
        }

        public async Task<CommandResponse<CreateFilmCommandOutput>> CreateFilmAsync(CreateFilmCommand command)
        {
            var output = new CommandResponse<CreateFilmCommandOutput>();
            command.IsValid();
            output.LoadValidation(command.ValidationResult);

            if (!output.IsValid)
                return output.GenerateResponseInvalid();

            var newFilm = new Film(command.Name, command.Description, command.IdCategory);
            if (!newFilm.ValidationResult.IsValid)
                return output.GenerateResponseInvalid(newFilm.ValidationResult);

            newFilm = await _filmAdapterRepository.CreateAsync(newFilm);
            output.LoadResult(new CreateFilmCommandOutput(newFilm.Id, System.DateTime.Now));

            return output;
        }
    }
}
