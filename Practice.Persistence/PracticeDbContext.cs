using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Domain.Entities;

namespace Practice.Persistence
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions<PracticeDbContext> options) : base(options)
        {

        }

        //Should be protected
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adds all configurations (Fluent API's) of type IEntityConfiguration<TEntity>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PracticeDbContext).Assembly);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public IEnumerable<object> Employee { get; internal set; }
    }
}
