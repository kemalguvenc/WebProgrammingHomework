using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Data
{
	public class ApplicationDbContext : IdentityDbContext<Customer>
	{
		public DbSet<Hosting> Hostings { get; set; }
		public DbSet<Hosting> Servers { get; set; }
		public DbSet<Shopping> Shoppings { get; set; }
		public DbSet<Message> Messages { get; set; }
		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
		{
		}
	}
}