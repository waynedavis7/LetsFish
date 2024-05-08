using MediatR;

namespace LetsFish.Shared.CQRS;

public interface ICommand : IRequest<IResult> { }
public interface ICommand<TResponse> : IRequest<IResult<TResponse>> { }