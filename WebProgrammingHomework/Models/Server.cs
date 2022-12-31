using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Server : Product
    {
        [Required(ErrorMessage = "Lütfen, disk boyutunu giriniz!")]
        [Display(Name = "Disk")]
        public uint Disk { get; set; }


        [Required(ErrorMessage = "Lütfen, ürünün adını giriniz!")]
        [Display(Name = "Trafik")]
        public uint Traffic { get; set; }


        [Required(ErrorMessage = "Lütfen, CPU bilgilerini giriniz!")]
        [Display(Name = "CPU")]
        public String Cpu { get; set; }


        [Required(ErrorMessage = "Lütfen, RAM miktarını giriniz!")]
        [Display(Name = "RAM")]
        public uint Ram { get; set; }
    }
}
