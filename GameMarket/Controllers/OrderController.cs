using GameMarket.Models;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Все заказы";
            return View(_orderRepository.GetOrders());
        }
        public IActionResult AddOrUpdate(int id)
        {
            var product = _productRepository.GetAllProducts();
            ViewBag.Title = id == 0 ? "Добвавление заказа" : "Редактирование заказа";
            Order order = id == 0 ? new Order() : _orderRepository.GetById(id);
            IDictionary<int, OrderLines> lineMaps = order.OrderLines?.ToDictionary(l => l.ProductId) ?? new Dictionary<int, OrderLines>();

            ViewBag.Lines = product.Select(p => lineMaps.ContainsKey(p.Id) ? lineMaps[p.Id] : new OrderLines()
            {
                Product = p,
                ProductId = p.Id,
                Quantity = 0
            });
            return View(order);
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Order order)
        {
            //ViewBag.Title = order.Id == 0 ? "Добвавление заказа" : "Редактирование заказа";
            //if (!ModelState.IsValid)
            //{
            //    return View(order);
            //}
            if (order.Id == 0)
            {
                _orderRepository.AddOrder(order);
            }
            else
            {
                _orderRepository.UpdateOrder(order);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Order order)
        {
            _orderRepository.DeleteOrder(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
