using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);


//var rabbit = builder.AddRabbitMQ("rabbit",
//    builder.CreateResourceBuilder(new ParameterResource("username", _ => "guest")),
//    builder.CreateResourceBuilder(new ParameterResource("password", _ => "guest"))
//    ).WithManagementPlugin();

var rabbit = builder.AddContainer("test-rabbit", "rabbitmq", "3-management")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "guest")
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "guest")
    .WithEndpoint(scheme: "tcp", targetPort: 5672, port: 5672, isProxied: false)
    .WithEndpoint(scheme: "http", targetPort: 15672, port: 15672, isProxied: false);

var endpoint = rabbit.GetEndpoint("endpoint");

builder.AddProject<Projects.Producer>("producer").WithReference(endpoint);

builder.AddProject<Projects.Consumer>("consumer").WithReference(endpoint);

builder.Build().Run();
