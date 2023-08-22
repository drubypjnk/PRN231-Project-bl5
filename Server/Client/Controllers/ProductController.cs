using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult List()
		{
			return View();
		}
	}
}
