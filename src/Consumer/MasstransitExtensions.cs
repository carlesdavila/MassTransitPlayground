using System.Text.Json.Serialization;
using MassTransit;

namespace Consumer;

public static class MasstransitExtensions
{
    public static void AddConfiguredMassTransit(this IServiceCollection services)
    {
       
        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(Program).Assembly);
            
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