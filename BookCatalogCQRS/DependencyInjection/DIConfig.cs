using BookCatalogCQRS.Application.Books.AddBook;
using BookCatalogCQRS.Application.Books.GetBooks;
using BookCatalogCQRS.Application.MapperProfiles;
using BookCatalogCQRS.Domain.Books;
using BookCatalogCQRS.Infrastructure.Database;
using BookCatalogCQRS.Infrastructure.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogCQRS.API.DependencyInjection
{
    public static class DIConfig
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BooksContext>(options => options.UseSqlServer(connection));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookProfile).Assembly);
        }

        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetBookByIdQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(AddBookCommandHandler).Assembly);
            });
        }
    }
}
