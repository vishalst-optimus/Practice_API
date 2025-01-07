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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.Property(dept => dept.Id).IsRequired();
            builder.Property(dept =>dept.Name).IsRequired();
            builder.HasKey(dept => dept.Id);
        }
    }
}
