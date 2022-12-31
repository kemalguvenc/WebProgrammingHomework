using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen, kullanıcı adını giriniz!")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır."]
        [Display(Name = "Ad")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Lütfen, kullanıcı soyadını giriniz!")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır."]
        [Display(Name = "Soyad")]
        public String Surname { get; set; }

        [Required(ErrorMessage = "Lütfen, kullanıcı e-postasını giriniz!")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}")]
        [Display(Name = "E-Posta")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Lütfen, kullanıcı şifresini giriniz!")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Lütfen, kullanıcı adresini giriniz!")]
        [StringLength(100, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 10)]
        [Display(Name = "Adres")]
        public String Adress { get; set; }

        public Product Cart { get; set; }
    }
}
