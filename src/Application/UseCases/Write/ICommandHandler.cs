using System.Threading.Tasks;

namespace Application.UseCases.Write;

public interface ICommandHandler<TCommand>
    where TCommand : class, ICommand
{
    Task<bool> HandleAsync(ICommand command);
}
