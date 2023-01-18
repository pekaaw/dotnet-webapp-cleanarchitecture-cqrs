namespace Application.UseCases.Read.FirstUser;

public interface ICommand {}

public class FirstUserCommand : ICommand {}

public interface IHandler<TCommand>
    where TCommand : ICommand
{
    void Handle(TCommand command);
}

public class FirstUserHandler : IHandler<FirstUserCommand>
{
    public void Handle(FirstUserCommand command)
    {
        // handler code ...
    }
}

public interface IHandlerFactory
{
    // IHandler<TCommand> Create<TCommand>() where TCommand : ICommand;
    IHandler<FirstUserCommand> Create<FirstUserCommand>() where FirstUserCommand : ICommand;
}

public class HandlerFactory : IHandlerFactory
{
    public IHandler<FirstUserCommand> Create<FirstUserCommand>() where FirstUserCommand : ICommand
    {
        return (IHandler<FirstUserCommand>)new FirstUserHandler();
    }
}