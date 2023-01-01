using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class HostingController : Controller
	{
		static DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
		ApplicationDbContext dbContext = new ApplicationDbContext(options);

		public IActionResult IndexHosting()
		{
			return View(dbContext.Hostings);
		}

		[HttpGet]
		public IActionResult CreateHosting()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateHosting(Hosting receivedHosting)
		{
			receivedHosting.ProductType = ProductType.Hosting;
			receivedHosting.Stock = 1;
			if (ModelState.IsValid)
			{
				dbContext.Hostings.Add(receivedHosting);
				dbContext.SaveChanges();
				TempData["Warning"] = "Hosting başarılı bir şekilde eklenmiştir!";
				return RedirectToAction("IndexHosting", "HostingController");
			}
			else
			{
				TempData["Warning"] = "Hosting eklenemedi!";
				return View();
			}
		}

		public IActionResult RemoveHosting(int? Id)
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

		[HttpGet]
		public IActionResult UpdateHosting(int? Id)
		{
			if (Id is not null)
			{
				Hosting hosting = dbContext.Hostings.FirstOrDefault(x => x.Id == Id);
				if (hosting != null)
					return View(hosting);
				else
					TempData["Warning"] = "Ürün bulunamadı!";
			}
			else
				TempData["Warning"] = "Ürün gönderilmedi!";

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpdateHosting(Hosting receivedHosting)
		{
			if (ModelState.IsValid)
			{
				dbContext.Hostings.Update(receivedHosting);
				dbContext.SaveChanges();
				TempData["Warning"] = "Ürün başarılı bir şekilde güncellendi!";
				return RedirectToAction("IndexHosting", "HostingController");
			}
			else
			{
				TempData["Warning"] = "Ürün güncellenemedi!";
				return View();
			}
		}
	}
}
