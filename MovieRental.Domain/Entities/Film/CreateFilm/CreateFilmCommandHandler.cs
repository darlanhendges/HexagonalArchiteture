using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Core.Messaging.Commands;
using MovieRental.Domain.Entities.Film.CreateFilm.Specs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Domain.Entities.Film.CreateFilm
{
    public class CreateFilmCommandHandler : CommandHandler<CreateFilmCommand, CreateFilmCommandOutput>
    {
        private readonly IFilmRepositoryAdapter _filmRepositoryAdapter;

        public CreateFilmCommandHandler(IFilmRepositoryAdapter filmRepositoryAdapter)
        {
            _filmRepositoryAdapter = filmRepositoryAdapter;
        }

        public override async Task<CommandResponse<CreateFilmCommandOutput>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Response(request.ValidationResult);

            var film = new Film(request.Name, request.Description, request.IdCategory);

            if (!film.ValidationResult.IsValid)
                return Response(film.ValidationResult);

            var validationResultCategory = new FilmIsValidToCreateSpec(_filmRepositoryAdapter).Validate(film);

            if (!validationResultCategory.IsValid)
                return Response(validationResultCategory);

            var newEntity = await _filmRepositoryAdapter.CreateAsync(film);

            return Response(new CreateFilmCommandOutput(newEntity.Id, DateTime.Now));
        }
    }
}
