using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Data;
using WebProgrammingHomework.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public CustomersController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		[Route("[action]")]
		public IActionResult GetCustomers()
		{
			var value = from h in _context.Customers.AsQueryable()
						select new Customer()
						{
							Role = h.Role,
							Adress = h.Adress,
							Surname = h.Surname,
							Email = h.Email,
							Id = h.Id,
							Name = h.Name,
							Password = h.Password,
						};
			return Ok(value.ToList());
		}
	}
}
