using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class PositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
