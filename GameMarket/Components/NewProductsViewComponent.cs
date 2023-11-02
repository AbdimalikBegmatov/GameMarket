using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Components
{
    public class NewProductsViewComponent:ViewComponent
    {
        private readonly IProductRepository _repository;

        public NewProductsViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_repository.GetNewProducts());
        }
    }
}
