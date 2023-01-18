using Application.UseCases.Write;
using Web.Factories;

namespace Web.Extensions;

public static class AddCommandHandlersExtension
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICommandHandlerFactory, CommandHandlerFactory>();

        return serviceCollection;
    }
}
