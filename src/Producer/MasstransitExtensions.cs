using System.Text.Json.Serialization;
using MassTransit;
using MassTransit.MessageData;
using Producer.Activities;

namespace Producer;

public static class MasstransitExtensions
{
    public static void AddConfiguredMassTransit(this IServiceCollection services)
    {
        IMessageDataRepository messageDataRepository = new InMemoryMessageDataRepository();

        services.AddMassTransit(x =>
        {
           // x.SetKebabCaseEndpointNameFormatter();
            
           // x.AddActivitiesFromNamespaceContaining<FirstActivity>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
               // cfg.UseMessageData(messageDataRepository);
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}