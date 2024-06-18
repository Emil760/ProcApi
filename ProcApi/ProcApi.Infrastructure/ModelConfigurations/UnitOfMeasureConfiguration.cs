using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.Property(um => um.IsActive)
            .HasColumnType("bool")
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(um => um.CanBeDecimal)
            .HasColumnType("bool")
            .IsRequired();

        builder.HasMany(um => um.Converters)
            .WithOne(umc => umc.SourceUnitOfMeasure)
            .HasForeignKey(umc => umc.SourceUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(um => um.Materials)
            .WithOne(m => m.UnitOfMeasure)
            .HasForeignKey(m => m.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}