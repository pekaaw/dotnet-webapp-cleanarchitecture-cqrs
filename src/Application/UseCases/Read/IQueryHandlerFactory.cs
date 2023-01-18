namespace Application.UseCases.Read;

public interface IQueryHandlerFactory
{
    IQueryHandler<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : class, IQuery
        where TResponse : class, IResponse;
}
