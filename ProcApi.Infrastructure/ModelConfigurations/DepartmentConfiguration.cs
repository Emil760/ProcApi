using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300);

        builder.HasOne(d => d.HeadUser)
            .WithMany()
            .HasForeignKey(d => d.HeadUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Users)
            .WithOne(u => u.Department)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(d => d.Name)
            .IsUnique();
    }
}