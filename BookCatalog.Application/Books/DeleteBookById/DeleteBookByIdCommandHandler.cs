using BookCatalogCQRS.Application.Configuration.Commands;
using BookCatalogCQRS.Domain.Books;

namespace BookCatalogCQRS.Application.Books.DeleteBookById
{
    public class DeleteBookByIdCommandHandler : ICommandHandler<DeleteBookByIdCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookByIdCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null)
            {
                throw new ArgumentException();
            }

            await _bookRepository.DeleteAsync(book);
        }
    }
}
