using Application.UseCases.Read;
using Application.UseCases.Read.AllUsers;
using Application.UseCases.Read.FirstUser;
using Application.UseCases.Read.SecondUser;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ReadController : Controller
{
    private readonly IQueryHandlerFactory _queryHandlerFactory;
    // private IUseCaseReadHandlerFactory _useCaseReadHandlerFactory;
    private IHandlerFactory _handlerFactory;
    private ISecondHandlerFactory _secondHandlerFactory;
    
    public ReadController(
        IQueryHandlerFactory queryHandlerFactory,
        IHandlerFactory handlerFactory,
        ISecondHandlerFactory secondHandlerFactory
        // Application.Factories.IUseCaseReadHandlerFactory useCaseReadHandlerFactory
    )
    {
        _queryHandlerFactory = queryHandlerFactory;
        _handlerFactory = handlerFactory;
        _secondHandlerFactory = secondHandlerFactory;
        // _useCaseReadHandlerFactory = useCaseReadHandlerFactory;
    }

    public IActionResult OneUser()
    {
        var handler = _handlerFactory.Create<FirstUserCommand>();
        handler.Handle(new FirstUserCommand());

        return Json("success");
    }

    public IActionResult SecondUser()
    {
        Application.UseCases.Read.SecondUser.IQuery query = new SecondUserQuery();
        IQueryResponse response = new SecondUserResponse();

        var handler = _secondHandlerFactory.Create<SecondUserQuery>();
        var output = handler.Handle(new SecondUserQuery());

        return Json(output);
    }

    public async Task<IActionResult> AllUsers(AllUsersQuery query)
    {
        var useCaseHandler = _queryHandlerFactory.Create<AllUsersQuery, AllUsersResponse>();
        var result = await useCaseHandler.HandleAsync(query);

        return Json(result);
    }
}
