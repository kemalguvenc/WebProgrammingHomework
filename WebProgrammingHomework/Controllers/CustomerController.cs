﻿using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingHomework.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Models.Customer receivedCustomer)
		{
			if (ModelState.IsValid)
			{
				//_context.Students.Add(student);
				//_context.SaveChanges();
				ViewBag.Warning = "Done";
				return View();
			}
			else
			{
				ViewBag.Warning = "Failed";
				return View();
			}
		}
	}
}