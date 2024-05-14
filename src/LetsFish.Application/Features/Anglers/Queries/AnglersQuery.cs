using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Anglers.Queries;

public class AnglersQuery : IQuery<IEnumerable<Angler>> { }

internal class AnglersQueryHandler : IQueryHandler<AnglersQuery, IEnumerable<Angler>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AnglersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<IEnumerable<Angler>>> Handle(AnglersQuery request, CancellationToken cancellationToken)
    {
        var anglers = await _unitOfWork.AnglerRepository.GetAllAsync();
        return Result<IEnumerable<Angler>>.Success(anglers);
    }
}