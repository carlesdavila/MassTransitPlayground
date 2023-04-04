using MassTransit;
using Messages.Events;

namespace Consumer.Consumers;

public class AnotherMessageConsumer : IConsumer<AnotherMessage>
{
    public Task Consume(ConsumeContext<AnotherMessage> context)
    {
        Console.WriteLine("I Consume AnotherMessage!!! " + context.Message.Value1 + context.Message.Value2);
        //throw new Exception("Exception Consumer AnotherMessage thrown");
        return Task.CompletedTask;
    }
}