using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Index(QueryOption option)
        {
            ViewBag.Title = "Главная страница";
            return View(_articleRepository.GetAll(option));
        }
    }
}