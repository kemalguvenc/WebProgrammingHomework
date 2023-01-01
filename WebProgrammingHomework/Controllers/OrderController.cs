using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View(/*dbContext.Shoppings*/);
		}

		public IActionResult Add(Shopping receivedShopping)
		{
			if (ModelState.IsValid)
			{
				//dbContext.Shoppings.Add(receivedShopping);
				//dbContext.SaveChanges();
				TempData["Warning"] = "Sipraişiniz başarılı bir şekilde oluşturulmuştur!";
			}
			else
			{
				TempData["Warning"] = "Sipraişiniz oluşturulamadı!";
			}
			return RedirectToAction("Index", "ProductController"); // Müşteriye gidecek
		}
		/*
		public IActionResult Delete(int? Id)
		{
			if (Id is not null)
			{
				Shopping shopping; //dbContext.Shoppings.FirstOrDefault(x => x.Id == Id);
				if (shopping != null)
				{
					//dbContext.Shoppings.Remove(shopping);
					//dbContext.SaveChanges();
					TempData["Warning"] = "Sipariş başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Sipariş bulunamadı!";
			}
			else
				TempData["Warning"] = "Sipariş gönderilmedi!";

			return RedirectToAction("Index", "OrderController");
		}*/


	}
}
