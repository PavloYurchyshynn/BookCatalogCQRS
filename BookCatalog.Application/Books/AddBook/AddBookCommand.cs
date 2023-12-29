using BookCatalogCQRS.Application.Configuration.Commands;

namespace BookCatalogCQRS.Application.Books.AddBook
{
    public class AddBookCommand : CommandBase<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }

        public AddBookCommand(
            string? name,
            string? description,
            string? author,
            decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Author = author;
            this.Price = price;
        }
    }
}
