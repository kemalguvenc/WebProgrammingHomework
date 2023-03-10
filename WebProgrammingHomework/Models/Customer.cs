using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProgrammingHomework.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Lütfen, adınızı giriniz!")]
		[StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
		[Display(Name = "Ad")]
		public String Name { get; set; }

		[Required(ErrorMessage = "Lütfen, soyadınızı giriniz!")]
		[StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
		[Display(Name = "Soyad")]
		public String Surname { get; set; }

		[Required(ErrorMessage = "Lütfen, e-postanızı giriniz!")]
		[StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "E-Posta")]
		public String Email { get; set; }

		[Required(ErrorMessage = "Lütfen, e-postanızı giriniz!")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		public string Role { get; set; }

		[Required(ErrorMessage = "Lütfen, adresinizi giriniz!")]
		[StringLength(100, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
		[Display(Name = "Adres")]
		public String Adress { get; set; }
	}
}
