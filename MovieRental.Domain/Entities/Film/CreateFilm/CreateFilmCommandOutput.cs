using System;

namespace MovieRental.Domain.Entities.Film.CreateFilm
{
    public class CreateFilmCommandOutput
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreateFilmCommandOutput(int id, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }
    }
}
