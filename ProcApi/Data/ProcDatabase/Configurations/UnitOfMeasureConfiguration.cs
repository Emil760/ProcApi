using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

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