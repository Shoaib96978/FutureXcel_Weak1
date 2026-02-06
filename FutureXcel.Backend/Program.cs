
using FutureXcel.Backend.Data;
using FutureXcel.Backend.Services.Implementations;
using FutureXcel.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

namespace FutureXcel.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFutureXcel_UI", policy =>
                {
                    policy
                    .WithOrigins("https://localhost:7100")
                    .WithHeaders()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });

            // dependency injections
            builder.Services.AddScoped<IHealthService, HealthService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFutureXcel_UI");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
