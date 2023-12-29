using BookCatalogCQRS.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogCQRS.Infrastructure.Database
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
