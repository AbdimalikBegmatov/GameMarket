using GameMarket.Data;
using GameMarket.Models;
using GameMarket.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameMarket.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Include(o=>o.OrderLines).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.Include(o => o.OrderLines).ThenInclude(l=>l.Product);
        }

        public IEnumerable<Product> GetSellerProduct()
        {
            return _context.OrderLines.OrderByDescending(l => l.Quantity).Select(l => l.Product).Take(10);
        }

        public void UpdateOrder(Order order)
        {
            Order data = _context.Orders.Include(o=>o.OrderLines).FirstOrDefault(o=>o.Id==order.Id);

            data.CustumerName = order.CustumerName;
            data.Address = order.Address;
            data.ZipCode = order.ZipCode;   
            data.OrderLines = order.OrderLines;
            data.Shipped  =   order.Shipped;
            data.ShippedTime = order.Shipped == true ? DateTime.Now : new DateTime();
            data.State = order.State;

            _context.SaveChanges();
        }
    }
}
