namespace Application.UseCases.Write;

public interface IResponse
{ }

public interface IResponse<TRequest> : IResponse
    where TRequest : class, IRequest
{ }
