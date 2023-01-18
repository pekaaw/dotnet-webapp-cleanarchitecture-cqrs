namespace Web.Exceptions;

public class QueryHandlerNotFoundException<TQueryHandler> : Exception
{
    public QueryHandlerNotFoundException()
        : base($"Could not find any handler for type {nameof(TQueryHandler)}.")
    { }
}
