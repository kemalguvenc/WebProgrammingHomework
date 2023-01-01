using Microsoft.EntityFrameworkCore;
using WebProgrammingHomework.Models;

namespace WebProgrammingHomework.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Customer> Customers { get; set; }

		public ApplicationDbContext(DbContextOptions options)
				: base(options)
		{
		}
		
	}
}