using System.Text.Json.Serialization;
using MassTransit;
using Producer.Activities;

namespace Producer;

public static class MasstransitExtensions
{
    public static void AddConfiguredMassTransit(this IServiceCollection services)
    {
       
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            
            x.AddActivitiesFromNamespaceContaining<FirstActivity>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
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