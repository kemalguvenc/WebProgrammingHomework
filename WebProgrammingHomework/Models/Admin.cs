using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebProgrammingHomework.Models
{
	public class Admin
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

		[Required(ErrorMessage = "Lütfen, kullanıcı e-postasını giriniz!")]
		[StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Lütfen, e-postanızı doğru giriniz!")]
		[Display(Name = "E-Posta")]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		public string Role { get; set; }

		[Required(ErrorMessage = "Lütfen, kullanıcı adresini giriniz!")]
		[StringLength(100, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 10)]
		[Display(Name = "Adres")]
		public String Adress { get; set; }
	}
}
