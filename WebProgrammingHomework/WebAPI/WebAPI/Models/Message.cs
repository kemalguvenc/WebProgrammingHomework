using System.ComponentModel.DataAnnotations;

namespace WebProgrammingHomework.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public String SenderName { get; set; }

        public String SenderSurname { get; set; }

        public String SenderEmail { get; set; }

        public String message { get; set; }

        public DateTime SendingDate { get; set; }
    }
}
