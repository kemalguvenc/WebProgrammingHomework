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
        public ProductType ProductType { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün stokunu giriniz!")]
        [Display(Name = "Stok")]
        public uint Stock { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün fiyatını giriniz!")]
        [Display(Name = "Fiyat")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
