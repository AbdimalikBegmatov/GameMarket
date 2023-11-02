using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(QueryOption option,int? id)
        {
            ViewBag.Title = "Все категории";
            ViewBag.EditId = TempData["EditId"] ?? id;
            return View(_categoryRepository.GetCategories(option));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(Category category)
        {
            _categoryRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["EditId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Category category)
        {
            if (category != null)
            {
                _categoryRepository.RemoveCategory(category);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ViewBag.Title = "Подробно";
            return View(_categoryRepository.GetById(id));
        }
    }
}
