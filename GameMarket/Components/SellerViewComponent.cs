using GameMarket.Models;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Components
{
    public class SellerViewComponent : ViewComponent
    {
        private readonly IOrderRepository _orderRepository;

        public SellerViewComponent(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Product> product = _orderRepository.GetSellerProduct();
            return View(product);
        }
    }
}
