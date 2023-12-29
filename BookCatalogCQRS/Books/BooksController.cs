using BookCatalogCQRS.Application.Books.AddBook;
using BookCatalogCQRS.Application.Books.DeleteBookById;
using BookCatalogCQRS.Application.Books.GetAllBooks;
using BookCatalogCQRS.Application.Books.GetBooks;
using BookCatalogCQRS.Application.Books.UpdateBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogCQRS.API.Books
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());

            return Ok(books);
        }

        [Route("{bookId}")]
        [HttpGet]
        public async Task<IActionResult> GetBookById([FromRoute] Guid bookId)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(bookId));

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookRequest request)
        {
            var bookId = await _mediator.Send(new AddBookCommand(request.Name, request.Description, request.Author, request.Price));

            return Ok(bookId);
        }

        [Route("{bookId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid bookId, [FromBody] BookRequest request)
        {
            var book = await _mediator.Send(new UpdateBookByIdCommand(bookId, request.Name, request.Description, request.Author, request.Price));

            return Ok(book);
        }

        [Route("{bookId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid bookId)
        {
            await _mediator.Send(new DeleteBookByIdCommand(bookId));

            return Ok();
        }
    }
}
