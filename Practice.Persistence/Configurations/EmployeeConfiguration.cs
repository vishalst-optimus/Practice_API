using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Domain.Entities;

namespace Practice.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.Property(emp => emp.Salary).IsRequired();
            builder.Property(emp => emp.Name).IsRequired();
            builder.Property(emp => emp.Position).IsRequired();
            builder.HasKey(emp => emp.Id);
            builder.Property(emp => emp.Id).IsRequired();

            //Many(Employees) to One(Department)
            builder.HasOne(emp => emp.Department)
                .WithMany(emp => emp.Employees)
                .HasForeignKey(emp => emp.DepartmentId);

            //One to One
            builder.HasOne(emp => emp.EmployeeProfile)
                .WithOne(emp => emp.Employee)
                .HasForeignKey<Employee>(emp => emp.EmployeeProfileId);
        }
    }
}
