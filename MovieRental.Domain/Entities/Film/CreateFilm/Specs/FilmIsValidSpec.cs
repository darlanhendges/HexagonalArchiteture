using FluentValidation;
using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Film.CreateFilm.Specs
{
    public class FilmIsValidSpec : AbstractValidator<Entities.Film.Film>
    {
        public FilmIsValidSpec()
        {
            RuleFor(x => x.Name).Must(ValidateEmptyString).WithMessage(Globalization.NameIsEmpty())
                .MinimumLength(20).WithMessage(Globalization.NameNeedHave20());

            RuleFor(x => x.Description).Must(ValidateEmptyString).WithMessage(Globalization.DescriptionIsEmpty())
                .MinimumLength(30).WithMessage(Globalization.DescriptionNeedHave30());

            RuleFor(x => x.IdCategory).GreaterThan(0).WithMessage(Globalization.CategoryInvalid());

        }
        private bool ValidateEmptyString(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg != null ? arg.Trim() : arg);
        }

    }
}
