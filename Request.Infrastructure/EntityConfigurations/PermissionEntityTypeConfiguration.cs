using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.Domain.AggregatesModel.Permission;
using System;

namespace Request.Infrastructure.EntityConfigurations
{
    public class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", RequestContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).UseHiLo("permissionseq", RequestContext.DEFAULT_SCHEMA);
            builder.Ignore(p => p.PermissionType);

            builder
                .Property<string>("_employeeName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EmployeeName")
                .IsRequired();
            builder
                .Property<string>("_employeeLastName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EmployeeLastName")
                .IsRequired();

            builder
                .Property<int?>("_permissionTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PermissionTypeId")
                .IsRequired();

            builder
                .Property<DateTime?>("_permissionDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PermissionDate")
                .IsRequired();

            builder.HasOne(p => p.PermissionType)
                .WithMany()
                .HasForeignKey("_permissionTypeId");
        }
    }
}
