using AutoMapper;
using BookCatalogCQRS.Application.Books.GetBooks;
using BookCatalogCQRS.Application.Configuration.Commands;
using BookCatalogCQRS.Application.Configuration.Queries;
using BookCatalogCQRS.Domain.Books;

namespace BookCatalogCQRS.Application.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = (await _bookRepository.GetAllAsync()).ToList();

            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
