using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DelegationConfiguration : IEntityTypeConfiguration<Delegation>
{
    public void Configure(EntityTypeBuilder<Delegation> builder)
    {
        builder.HasOne(d => d.FromUser)
            .WithMany(u => u.FromDelegations)
            .HasForeignKey(u => u.FromUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.ToUser)
            .WithMany(u => u.ToDelegations)
            .HasForeignKey(u => u.ToUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}