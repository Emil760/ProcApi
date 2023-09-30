using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class PurchaseRequestItemConfiguration : IEntityTypeConfiguration<PurchaseRequestItem>
{
    public void Configure(EntityTypeBuilder<PurchaseRequestItem> builder)
    {
        builder.HasOne(prdi => prdi.PurchaseRequest)
            .WithMany(prd => prd.Items)
            .HasForeignKey(prdi => prdi.PurchaseRequestId)
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