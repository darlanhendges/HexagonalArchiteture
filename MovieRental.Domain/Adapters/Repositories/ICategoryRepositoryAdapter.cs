using MovieRental.Domain.Entities.Category;
using System.Threading.Tasks;

namespace MovieRental.Domain.Adapters.Repositories
{
    public interface ICategoryRepositoryAdapter
    {
        Task<Category> GetCategoryById(int id);

    }
}
