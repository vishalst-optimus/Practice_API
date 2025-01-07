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
    public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
        {
            builder.ToTable("EmployeeProfiles");
            builder.Property(emp => emp.PhoneNumber).IsRequired();
            builder.Property(emp => emp.Address).IsRequired();
            builder.Property(emp => emp.ImageUrl).IsRequired();
            builder.Property(emp => emp.Id).IsRequired();
            builder.HasKey(emp => emp.Id);
        }
    }
}
