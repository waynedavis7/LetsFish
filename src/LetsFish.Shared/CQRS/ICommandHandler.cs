using MediatR;

namespace LetsFish.Shared.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, IResult> where TCommand : ICommand { }

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, IResult<TResponse>>
    where TCommand : ICommand<TResponse>
{ }
