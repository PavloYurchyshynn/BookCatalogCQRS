namespace BookCatalogCQRS.Application.Books.GetBooks
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? Created { get; set; }
    }
}
