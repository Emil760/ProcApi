using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.HasMany(um => um.Converters)
            .WithOne(umc => umc.TargetUnitOfMeasure)
            .HasForeignKey(umc => umc.TargetUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}