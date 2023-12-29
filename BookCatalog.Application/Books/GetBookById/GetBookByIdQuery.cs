using BookCatalogCQRS.Application.Configuration.Queries;

namespace BookCatalogCQRS.Application.Books.GetBooks
{
    public class GetBookByIdQuery : IQuery<BookDto>
    {
        public Guid BookId { get; set; }
        public GetBookByIdQuery(Guid bookId) 
        {
            this.BookId = bookId;
        }
    }
}
