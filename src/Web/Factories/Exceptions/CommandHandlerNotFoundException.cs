using Application.UseCases.Write;

namespace Web.Factories.Exceptions;

public class CommandHandlerNotFoundException<TCommand> : Exception
    where TCommand : class, ICommand
{
    public CommandHandlerNotFoundException()
        : base($"Could not find any implementation of ICommandHandler<{typeof(TCommand).Name}>.")
    { }
}
