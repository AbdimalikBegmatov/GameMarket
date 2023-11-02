using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(QueryOption option)
        {
            ViewBag.Title = "Все товары";
            return View(_productRepository.GetProducts(option));
        }

        public IActionResult AddOrUpdate(int id)
        {
            ViewBag.Title = id == 0 ? "Добавление товара" : "Редактирование товара";
            ViewBag.Categories = _categoryRepository.GetAllCategories();

            if (id == 0)
            {

                return View(new Product());
            }
            return View(_productRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Product product)
        {
            ViewBag.Title = product.Id == 0 ? "Добавление товара" : "Редактирование товара";
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryRepository.GetAllCategories();
                return View(product);
            }
            if (product.Id == 0)
            {
                _productRepository.AddProduct(product);
            }
            else
            {
                _productRepository.UpdateProduct(product);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _productRepository.RemoveProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            ViewBag.Title = "Детали товара";
            return View(_productRepository.GetById(id));
        }
    }
}
