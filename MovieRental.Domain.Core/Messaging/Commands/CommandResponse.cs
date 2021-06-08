using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Domain.Core.Messaging.Commands
{
    public class CommandResponse<TResult>
    {
        public TResult Result { get; protected set; }
        public bool IsValid => !Errors.Any();
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public CommandResponse()
        {
            this.Errors = Array.Empty<ValidationFailure>();
        }

        public CommandResponse(ValidationResult validationResult)
        {
            this.Errors = validationResult == null ?
              Array.Empty<ValidationFailure>() :
              validationResult.Errors.ToArray();
        }

        public CommandResponse(IEnumerable<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public void LoadValidation(ValidationResult validationErrors)
        {
            this.Errors = validationErrors == null ?
              Array.Empty<ValidationFailure>() :
              validationErrors.Errors.ToArray();
        }

        public void LoadResult(TResult result)
        {
            Result = result;
        }


    }
}
