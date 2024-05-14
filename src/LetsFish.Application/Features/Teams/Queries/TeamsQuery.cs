using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Teams.Queries;

public class TeamsQuery : IQuery<IEnumerable<Team>> { }

internal class TeamsQueryHandler : IQueryHandler<TeamsQuery, IEnumerable<Team>>
{
    private readonly IUnitOfWork _unitOfWork;

    public TeamsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<IEnumerable<Team>>> Handle(TeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _unitOfWork.TeamRepository.GetAllAsync();
        return Result<IEnumerable<Team>>.Success(teams);
    }
}