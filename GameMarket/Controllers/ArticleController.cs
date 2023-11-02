using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Index(QueryOption option)
        {
            ViewBag.Title = "Все статьи";
            return View(_articleRepository.GetAll(option));
        }
        public IActionResult Detail(int id)
        {
            ViewBag.Title = "Подробнее";
            return View(_articleRepository.GetArticle(id));
        }
        [HttpGet]
        public IActionResult AddOrUpdate(int id)
        {
            ViewBag.Title = id == 0 ? "Добавить" : "Редактировать";
            if (id == 0)
            {
                return View(new Article());
            }
            return View(_articleRepository.GetArticle(id));
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Article article)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = article.Id == 0 ? "Добавить" : "Редактировать";
                return View(article);
            }
            if (article.Id == 0)
            {
                _articleRepository.AddArticle(article);
            }
            else
            {
                _articleRepository.UpdateArticle(article);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
