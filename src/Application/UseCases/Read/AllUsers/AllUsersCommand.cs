using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.UseCases.Read.AllUsers;

public class AllUsersQuery : IQuery
{ }

public class AllUsersResponse : IResponse
{
    public List<User> Users { get; set; }
}

public class AllUsersHandler : IQueryHandler<AllUsersQuery, AllUsersResponse>
{
    public Task<AllUsersResponse> HandleAsync(AllUsersQuery query)
    {
        var response = new AllUsersResponse
        {
            Users = new List<User> {
                new User(),
                new User()
            }
        };

        return Task.FromResult(response);
    }
}
