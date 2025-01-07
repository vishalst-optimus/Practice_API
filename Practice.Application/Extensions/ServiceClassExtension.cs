using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Application.Commands;
using Practice.Application.Handlers;
using Practice.Application.Queries;

namespace Practice.Application.Extensions
{
    public static class ServiceClassExtension 
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceClassExtension).Assembly;
            services.AddMediatR(con => con.RegisterServicesFromAssemblies(applicationAssembly));

            services.AddAutoMapper(applicationAssembly);

            RegisterGenericHandlers(services);
        }

        private static void RegisterGenericHandlers(IServiceCollection services)
        {
            Assembly assembly = Assembly.Load("Practice.Domain");  // Use the assembly name

            // Specify the namespace you want to filter by
            string targetNamespace = "Practice.Domain.Entities";

            // Get all types (classes, interfaces, enums, etc.) from the assembly
            Type[] types = assembly.GetTypes();

            var classTypes = types
                .Where(t => t.IsClass && t.Namespace == targetNamespace)  // Ensure only classes in the target namespace
                .ToArray();

            foreach (var item in classTypes)
            {
                //Create Command
                var createRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(CreateCommand<>).MakeGenericType(item), item);
                var createCommandHandlerType = typeof(CreateCommandHandler<>).MakeGenericType(item);

                //Get Query
                var getRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(GetQuery<>).MakeGenericType(item), item);
                var getQueryHandlerType = typeof(GetQueryHandler<>).MakeGenericType(item);

                //Delete Command
                var deleteRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(DeleteCommand<>).MakeGenericType(item), typeof(bool));
                var deleteCommandHandlerType = typeof(DeleteCommandHandler<>).MakeGenericType(item);

                //Get All Query
                var getAllRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(GetAllDataQuery<>).MakeGenericType(item), typeof(IEnumerable<>).MakeGenericType(item));
                var getAllQueryHandlerType = typeof(GetAllDataQueryhandler<>).MakeGenericType(item);

                services.AddScoped(createRequestHandlerType, createCommandHandlerType);
                services.AddScoped(getRequestHandlerType, getQueryHandlerType);
                services.AddScoped(deleteRequestHandlerType, deleteCommandHandlerType);
                services.AddScoped(getAllRequestHandlerType, getAllQueryHandlerType);
            }
        }
    }
}
