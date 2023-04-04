using MassTransit;
using Messages.Events;
using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public PublisherController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    [HttpPost("Message")]
    public async Task<IActionResult> PostMessage([FromBody] MyMessage message)
    {
        await _publishEndpoint.Publish(message);

        return Ok();
    }
    
    [HttpPost("AnotherMessage")]
    public async Task<IActionResult> PostAnotherMessage([FromBody] AnotherMessage message)
    {
        await _publishEndpoint.Publish(message);

        return Ok();
    }
    
    [HttpPost("YetAnotherMessage")]
    public async Task<IActionResult> PostYetAnotherMessage([FromBody] YetAnotherMessage message)
    {
        await _publishEndpoint.Publish(message);

        return Ok();
    }
}