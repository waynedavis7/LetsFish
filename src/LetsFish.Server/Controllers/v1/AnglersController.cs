namespace LetsFish.Server.Controllers.v1;


public class AnglersController : BaseApiController<AnglersController>
{
    [HttpGet]
    public async Task<IActionResult> GetAnglers()
    {
        var captains = await _mediator.Send(new Application.Features.Anglers.Queries.AnglersQuery());
        return Ok(captains);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Angler angler)
    {
        return Ok(await _mediator.Send(new Application.Features.Anglers.Commands.AnglerAddCommand() { Angler = angler }));
    }
}
