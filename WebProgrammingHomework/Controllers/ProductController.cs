using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class ProductController : Controller
	{
		ApplicationDbContext dbContext;
		public ProductController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IActionResult IndexProduct()
		{
			return View(dbContext.Products);
		}

		public IActionResult IndexHosting()
		{
			return View(dbContext.Products.Where(x => x.ProductType == "Hosting"));
		}

		public IActionResult IndexServer()
		{
			return View(dbContext.Products.Where(x => x.ProductType == "Server"));
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateProduct(Product receivedProduct)
		{
			if (ModelState.IsValid)
			{
				dbContext.Products.Add(receivedProduct);
				dbContext.SaveChanges();
				TempData["Warning"] = "Hosting başarılı bir şekilde eklenmiştir!";
				return RedirectToAction("IndexProduct", "Product");
			}
			else
			{
				TempData["Warning"] = "Hosting eklenemedi!";
				return View();
			}
		}

		public IActionResult RemoveProduct(int? Id)
		{
			if (Id is not null)
			{
				Product product = dbContext.Products.FirstOrDefault(x => x.Id == Id);
				if (product != null)
				{
					dbContext.Products.Remove(product);
					dbContext.SaveChanges();
					TempData["Warning"] = "Ürün başarılı bir şekilde silindi!";
				}
				else
					TempData["Warning"] = "Ürün bulunamadı!";
			}
			else
				TempData["Warning"] = "Ürün belirtilmedi!";

			return RedirectToAction("IndexProduct", "Product");
		}

		[HttpGet]
		public IActionResult UpdateProduct(int? Id)
		{
			if (Id is not null)
			{
				Product product = dbContext.Products.FirstOrDefault(x => x.Id == Id);
				if (product != null)
					return View(product);
				else
					TempData["Warning"] = "Ürün bulunamadı!";
			}
			else
				TempData["Warning"] = "Ürün gönderilmedi!";

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpdateProduct(Product receivedProduct)
		{
			if (ModelState.IsValid)
			{
				dbContext.Products.Update(receivedProduct);
				dbContext.SaveChanges();
				TempData["Warning"] = "Ürün başarılı bir şekilde güncellendi!";
				return RedirectToAction("IndexHosting", "Hosting");
			}
			else
			{
				TempData["Warning"] = "Ürün güncellenemedi!";
				return View();
			}
		}
	}
}
