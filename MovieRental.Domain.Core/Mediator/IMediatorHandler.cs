using MovieRental.Domain.Core.Messaging.Commands;
using System.Threading.Tasks;

namespace MovieRental.Domain.Core.Mediator
{
  public interface IMediatorHandler
  {
    Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command);

  }
}