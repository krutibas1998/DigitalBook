using System.ComponentModel.DataAnnotations;

namespace DigitalBook.Model
{
    public class Book
    {
        [Key]
        public long bookId { get; set; } 
        public byte[]? logo { get; set; }
        public string ?title { get; set; }
        public string? category { get; set; }
        public int price { get; set; }
        public long authorId { get; set; }
        public string? publisher { get; set; }
        public DateTime publishesDate { get; set; }
        public string? content { get; set; }
        public int active { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
       
     
    }
}
