using System;

namespace Application.UseCases.Read.ThirdUser;

public interface IRequest {}
public interface ICommand : IRequest {}
public interface IQuery : IRequest {}
public interface IResponse {}
public interface IResponse<TRequest> : IResponse
    where TRequest: class, IRequest {}

public class TestCommand1 : ICommand {}
public class TestCommand2 : ICommand {}
public class TestQuery1 : IQuery {}
public class TestQuery2 : IQuery {}

public class TestResponse1 : IResponse<TestCommand1>, IResponse<TestCommand2>
{
    public string Id = "TestResponse1";
}
public class TestResponse2 : IResponse<TestQuery2>
{
    public string Id = "TestResponse2";
}
public class TestResponse3 : IResponse
{
    public string Id = "TestResponse3";
}

public interface IHandler<TRequest, TResponse>
    where TRequest : class, IRequest
    where TResponse : class, IResponse
{
    TResponse Handle(TRequest request);
}

public interface ICommandHandler<TCommand>
    where TCommand : class, ICommand
{
    bool Handle(TCommand command);
}

public interface IQueryHandler<TQuery, TResponse>
    where TQuery : class, IQuery
    where TResponse : class, IResponse
{
    TResponse Handle(TQuery query);
}

public class TestCommand1Handler : ICommandHandler<TestCommand1>
{
    public bool Handle(TestCommand1 command)
    {
        return true;
    }
}
public class TestCommand2Handler : ICommandHandler<TestCommand2>
{
    public bool Handle(TestCommand2 command)
    {
        return true;
    }
}
public class TestQuery1Handler : IQueryHandler<TestQuery1, TestResponse1>
{
    public TestResponse1 Handle(TestQuery1 request)
    {
        return new TestResponse1();
    }
}
public class TestQuery2Handler : IQueryHandler<TestQuery2, TestResponse2>
{
    public TestResponse2 Handle(TestQuery2 request)
    {
        return new TestResponse2();
    }
}

public interface ICommandHandlerFactory
{
    ICommandHandler<TCommand> Create<TCommand>() where TCommand : class, ICommand;
}

public class CommandHandlerFactory : ICommandHandlerFactory
{
    private IServiceProvider _serviceProvider;
    
    public CommandHandlerFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    ICommandHandler<TCommand> ICommandHandlerFactory.Create<TCommand>()
    {
        var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>));
        return (ICommandHandler<TCommand>)handler;
    }
}

public interface IQueryHandlerFactory
{
    IQueryHandler<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : class, IQuery
        where TResponse : class, IResponse;
}

public class QueryHandlerFactory : IQueryHandlerFactory
{
    private IServiceProvider _serviceProvider;

    public QueryHandlerFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }
    
    public IQueryHandler<TQuery, TResponse> Create<TQuery, TResponse>()
        where TQuery : class, IQuery
        where TResponse : class, IResponse
    {
        var queryHandler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>));
        return (IQueryHandler<TQuery, TResponse>)queryHandler;
    }

    // public static AddQueryHandlers(this IServiceCollection serviceCollection)
    // {
    //     serviceCollection.AddTransient<IQueryHandler<TestQuery2, TestResponse2>, TestQuery2Handler>();
    // }
}
