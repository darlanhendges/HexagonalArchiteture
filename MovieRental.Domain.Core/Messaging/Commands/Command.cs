﻿using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace MovieRental.Domain.Core.Messaging.Commands
{
    public abstract class Command<TResult> : IRequest<CommandResponse<TResult>>
    {

        /// <summary>
        /// A lista de erros de validação resultante da chamada ao método IsValid.
        /// </summary>
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        /// <summary>
        /// Verifica se o comando está em um estado válido.
        /// </summary>
        /// <returns>Retorna true se o comando é válido; caso contrário retorna false.</returns>
        public virtual bool IsValid()
        {
            return true;
        }
    }
}
