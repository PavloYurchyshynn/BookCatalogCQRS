namespace BookCatalogCQRS.Domain.Books
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Book item);
        Task<Book> UpdateAsync(Book item);
        Task<Book> DeleteAsync(Book item);
    }
}
