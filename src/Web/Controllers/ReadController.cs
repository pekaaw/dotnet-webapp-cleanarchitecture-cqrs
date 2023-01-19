using Application.UseCases.Read;
using Application.UseCases.Read.AllUsers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ReadController : Controller
{
    private readonly IQueryHandlerFactory _queryHandlerFactory;
    
    public ReadController(
        IQueryHandlerFactory queryHandlerFactory
    )
    {
        _queryHandlerFactory = queryHandlerFactory;
    }

    public async Task<IActionResult> AllUsers(AllUsersQuery query)
    {
        var useCaseHandler = _queryHandlerFactory.Create<AllUsersQuery, AllUsersResponse>();
        var allUsers = await useCaseHandler.HandleAsync(query);

        return Json(allUsers);
    }
}
