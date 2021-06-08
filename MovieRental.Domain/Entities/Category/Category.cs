using MovieRental.Domain.Core.CrossCutting.Entities;

namespace MovieRental.Domain.Entities.Category
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
