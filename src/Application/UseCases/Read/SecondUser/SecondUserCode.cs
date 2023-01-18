using System;

namespace Application.UseCases.Read.SecondUser;

public interface IQuery {}
public interface IQueryResponse {}

public class SecondUserQuery : IQuery {}
public class SecondUserResponse : IQueryResponse {
    public bool Success { get; set; } = true;
}
public class SecondUserResponse2 : SecondUserResponse {}

public interface IHandle<in TQuery, out TResponse>
    where TQuery : class, IQuery
    where TResponse : class, IQueryResponse
// public interface IHandle<TQuery, TResponse>
//     where TQuery : IQuery
//     where TResponse : IQueryResponse
{
    TResponse Handle(TQuery query);
}

public class SecondUserHandler : IHandle<SecondUserQuery, SecondUserResponse>
{
    public SecondUserResponse Handle(SecondUserQuery query)
    {
        return new SecondUserResponse();
    }
}

public interface IResponse<T> where T : class, IQuery {}
public interface ISecondHandlerFactory
{
    IHandle<SecondUserQuery, SecondUserResponse> Create<SecondUserQuery>()
        where SecondUserQuery : class, IQuery;

    // IHandle<SecondUserQuery, SecondUserResponse2> Create2<SecondUserQuery>()
    //     where SecondUserQuery : class, IQuery;

    // IHandle<T, IResponse<T>> Create<T>()
    //     where T : class, IQuery;
}

public class SecondHandlerFactory : ISecondHandlerFactory
{
    private IServiceProvider _serviceProvider;
    
    public SecondHandlerFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IHandle<SecondUserQuery, SecondUserResponse> Create<SecondUserQuery>()
        where SecondUserQuery : class, IQuery
    {
        var handler = _serviceProvider.GetService(typeof(IHandle<SecondUserQuery, SecondUserResponse>));
        return (IHandle<SecondUserQuery, SecondUserResponse>)handler;
        // var handler = new SecondUserHandler();
        // var handlerType = handler as IHandle<SecondUserQuery, SecondUserResponse>;
        // return handlerType;

    // public IHandle<IQuery, IQueryResponse> Create<SecondUserQuery>() where SecondUserQuery : class, IQuery
    // {
    //     var handler = new SecondUserHandler();
    //     var handlerType = handler as IHandle<SecondUserQuery, SecondUserResponse>;
    //     return (IHandle<IQuery, IQueryResponse>) handlerType;
        // var result = handler as IHandle<IQuery, IQueryResponse>;

        // return result;
        // return (IHandle<IQuery, IQueryResponse>)new SecondUserHandler();
    }
}
