using Application.UseCases.Read;

namespace Web.Factories.Exceptions;

public class QueryHandlerNotFoundException<TQuery, TResponse> : Exception
    where TQuery : class, IQuery
    where TResponse : class
{
    public QueryHandlerNotFoundException()
        : base($"Could not find any implementation of IQueryHandler<{typeof(TQuery).Name}, {typeof(TResponse).Name}>.")
    { }
}
