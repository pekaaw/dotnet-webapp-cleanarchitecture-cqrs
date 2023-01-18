using System.Threading.Tasks;

namespace Application.UseCases.Read;

public interface IQueryHandler<TQuery, TResponse>
    where TQuery : class, IQuery
    where TResponse : class, IResponse
{
    Task<TResponse> HandleAsync(TQuery query);
}
