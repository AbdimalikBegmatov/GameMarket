using GameMarket.Models;
using GameMarket.Models.Page;

namespace GameMarket.Repositories.Interfaces
{
    public interface IProductRepository
    {
        PagedList<Product> GetProducts(QueryOption option);
        Product GetById(int id);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        PagedList<Product> GetProducts(QueryOption options, int category);
        IEnumerable<Product> GetNewProducts();
    }
}
