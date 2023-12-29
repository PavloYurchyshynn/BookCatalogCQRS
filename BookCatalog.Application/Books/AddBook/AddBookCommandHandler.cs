using BookCatalogCQRS.Application.Configuration.Commands;
using BookCatalogCQRS.Domain.Books;

namespace BookCatalogCQRS.Application.Books.AddBook
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Name = request.Name,
                Author = request.Author,
                Description = request.Description,
                Price = request.Price,
                Created = DateTime.UtcNow,
            };

            Guid addedBookId = await _bookRepository.AddAsync(book);
            return addedBookId;
        }
    }
}
