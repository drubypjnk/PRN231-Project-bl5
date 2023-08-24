using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
