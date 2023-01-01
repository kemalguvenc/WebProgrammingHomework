using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProgrammingHomework.Models
{
	public class Customer : IdentityUser
	{
		[Required(ErrorMessage = "Lütfen, adınızı giriniz!")]
		[StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
		[Display(Name = "Ad")]
		public String Name { get; set; }

		[Required(ErrorMessage = "Lütfen, soyadınızı giriniz!")]
		[StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
		[Display(Name = "Soyad")]
		public String Surname { get; set; }

		[Required(ErrorMessage = "Lütfen, kullanıcı adresini giriniz!")]
		[StringLength(100, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 10)]
		[Display(Name = "Adres")]
		public String Adress { get; set; }

		public Product? Cart { get; set; }
	}
}
