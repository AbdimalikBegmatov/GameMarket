using GameMarket.Models;
using GameMarket.Models.Page;

namespace GameMarket.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        PagedList<Category> GetCategories(QueryOption option);
        Category GetById(int id);
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        IEnumerable<Category> GetAllCategories();
    }
}
