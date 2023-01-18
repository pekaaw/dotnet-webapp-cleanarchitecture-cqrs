namespace Application.UseCases.Write;

public interface ICommandHandlerFactory
{
    ICommandHandler<TCommand> Create<TCommand>()
        where TCommand : class, ICommand;
}
