using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class PurchaseRequestDocumentItemConfiguration : IEntityTypeConfiguration<PurchaseRequestDocumentItem>
{
    public void Configure(EntityTypeBuilder<PurchaseRequestDocumentItem> builder)
    {
        builder.HasOne(prdi => prdi.PurchaseRequestDocument)
            .WithMany(prd => prd.Items)
            .HasForeignKey(prdi => prdi.PurchaseRequestDocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(prdi => prdi.Material)
            .WithMany()
            .HasForeignKey(prdi => prdi.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(prdi => prdi.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(prdi => prdi.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}