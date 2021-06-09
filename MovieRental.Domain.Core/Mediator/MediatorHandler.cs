
using MediatR;
using MovieRental.Domain.Core.Messaging.Commands;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MovieRental.Domain.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command)
        {
            return mediator.Send(command);
        }
    }
}