using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class ServerController : Controller
	{
		static DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
		ApplicationDbContext dbContext = new ApplicationDbContext(options);

		public IActionResult IndexServer()
		{
			return View(dbContext.Servers);
		}

		[HttpGet]
		public IActionResult CreateServer()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateServer(Server receivedServer)
		{
			receivedServer.ProductType = ProductType.Server;
			receivedServer.Stock = 1;
			if (ModelState.IsValid)
			{
				dbContext.Servers.Add(receivedServer);
				dbContext.SaveChanges();
				TempData["Warning"] = "Server başarılı bir şekilde eklenmiştir!";
				return RedirectToAction("IndexServer", "ServerController");
			}
			else
			{
				TempData["Warning"] = "Server eklenemedi!";
				return View();
			}
		}

		public IActionResult RemoveServer(int? Id)
		{
			if (Id is not null)
			{
				Server server = dbContext.Servers.FirstOrDefault(x => x.Id == Id);
				if (server != null)
				{
					dbContext.Hostings.Remove(server);
					dbContext.SaveChanges();
					TempData["Warning"] = "Server başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Server bulunamadı!";
			}
			else
				TempData["Warning"] = "Server belirtilmedi!";

			return RedirectToAction("Index", "ServerController");
		}

		[HttpGet]
		public IActionResult UpdateHosting(int? Id)
		{
			if (Id is not null)
			{
				Server server = dbContext.Servers.FirstOrDefault(x => x.Id == Id);
				if (server != null)
					return View(server);
				else
					TempData["Warning"] = "Server bulunamadı!";
			}
			else
				TempData["Warning"] = "Server gönderilmedi!";

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpdateHosting(Hosting receivedHosting)
		{
			if (ModelState.IsValid)
			{
				dbContext.Servers.Update(receivedHosting);
				dbContext.SaveChanges();
				TempData["Warning"] = "Server başarılı bir şekilde güncellendi!";
				return RedirectToAction("IndexServer", "ServerController");
			}
			else
			{
				TempData["Warning"] = "Server güncellenemedi!";
				return View();
			}
		}
	}
}
