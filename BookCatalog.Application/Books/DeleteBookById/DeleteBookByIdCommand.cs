using BookCatalogCQRS.Application.Configuration.Commands;

namespace BookCatalogCQRS.Application.Books.DeleteBookById
{
    public class DeleteBookByIdCommand : CommandBase
    {
        public Guid BookId { get; set; }

        public DeleteBookByIdCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
