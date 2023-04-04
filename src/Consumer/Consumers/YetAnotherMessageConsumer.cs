using MassTransit;
using Messages.Events;

namespace Consumer.Consumers;

public class YetAnotherMessageConsumer : IConsumer<YetAnotherMessage>
{
    public Task Consume(ConsumeContext<YetAnotherMessage> context)
    {
        Console.WriteLine("I Consume YetAnotherMessage!!! " + context.Message.Value + context.Message.Value2);
        //throw new Exception("Exception Consumer YetAnotherMessage thrown");
        return Task.CompletedTask;
    }
}