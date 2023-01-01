using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class OrderController : Controller
	{
		ApplicationDbContext dbContext;
		public OrderController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult IndexOrder()
		{
			return View(dbContext.Orders);
		}

		public IActionResult IndexOrderForCustomer(int? customerId)
		{
			if (customerId is not null)
			{
				Order order = dbContext.Orders.FirstOrDefault(x => x.Id == customerId);
				if (order != null)
				{
					dbContext.Orders.Remove(order);
					dbContext.SaveChanges();
					TempData["Warning"] = "Sipariş başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Sipariş bulunamadı!";
			}
			else
				TempData["Warning"] = "Sipariş gönderilmedi!";

			return RedirectToAction("Index", "OrderController");
		}

		public IActionResult AddOrder(Order receivedOrder)
		{
			if (ModelState.IsValid)
			{
				dbContext.Orders.Add(receivedOrder);
				Product product;
				foreach (var item in receivedOrder.Products)
				{
					if (item.ProductType == ProductType.Server)
					{
						product = dbContext.Hostings.FirstOrDefault(x => x.Id == item.Id);
					}
					if (item.ProductType == ProductType.Hosting)
					{

					}
				}
				dbContext.SaveChanges();
				TempData["Warning"] = "Sipraişiniz başarılı bir şekilde oluşturulmuştur!";
			}
			else
			{
				TempData["Warning"] = "Sipraişiniz oluşturulamadı!";
			}
			receivedOrder.Buyer.Cart = null;
			return RedirectToAction("IndexCart", "CartController"); // Müşteriye gidecek
		}
		
		public IActionResult RemoveOrder(int? Id)
		{
			if (Id is not null)
			{
				Order order = dbContext.Orders.FirstOrDefault(x => x.Id == Id);
				if (order != null)
				{
					dbContext.Orders.Remove(order);
					dbContext.SaveChanges();
					TempData["Warning"] = "Sipariş başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Sipariş bulunamadı!";
			}
			else
				TempData["Warning"] = "Sipariş gönderilmedi!";

			return RedirectToAction("Index", "OrderController");
		}
	}
}
