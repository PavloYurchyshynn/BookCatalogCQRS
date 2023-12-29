using BookCatalogCQRS.Application.Books.GetBooks;
using BookCatalogCQRS.Application.Configuration.Queries;

namespace BookCatalogCQRS.Application.Books.GetAllBooks
{
    public class GetAllBooksQuery : IQuery<List<BookDto>>
    {
    }
}
