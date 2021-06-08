using MovieRental.Domain.Core.Messaging.Commands;
using MovieRental.Domain.Entities.Film.CreateFilm;
using System.Threading.Tasks;

namespace MovieRental.Domain.Adapters.UseCases
{
    public interface ICreateFilmUseCaseServiceAdapter
    {
        Task<CommandResponse<CreateFilmCommandOutput>> CreateFilmAsync(CreateFilmCommand command);
    }
}
