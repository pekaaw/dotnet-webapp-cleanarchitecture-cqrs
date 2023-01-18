namespace Web.Exceptions;

public class CommandHandlerNotFoundException<TCommandHandler> : Exception
{
    public CommandHandlerNotFoundException()
        : base($"Could not find any handler for type {nameof(TCommandHandler)}.")
    { }
}
