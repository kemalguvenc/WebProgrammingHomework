using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;
using Microsoft.AspNetCore.Authorization;
using WebProgrammingHomework.Extension;

namespace WebProgrammingHomework.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		ApplicationDbContext dbContext;
		public LoginController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult LoginPage()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LoginPageAsync(Customer customer)
		{
			Customer temp = dbContext.Customers.FirstOrDefault(x => x.Email == customer.Email);
			bool isMember;
			if (temp != null)
				isMember = temp.Password == customer.Password;
			else
				isMember = false;

			//User.Claims.GetSpecificClaim(ClaimTypes.Role);

			if (isMember == true)
			{
				List<Claim> claims = new List<Claim>()
					{
						new Claim(ClaimTypes.NameIdentifier,temp.Id.ToString()),
						new Claim(ClaimTypes.Name,temp.Name),
						new Claim(ClaimTypes.Surname,temp.Surname),
						new Claim(ClaimTypes.Role,temp.Role),
					};
				var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties();
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
				return RedirectToAction("HomePage", "Home");
			}

			return View();
		}

		public async Task<IActionResult> LogOutAsync()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("HomePage", "Home");
		}
	}
}
