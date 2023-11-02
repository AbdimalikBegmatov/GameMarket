using GameMarket.Data;
using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameMarket.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p=>p.Category);
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(c=>c.Category).FirstOrDefault(p=>p.Id==id);
        }

        public IEnumerable<Product> GetNewProducts()
        {
            return _context.Products.OrderByDescending(p=>p.EditedTime).Take(5);
        }

        public PagedList<Product> GetProducts(QueryOption option)
        {
            return new PagedList<Product>(_context.Products.Include(p=>p.Category),option);
        }

        public PagedList<Product> GetProducts(QueryOption options, int category)
        {
            if (category == 0)
            {
                return new PagedList<Product>(_context.Products.Include(p => p.Category), options);
            }
            return new PagedList<Product>(_context.Products.Include(p => p.Category).Where(p => p.CategoryId == category), options);
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product prod = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.PurchasePrice = product.PurchasePrice;
            prod.RetailPrice = product.RetailPrice;
            prod.DeveloperCompany= product.DeveloperCompany;
            prod.Released= product.Released;
            prod.EditedTime = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
