using AutoMapper;
using BookCatalogCQRS.Application.Configuration.Queries;
using BookCatalogCQRS.Domain.Books;

namespace BookCatalogCQRS.Application.Books.GetBooks
{
    public sealed class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            return _mapper.Map<BookDto>(book);
        }
    }
}
