using GameMarket.Data;
using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;

namespace GameMarket.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public PagedList<Category> GetCategories(QueryOption option)
        {
            return new PagedList<Category>(_context.Categories,option);
        }

        

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            Category result = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            result.Name = category.Name;
            result.Description = category.Description;
            _context.SaveChanges();
        }
    }
}
