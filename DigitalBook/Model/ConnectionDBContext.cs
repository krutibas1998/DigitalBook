using Microsoft.EntityFrameworkCore;

namespace DigitalBook.Model
{
    public class ConnectionDBContext : DbContext

    {
        public ConnectionDBContext(DbContextOptions<ConnectionDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
