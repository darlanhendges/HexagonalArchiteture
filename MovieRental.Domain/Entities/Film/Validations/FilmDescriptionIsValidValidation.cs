using FluentValidation;
using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmDescriptionIsValidValidation : AbstractValidator<Entities.Film.Film>
    {
        public FilmDescriptionIsValidValidation()
        {
            RuleFor(f => f.Description).Must(ValidateEmptyString).WithMessage(Globalization.DescriptionIsEmpty())
                 .MinimumLength(30).WithMessage(Globalization.DescriptionNeedHave30());
        }
        private bool ValidateEmptyString(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg != null ? arg.Trim() : arg);
        }
    }
}
