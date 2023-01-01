using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Customer Buyer { get; set; }

        public Product BuyedProduct { get; set; }

        [Display(Name = "Kredi Kartı")]
        [DataType(DataType.CreditCard)]
        public String CreditCard { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime ShoppingDate { get; set; }

    }
}
