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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);

            //Many To Many relationship
            builder.HasMany(x => x.Employees)
                .WithMany(x => x.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeProjects",
                    j => j.HasOne<Employee>().WithMany().HasForeignKey("EmployeeID"),
                    j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectID")
                );
        }
    }
}
