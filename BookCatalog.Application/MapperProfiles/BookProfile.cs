using AutoMapper;
using BookCatalogCQRS.Application.Books.GetBooks;
using BookCatalogCQRS.Domain.Books;

namespace BookCatalogCQRS.Application.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
