using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class ContactController : Controller
	{
		static DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
		ApplicationDbContext dbContext = new ApplicationDbContext(options);

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Contact(Message receivedMessage)
		{
			receivedMessage.SendingDate = DateTime.Now;

			if (ModelState.IsValid)
			{
				dbContext.Messages.Add(receivedMessage);
				dbContext.SaveChanges();
				TempData["Warning"] = "Mesajınız başarılır bir şekilde iletilmiştir!";
			}
			else
			{
				TempData["Warning"] = "Mesajınız teknik bir aksaklık nedeniyle iletilememiştir!";
			}
			return View();
		}
	}
}
