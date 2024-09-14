
using ApiService.Services.AuthService;
using MassTransit;
namespace ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IAuthService, AuthService>();

            builder.Services.AddMassTransit(x =>
            {


                x.UsingRabbitMq((context, cfg) =>
                {

                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");

                    });
                });
            });
          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
