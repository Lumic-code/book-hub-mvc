using BookHub.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {}

        public DbSet<Book> Books { get; set; } = null!;
    }
}
