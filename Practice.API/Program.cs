
using System.Collections;
using System.Reflection;
using MediatR;
using Practice.Application.Commands;
using Practice.Application.Extensions;
using Practice.Application.Handlers;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;
using Practice.Persistence.Extension;
using Practice.Persistence.Repositories;

namespace Practice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add Persistence layer dependency
            builder.Services.AddPersistenceDI(configuration);

            //Add Application layer dependency
            //builder.Services.AddApplicationDI();

            //builder.Services.AddScoped(typeof(IRequestHandler<CreateCommand<Employee>, Employee>), typeof(CreateCommand<Employee>));

            //Type[] classTypes = new Type[] {typeof(Employee), typeof(Department), typeof(EmployeeProfile), typeof(Project)};
            //foreach (var item in classTypes)
            //{
            //    var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(CreateCommand<>).MakeGenericType(item), item);
            //    var commandHandlerType = typeof(CreateCommandHandler<>).MakeGenericType(item);

            //    builder.Services.AddScoped(requestHandlerType, commandHandlerType);
            //}

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
