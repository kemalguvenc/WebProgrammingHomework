using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String ProductType { get; set; }

		public uint Disk { get; set; }

		public String System { get; set; }

		public uint Traffic { get; set; }

        public decimal Price { get; set; }
    }
}
