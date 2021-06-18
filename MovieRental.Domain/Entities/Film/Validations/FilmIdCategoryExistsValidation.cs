using FluentValidation;
using MovieRental.Domain.Adapters.Repositories;
using MovieRental.Domain.Core.CrossCutting.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRental.Domain.Entities.Film.Validations
{
    public class FilmIdCategoryExistsValidation : AbstractValidator<Entities.Film.Film>
    {
        private readonly ICategoryRepositoryAdapter _categoryRepositoryAdapter;

        public FilmIdCategoryExistsValidation(ICategoryRepositoryAdapter categoryRepositoryAdapter)
        {
            _categoryRepositoryAdapter = categoryRepositoryAdapter;


            RuleFor(x => x.IdCategory).MustAsync(ExistsCategoryId).WithMessage(Globalization.CategoryDoesntExist());
        }

        private async Task<bool> ExistsCategoryId(int id, CancellationToken arg2)
        {
            var category = await _categoryRepositoryAdapter.GetCategoryById(id);
            return category != null;
        }
    }
}
