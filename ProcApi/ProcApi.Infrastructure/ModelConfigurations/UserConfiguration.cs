using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .HasColumnType("varchar(300)")
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnType("varchar(300)")
            .IsRequired();

        builder.Property(u => u.Gender)
            .HasColumnType("int")
            .IsRequired()
            .HasDefaultValue(Gender.Unknown);

        builder.HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity<UserRole>();

        builder.HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(u => u.FromDelegations)
            .WithOne(fd => fd.FromUser)
            .HasForeignKey(d => d.FromUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.ToDelegations)
            .WithOne(td => td.ToUser)
            .HasForeignKey(d => d.ToUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Documents)
            .WithOne(d => d.CreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.NoAction);
    }
}