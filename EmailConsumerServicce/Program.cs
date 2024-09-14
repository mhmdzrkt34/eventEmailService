using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using EmailConsumerServicce.Consumers;
namespace EmailConsumerServicce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureServices((hostContext, services) =>
             {

                 services.AddMassTransit(x =>
                 {
                     // Register the consumer
                     x.AddConsumer<SendEmailEventConsumer>();

                     // Configure RabbitMQ as the transport
                     x.UsingRabbitMq((context, cfg) =>
                     {
                         cfg.Host("rabbitmq://localhost", h =>
                         {
                             h.Username("guest");
                             h.Password("guest");
                         });

                         // Use Newtonsoft.Json for serialization/deserialization
                         cfg.UseNewtonsoftJsonSerializer();

                         // Configure the endpoint to consume messages
                         cfg.ReceiveEndpoint("email_consumer_queue", e =>
                         {
                             e.ConfigureConsumer<SendEmailEventConsumer>(context);
                         });
                     });
                 });
                 // Register the Worker service
                 services.AddHostedService<Worker>();
             });
    }
}