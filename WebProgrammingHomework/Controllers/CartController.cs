using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingHomework.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
