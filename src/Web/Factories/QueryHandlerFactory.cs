using Application.UseCases.Read;
using Web.Exceptions;

namespace Web.Factories;

public class QueryHandlerFactory : IQueryHandlerFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public QueryHandlerFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    IQueryHandler<TQuery, TResponse> IQueryHandlerFactory.Create<TQuery, TResponse>()
    {
        var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResponse>>();

        if (handler == null)
        {
            throw new QueryHandlerNotFoundException<IQueryHandler<TQuery, TResponse>>();
        }

        return handler;
    }
}
