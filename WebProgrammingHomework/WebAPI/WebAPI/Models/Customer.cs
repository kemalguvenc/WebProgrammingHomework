using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProgrammingHomework.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		public String Name { get; set; }

		public String Surname { get; set; }

		public String Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public String Adress { get; set; }
	}
}
