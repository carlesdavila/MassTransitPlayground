using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.StateMachines;

namespace Producer.Controllers;

public class StateMachineController: ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public StateMachineController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("Execute")]
    public async Task<IActionResult> PostMessage()
    {
        await _publishEndpoint.Publish<ComplexProcessRequested>(new
        {
            JobId = Guid.NewGuid()
        });
        return Ok();
    }
}