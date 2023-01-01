using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün adını giriniz!")]
        [StringLength(20, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [Display(Name = "Ürün")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün tipini giriniz!")]
        [Display(Name = "Tip")]
        public String ProductType { get; set; }

		[Required(ErrorMessage = "Lütfen, disk boyutunu giriniz!")]
		[Display(Name = "Disk")]
		public uint Disk { get; set; }

		[Required(ErrorMessage = "Lütfen, bir sistem bilgisini giriniz!")]
		[Display(Name = "Sistem")]
		public String System { get; set; }

		[Required(ErrorMessage = "Lütfen, ürünün adını giriniz!")]
		[Display(Name = "Trafik")]
		public uint Traffic { get; set; }

		[Required(ErrorMessage = "Lütfen ürünün fiyatını giriniz!")]
        [Display(Name = "Fiyat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
