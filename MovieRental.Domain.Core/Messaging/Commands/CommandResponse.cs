using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Domain.Core.Messaging.Commands
{
    public class CommandResponse<TResult>
    {
        private ValidationResult validationResult;

        public TResult Result { get; protected set; }
        public bool IsValid => !Errors.Any();
        public IEnumerable<ValidationFailure> Errors { get; private set; } = Array.Empty<ValidationFailure>();

        public CommandResponse()
        {
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

        public CommandResponse(TResult result, ValidationResult validationResult)
        {
            this.Result = result;
            this.validationResult = validationResult;

            LoadValidation(validationResult);
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
