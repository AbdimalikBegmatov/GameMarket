using GameMarket.Models;

namespace GameMarket.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Product> GetSellerProduct();
        void AddOrder(Order order);
        Order GetById(int id);
        IEnumerable<Order> GetOrders();
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
