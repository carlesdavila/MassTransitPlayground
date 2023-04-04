using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class BaseConsumer: IConsumer<IMessageInterface>
{
    public Task Consume(ConsumeContext<IMessageInterface> context)
    {
        Console.WriteLine("I Consume MyMessage!!! ");
        return Task.CompletedTask;

    }
}