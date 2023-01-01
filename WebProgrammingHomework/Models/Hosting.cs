using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Hosting : Product
    {

        [Required(ErrorMessage = "Lütfen, disk boyutunu giriniz!")]
        [Display(Name = "Disk")]
        public uint Disk { get; set; }


        [Required(ErrorMessage = "Lütfen, ürünün adını giriniz!")]
        [Display(Name = "Trafik")]
        public uint Traffic { get; set; }


        [Required(ErrorMessage = "Lütfen, web sitesi kapasitesini giriniz!")]
        [Display(Name = "Web Sitesi Kapasitesi")]
        public uint WebAdressNumber { get; set; }


        [Required(ErrorMessage = "Lütfen, bir panel giriniz!")]
        [Display(Name = "Panel")] 
        public HostingPanel hostingPanel { get; set; }
    }
}
