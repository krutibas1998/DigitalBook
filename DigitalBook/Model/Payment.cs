using System.ComponentModel.DataAnnotations;

namespace DigitalBook.Model
{
    public class Payment
    {
        [Key]
        public long paymentId { get; set; }
        public string? email { get; set; }
        public long userId { get; set; }
        public DateTime payment { get; set; }
        public long bookId { get; set; }

    }
}
