using MassTransit;
using MassTransit.Courier.Contracts;
using Microsoft.AspNetCore.Mvc;
using Producer.Activities;

namespace Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutingSlipController: ControllerBase
{
    private readonly IEndpointNameFormatter _endpointNameFormatter;
    private readonly IBus _bus;

    public RoutingSlipController(IEndpointNameFormatter endpointNameFormatter, IBus bus)
    {
        _endpointNameFormatter = endpointNameFormatter;
        _bus = bus;
    }

    [HttpPost("ExecuteRS")]
    public async Task<IActionResult> PostMessage()
    {

        var rs = CreateRoutingSlip();
        
        await _bus.Execute(rs);
        
        return Ok();
    }

    private RoutingSlip CreateRoutingSlip()
    {
        var builder = new RoutingSlipBuilder(NewId.NextGuid());

        builder.AddSubscription(new Uri($"queue:some_subs"), RoutingSlipEvents.Completed | RoutingSlipEvents.Faulted);
        
        // var firstActivityQueueName = _endpointNameFormatter.ExecuteActivity<FirstActivity, FirstActivityLog>();
        var lastActivityQueueName = _endpointNameFormatter.ExecuteActivity<LastActivity, LastActivityArguments>();
        
        builder.AddVariable("TenantId", @"e9188b15-2ec9-46b5-821e-b1b3940f9a62");
        builder.AddActivity("FirstActivity", new Uri($"queue:first_execute"), 
            new
            {
                FirstActivityProp1 = "someValue"
            });
        builder.AddActivity("LastActivity", new Uri($"queue:{lastActivityQueueName}"));

        return builder.Build();
    }
}