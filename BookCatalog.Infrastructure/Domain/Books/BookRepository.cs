using BookCatalogCQRS.Domain.Books;
using BookCatalogCQRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogCQRS.Infrastructure.Domain.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext _booksContext;
        private readonly DbSet<Book> _dbSet;
        public BookRepository(BooksContext booksContext)
        {
            _booksContext = booksContext;
            _dbSet = _booksContext.Set<Book>();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _booksContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _booksContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Guid> AddAsync(Book item)
        {
            var addedBook = (await _booksContext.Books.AddAsync(item)).Entity;
            await _booksContext.SaveChangesAsync();

            return addedBook.Id;
        }

        public async Task<Book> UpdateAsync(Book item)
        {
            _dbSet.Update(item);
            await _booksContext.SaveChangesAsync();

            return item;
        }

        public async Task<Book> DeleteAsync(Book item)
        {
            var deletedBook = _dbSet.Remove(item).Entity;
            await _booksContext.SaveChangesAsync();

            return deletedBook;
        }
    }
}
