// using Application.Factories;
// using Application.UseCases.Read;
// using Application.UseCases.Read.AllUsers;

// namespace Web.Factories;

// public class UseCaseReadHandlerFactory : IUseCaseReadHandlerFactory
// {
//     private IServiceProvider _serviceProvider;
    
//     public UseCaseReadHandlerFactory(
//         IServiceProvider serviceProvider
//     )
//     {
//         _serviceProvider = serviceProvider;
//     }

//     // Read.IHandler<T> Create<T>() where T : Read.ICommand
//     // {
//     //     return _serviceProvider.GetService<Read.IHandler<T>>();
//     // }

//     // Read.IHandler<AllUsersCommand, AllUsersResponse> Create<Read.AllUsers.AllUsersCommand>()
//     // {
//     //     return _serviceProvider.GetService<Read.IHandler<Read.AllUsers.AllUsersCommand>>();
//     // }

//     // IHandler<AllUsersCommand, AllUsersResponse> Create<AllUsersCommand>()
//     // {
//     //     return _serviceProvider.GetService<IHandler<AllUsersCommand, AllUsersResponse>>();
//     // }
// }
