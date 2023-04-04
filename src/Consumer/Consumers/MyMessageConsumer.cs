using MassTransit;
using Messages.Events;

namespace Consumer.Consumers;

public class MyMessageConsumer : IConsumer<MyMessage>
{
    public Task Consume(ConsumeContext<MyMessage> context)
    {
        Console.WriteLine("I Consume  MyMessage!!! " + context.Message.Value);
        //throw new Exception("Exception Consumer MyMessage thrown");
        return Task.CompletedTask;
    }
}