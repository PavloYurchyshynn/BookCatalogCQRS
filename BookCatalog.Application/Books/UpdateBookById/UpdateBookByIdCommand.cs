using BookCatalogCQRS.Application.Configuration.Commands;
using MediatR;

namespace BookCatalogCQRS.Application.Books.UpdateBookById
{
    public class UpdateBookByIdCommand : CommandBase<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }

        public UpdateBookByIdCommand(
            Guid id,
            string? name,
            string? description,
            string? author,
            decimal price)
        {
            Id = id;
            this.Name = name;
            this.Description = description;
            this.Author = author;
            this.Price = price;
        }
    }
}
