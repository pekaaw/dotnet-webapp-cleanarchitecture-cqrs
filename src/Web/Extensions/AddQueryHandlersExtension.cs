using Application.UseCases.Read;
using Application.UseCases.Read.AllUsers;
using Web.Factories;

namespace Web.Extensions;

public static class AddQueryHandlersExtension
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IQueryHandlerFactory, QueryHandlerFactory>();

        serviceCollection.AddTransient<IQueryHandler<AllUsersQuery, AllUsersResponse>, AllUsersHandler>();

        return serviceCollection;
    }
}
