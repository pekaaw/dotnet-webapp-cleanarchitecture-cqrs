using Application.UseCases.Write;
using Web.Exceptions;

namespace Web.Factories;

public class CommandHandlerFactory : ICommandHandlerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CommandHandlerFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }
    
    ICommandHandler<TCommand> ICommandHandlerFactory.Create<TCommand>()
    {
        var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

        if (handler == null)
        {
            throw new CommandHandlerNotFoundException<ICommandHandler<TCommand>>();
        }

        return handler;
    }
}
