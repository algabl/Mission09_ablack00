using Microsoft.AspNetCore.Mvc;

namespace Mission09_ablack00.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}