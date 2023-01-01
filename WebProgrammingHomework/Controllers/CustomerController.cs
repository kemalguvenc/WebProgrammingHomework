using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Controllers
{
	public class CustomerController : Controller
	{
		ApplicationDbContext dbContext;
		public CustomerController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[Authorize(Roles = "Customer")]
		public async Task<IActionResult> IndexCustomer()
		{
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:7262/api/Customers/GetCustomers");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonBlog = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<Customer>>(jsonBlog);
				return View(values);
			}
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult CreateCustomer()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateCustomer(Models.Customer receivedCustomer)
		{
			receivedCustomer.Role = "Customer";
			receivedCustomer.Id = 5;
			if (ModelState.IsValid)
			{
				dbContext.Customers.Add(receivedCustomer);
				dbContext.SaveChanges();
				return RedirectToAction("LoginPage", "Login");
			}
			else
			{
				TempData["Warning"] = "Kayıt başarısız";
				return View();
			}
		}
	}
}
