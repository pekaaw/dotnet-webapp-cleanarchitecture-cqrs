namespace Application.UseCases.Read;

public interface IResponse
{ }

public interface IResponse<TRequest> : IResponse
    where TRequest : class, IRequest
{ }
