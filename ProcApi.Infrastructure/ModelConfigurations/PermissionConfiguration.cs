using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace  ProcApi.Infrastructure.ModelConfigurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasMany(r => r.Roles)
            .WithMany()
            .UsingEntity<RolePermission>();

        var permission = Enum.GetValues<Permissions>()
            .Select(p => new Permission() { Id = (int)p, Name = p.ToString() });

        builder.HasData(permission);
    }
}