using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Customer Buyer { get; set; }

        public Product BuyedProduct { get; set; }

        public String CreditCard { get; set; }

        public DateTime ShoppingDate { get; set; }

    }
}
