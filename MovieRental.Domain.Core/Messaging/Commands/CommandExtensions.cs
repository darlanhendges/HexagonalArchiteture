using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Core.Messaging.Commands
{
    public static class CommandExtensions
    {
        public static CommandResponse<TResult> GenerateResponseInvalid<TResult>(this CommandResponse<TResult> command)
        {
            return new CommandResponse<TResult>(command.Errors);
        }
        public static CommandResponse<TResult> GenerateResponseInvalid<TResult>(this CommandResponse<TResult> command, FluentValidation.Results.ValidationResult validationResult)
        {
            return new CommandResponse<TResult>(validationResult);
        }
    }
}
