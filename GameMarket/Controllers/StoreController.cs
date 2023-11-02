using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public StoreController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index([FromQuery(Name = "option")] QueryOption productOptions, QueryOption catOptions, int category)
        {
            ViewBag.Categories = _categoryRepository.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(_productRepository.GetProducts(productOptions, category));
        }
    }
}
