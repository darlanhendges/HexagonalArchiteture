using FluentValidation;
using FluentValidation.Results;
using MovieRental.Domain.Core.CrossCutting.Entities;
using MovieRental.Domain.Core.Messaging.Commands;
using System;

namespace MovieRental.Domain.Entities.Film.CreateFilm
{
    public class CreateFilmCommand : Command<long>
    {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int IdCategory { get; private set; }

        public CreateFilmCommand(string name, string description, int idCategory)
        {
            Name = name;
            Description = description;
            IdCategory = idCategory;
        }
      
        public override bool IsValid()
        {
            var v = new InlineValidator<CreateFilmCommand>();
            v.RuleFor(x => x.Name).Must(ValidateEmptyString).WithMessage(Globalization.NameIsEmpty())
                .MinimumLength(20).WithMessage(Globalization.NameNeedHave20());

            v.RuleFor(x => x.Description).Must(ValidateEmptyString).WithMessage(Globalization.DescriptionIsEmpty())
                .MinimumLength(30).WithMessage(Globalization.DescriptionNeedHave30());


            v.RuleFor(x => x.IdCategory).GreaterThan(0).WithMessage(Globalization.CategoryInvalid());

            ValidationResult = v.Validate(this);
            return ValidationResult.IsValid;
        }

        private bool ValidateEmptyString(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg != null ? arg.Trim() : arg);
        }
    }
}
