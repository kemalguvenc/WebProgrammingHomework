using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen, adınızı giriniz!")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Ad")]
        public String SenderName { get; set; }

        [Required(ErrorMessage = "Lütfen, soyadınızı giriniz!")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
        [Display(Name = "Soyad")]
        public String SenderSurname { get; set; }

        [Required(ErrorMessage = "Lütfen, e-postanızı giriniz!")]
        [StringLength(50, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Lütfen, e-postanızı doğru giriniz!")]
        [Display(Name = "E-Posta")]
        public String SenderEmail { get; set; }

        [Required(ErrorMessage = "Lütfen, mesajınızı giriniz!")]
        [StringLength(100, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 10)]
        [Display(Name = "Mesaj")]
        public String message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SendingDate { get; set; }
    }
}
