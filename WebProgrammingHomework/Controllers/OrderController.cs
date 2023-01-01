using Microsoft.AspNetCore.Authorization;
using System.Data;
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

		[Authorize(Roles = "Admin")]
		public IActionResult IndexOrder()
		{
			return View(dbContext.Orders);
		}

		[Authorize(Roles = "Customer")]
		public IActionResult IndexOrder(int? customerId) //For Customer
		{
			if (customerId is not null)
			{
				List<Order> orders = dbContext.Orders.Where(x => x.Id == customerId).ToList();
				if (orders.Count != 0)
					return View(orders);
				else
					TempData["Warning"] = "Sipariş bulunamadı!";
			}
			else
				TempData["Warning"] = "Sipariş gönderilmedi!";

			return RedirectToAction("IndexOrder", "Order");
		}
		/*
		[Authorize(Roles = "Customer")]
		public IActionResult AddOrder(int? productId)
		{
			if (ModelState.IsValid)
			{
				dbContext.Orders.Add(receivedOrder);
				Product product;
				foreach (var item in receivedOrder.Products)
				{
					if (item.ProductType == "Hosting")
					{
						product = dbContext.Hostings.FirstOrDefault(x => x.Id == item.Id);
					}
					if (item.ProductType == "Server")
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
			return RedirectToAction("IndexCart", "Cart"); // Müşteriye gidecek
		}*/
	}
}
