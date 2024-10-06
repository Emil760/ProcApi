using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UserPasswordConfiguration : IEntityTypeConfiguration<UserPassword>
{
    public void Configure(EntityTypeBuilder<UserPassword> builder)
    {
        builder.HasKey(up => up.Id);

        builder.Property(up => up.Id)
            .ValueGeneratedNever();

        builder.HasOne(up => up.User)
            .WithOne(u => u.UserPassword)
            .HasForeignKey<UserPassword>(up => up.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}