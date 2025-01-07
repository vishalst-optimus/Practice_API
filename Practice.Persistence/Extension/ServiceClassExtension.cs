using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practice.Application.Extensions;
using Practice.Application.Interfaces;
using Practice.Persistence.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice.Persistence.Extension
{
    public static class ServiceClassExtension
    {
        public static void AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("ConnectionString");
            //Add DBContext
            //By calling AddDbContext, ASP.NET Core will automatically manage the lifecycle of ReportingContext and inject it wherever needed.
            services.AddDbContext<PracticeDbContext>(opt => opt.UseSqlServer(dbConnectionString).UseLazyLoadingProxies());

            //Add Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeProfileRepository, EmployeeProfileRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProjectRepository, ProjectRepository>();

            //Add Application layer dependency
            services.AddApplicationDI();
        }
    }
}
