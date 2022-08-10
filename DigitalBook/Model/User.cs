using System.ComponentModel.DataAnnotations;

namespace DigitalBook.Model
{
    public class User
    {
        [Key]
        public long userId { get; set; }
        public string? userName { get; set; }
        public string? userType { get; set; }
        public string? password { get; set; }
    }
}
