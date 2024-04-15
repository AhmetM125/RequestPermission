using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.D_ID);
            builder.Property(x => x.D_NAME).IsRequired().HasMaxLength(50);
            builder.Property(x => x.InsertUser).HasColumnType("nvarchar(50)");
            builder.Property(x => x.InsertDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateUser).HasColumnType("nvarchar(50)");

            builder.HasMany(d => d.EMPLOYEES)
            .WithOne(e => e.DEPARTMENT)
            .HasForeignKey(e => e.E_DEPARTMENT)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
