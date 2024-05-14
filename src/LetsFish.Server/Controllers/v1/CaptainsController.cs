namespace LetsFish.Server.Controllers.v1;

public class CaptainsController : BaseApiController<CaptainsController>
{
    [HttpGet]
    public async Task<IActionResult> GetCaptains()
    {
        var captains = await _mediator.Send(new AnglersQuery());
        return Ok(captains);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Captain captain)
    {
        return Ok(await _mediator.Send(new AnglerAddCommand() { Captain = captain }));
    }
}