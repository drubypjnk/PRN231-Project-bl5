using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class SkuController : Controller
    {
        public IActionResult Index()
        {
            return View("list");
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
