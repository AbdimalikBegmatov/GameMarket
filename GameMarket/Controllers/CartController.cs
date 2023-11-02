using GameMarket.Infrastructure;
using GameMarket.Models;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GameMarket.Controllers
{
    [ViewComponent(Name = "Cart")]
    public class CartController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public CartController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        private Cart GetCart() => HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        private void SaveCart(Cart cart) => HttpContext.Session.SetJson("Cart", cart);

        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(GetCart());
        }

        [HttpPost]
        public IActionResult AddToCart(Product product, string returnUrl)
        {
            SaveCart(GetCart().AddItem(product, 1));
            return RedirectToAction(nameof(Index), new { returnUrl });
        }
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.OrderLines = GetCart().Selections.Select(p => new OrderLines
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity,
            }).ToArray();
            _orderRepository.AddOrder(order);
            SaveCart(new Cart());
            return RedirectToAction(nameof(Completed));
        }

        public IActionResult Completed()
        {
            GetCart().Clear();
            HttpContext.Session.Remove("Cart");
            return View();
        }

        public IViewComponentResult Invoke(ISession session)
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<Cart>(ViewData, session.GetJson<Cart>("Cart"))
            };
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            SaveCart(GetCart().RemoveItem(productId));
            return RedirectToAction(nameof(Index));
        }
    }
}
