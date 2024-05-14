using LetsFish.Application.Features.Teams.Commands;
using LetsFish.Application.Features.Teams.Queries;

namespace LetsFish.Server.Controllers.v1;

public class TeamsController : BaseApiController<TeamsController>
{
    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var captains = await _mediator.Send(new TeamsQuery());
        return Ok(captains);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Team team)
    {
        return Ok(await _mediator.Send(new TeamAddCommand() { Team = team }));
    }
}