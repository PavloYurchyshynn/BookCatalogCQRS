using BookCatalogCQRS.Domain.Common;

namespace BookCatalogCQRS.Domain.Books
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? Created { get; set; }
    }
}
