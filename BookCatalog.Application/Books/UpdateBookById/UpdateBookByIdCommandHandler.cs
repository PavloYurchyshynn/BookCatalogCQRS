using BookCatalogCQRS.Application.Configuration.Commands;
using BookCatalogCQRS.Domain.Books;
using MediatR;

namespace BookCatalogCQRS.Application.Books.UpdateBookById
{
    public class UpdateBookByIdCommandHandler : ICommandHandler<UpdateBookByIdCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookByIdCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new ArgumentException();
            }

            book.Description = request.Description;
            book.Price = request.Price;
            book.Author = request.Author;
            book.Name = request.Name;

            await _bookRepository.UpdateAsync(book);

            return Unit.Value;
        }
    }
}
