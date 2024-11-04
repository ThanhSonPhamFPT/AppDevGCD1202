using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
