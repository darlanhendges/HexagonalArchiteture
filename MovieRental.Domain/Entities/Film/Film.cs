using MovieRental.Domain.Core.CrossCutting.Entities;
using MovieRental.Domain.Entities.Film.CreateFilm.Specs;
using MovieRental.Domain.Entities.Film.Validations;
using System;

namespace MovieRental.Domain.Entities.Film
{
    public class Film : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int IdCategory { get; private set; }

       public Film(string name, string description, int idCategory)
        {
            Name = name;
            Description = description;
            IdCategory = idCategory;

            var validator = new FilmIsValidSpec();
            this.ValidationResult = validator.Validate(this);
        }

        public void LoadId(int id)
        {
            Id = id;

            var validator = new FilmIDGreaterThanZeroValidation();
            this.ValidationResult = validator.Validate(this);
        }

        public void LoadName(string name)
        {
            Name = name;

            var validator = new FilmNameIsnotEmptyValidation();
            this.ValidationResult = validator.Validate(this);
        }

        public void LoadDescription(string description)
        {
            Description = description;

            var validator = new FilmDescriptionIsValidValidation();
            this.ValidationResult = validator.Validate(this);
        }
    }
}
