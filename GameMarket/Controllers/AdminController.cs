using Microsoft.AspNetCore.Mvc;

namespace GameMarket.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Админ страница";
            return View();
        }
    }
}
