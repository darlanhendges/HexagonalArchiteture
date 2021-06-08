using FluentValidation.Results;

namespace MovieRental.Domain.Core.CrossCutting.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
