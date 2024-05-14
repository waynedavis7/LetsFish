using LetsFish.Application.Core.Database;

namespace LetsFish.Application.Features.Teams.Commands;

public class TeamAddCommand : ICommand<int>
{
    public Team Team { get; set; }
}

internal class CaptainAddCommandHandler : ICommandHandler<TeamAddCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CaptainAddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult<int>> Handle(TeamAddCommand request, CancellationToken cancellationToken)
    {
        if (request.Team.TeamId > 0)
        {
            _unitOfWork.TeamRepository.Update(request.Team);
        }
        else
        {
            await _unitOfWork.TeamRepository.InsertAsync(request.Team);
        }

        await _unitOfWork.Save();

        return await Result<int>.SuccessAsync(request.Team.TeamId);
    }

}