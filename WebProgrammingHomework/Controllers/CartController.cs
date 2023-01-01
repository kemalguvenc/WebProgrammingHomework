using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class CartController : Controller
	{
		ApplicationDbContext dbContext;
		public CartController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult Index(int? Id)
		{
			if (Id is not null)
			{
				Hosting hosting = dbContext.Hostings.FirstOrDefault(x => x.Id == Id);
				if (hosting != null)
				{
					dbContext.Hostings.Remove(hosting);
					dbContext.SaveChanges();
					TempData["Warning"] = "Ürün başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Ürün bulunamadı!";
			}
			else
				TempData["Warning"] = "Ürün belirtilmedi!";

			return RedirectToAction("Index", "ProductController");
		}

		public IActionResult Add(int? id)
		{
			return View();
		}
	}
}
