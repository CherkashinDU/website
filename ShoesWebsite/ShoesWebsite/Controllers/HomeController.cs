using Microsoft.AspNetCore.Mvc;

namespace ShoesWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Shoes");
        }
    }
}
