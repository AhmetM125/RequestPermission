using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Api.Entity;

namespace RequestPermission.Api.Infrastracture.DatabaseConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.E_ID);
        builder.Property(x => x.E_NAME).IsRequired().HasMaxLength(50);
        builder.Property(x => x.E_SURNAME).IsRequired().HasMaxLength(50);
        builder.Property(x => x.E_DEPARTMENT);
        builder.Property(x => x.E_TITLE).HasColumnType("nvarchar(50)").HasMaxLength(50);
        builder.Property(x => x.InsertUser).HasColumnType("nvarchar(50)");
        builder.Property(x => x.InsertDate).HasColumnType("datetime");
        builder.Property(x => x.UpdateDate).HasColumnType("datetime");
        builder.Property(x => x.UpdateUser).HasColumnType("nvarchar(50)");
        builder.HasOne(x => x.EMPLOYEE_COMMUNICATION)
            .WithOne().HasForeignKey<Employee>(x => x.E_EMP_COMM_ID).OnDelete(DeleteBehavior.NoAction);

    }
}
