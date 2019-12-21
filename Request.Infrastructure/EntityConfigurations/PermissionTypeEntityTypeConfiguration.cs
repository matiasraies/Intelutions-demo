using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.Domain.AggregatesModel.Permission;

namespace Request.Infrastructure.EntityConfigurations
{
    public class PermissionTypeEntityTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionType", RequestContext.DEFAULT_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(o => o.Id).UseHiLo("permissiontypeseq", RequestContext.DEFAULT_SCHEMA);

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .IsRequired(false);
        }
    }
}
