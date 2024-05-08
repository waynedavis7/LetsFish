using MediatR;

namespace LetsFish.Shared.CQRS;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, IResult<TResponse>> where TQuery : IQuery<TResponse>
{ }
