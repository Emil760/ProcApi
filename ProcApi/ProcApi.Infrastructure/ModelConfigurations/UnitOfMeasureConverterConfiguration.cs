using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UnitOfMeasureConverterConfiguration : IEntityTypeConfiguration<UnitOfMeasureConverter>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasureConverter> builder)
    {
        builder.Property(umc => umc.IsActive)
            .HasColumnType("bool")
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(umc => umc.SourceUnitOfMeasure)
            .WithMany(um => um.Converters)
            .HasForeignKey(umc => umc.SourceUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(umc => umc.TargetUnitOfMeasure)
            .WithMany()
            .HasForeignKey(umc => umc.TargetUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}