using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UserPasswordConfiguration : IEntityTypeConfiguration<UserPassword>
{
    public void Configure(EntityTypeBuilder<UserPassword> builder)
    {
        builder.HasKey(up => up.UserId);

        builder.HasOne(up => up.User)
            .WithOne(u => u.UserPassword)
            .HasForeignKey<UserPassword>(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}