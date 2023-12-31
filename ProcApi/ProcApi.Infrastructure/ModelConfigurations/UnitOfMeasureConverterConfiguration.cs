﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UnitOfMeasureConverterConfiguration : IEntityTypeConfiguration<UnitOfMeasureConverter>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasureConverter> builder)
    {
        builder.Property(umc => umc.IsActive)
            .HasDefaultValue(false);

        builder.HasOne(umc => umc.SourceUnitOfMeasure)
            .WithMany()
            .HasForeignKey(umc => umc.SourceUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(umc => umc.TargetUnitOfMeasure)
            .WithMany(um => um.Converters)
            .HasForeignKey(umc => umc.TargetUnitOfMeasureId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}