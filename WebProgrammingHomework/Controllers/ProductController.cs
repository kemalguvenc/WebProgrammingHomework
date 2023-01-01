using Microsoft.AspNetCore.Authorization;
using System.Data;
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

		[Authorize(Roles = "Admin")]
		public IActionResult IndexProduct()
		{
			return View(dbContext.Products);
		}

		[AllowAnonymous]
		public IActionResult IndexHosting()
		{
			return View(dbContext.Products.Where(x => x.ProductType == "Hosting"));
		}

		[AllowAnonymous]
		public IActionResult IndexServer()
		{
			return View(dbContext.Products.Where(x => x.ProductType == "Server"));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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

		[Authorize(Roles = "Admin")]
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
