using FluentValidation;
using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmNameIsnotEmptyValidation : AbstractValidator<Entities.Film.Film>
    {
        public FilmNameIsnotEmptyValidation()
        {
            RuleFor(x => x.Name).Must(ValidateEmptyString).WithMessage(Globalization.NameIsEmpty()).MinimumLength(20).WithMessage(Globalization.NameNeedHave20());
        }

        private bool ValidateEmptyString(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg != null ? arg.Trim() : arg);
        }
    }
}
