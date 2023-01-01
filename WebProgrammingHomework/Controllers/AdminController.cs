using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebProgrammingHomework.Controllers
{
	public class AdminController : Controller
	{
		ApplicationDbContext dbContext;
		public AdminController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult AdminLogin()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> AdminLoginAsync(Admin admin)
		{
			Admin temp = dbContext.Admins.FirstOrDefault(x => x.Email == admin.Email);
			bool isMember;
			if (temp != null)
				isMember = temp.Password == admin.Password;
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
		public IActionResult AdminPage()
		{
			return View();
		}
	}
}
