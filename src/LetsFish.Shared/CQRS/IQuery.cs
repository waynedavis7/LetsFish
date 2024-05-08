using MediatR;

namespace LetsFish.Shared.CQRS;

public interface IQuery<TResponse> : IRequest<IResult<TResponse>> { }
