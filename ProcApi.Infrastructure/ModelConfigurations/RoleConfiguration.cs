using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasMany(r => r.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        builder.HasMany(r => r.Users)
            .WithMany()
            .UsingEntity<UserRole>();

        var roles = Enum.GetValues<Roles>()
            .Select(r => new Role { Id = (int)r, Name = r.ToString() });

        builder.HasData(roles);
    }
}