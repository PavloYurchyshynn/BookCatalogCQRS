using MediatR;

namespace BookCatalogCQRS.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
