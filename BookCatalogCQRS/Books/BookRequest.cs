namespace BookCatalogCQRS.API.Books
{
    public class BookRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
