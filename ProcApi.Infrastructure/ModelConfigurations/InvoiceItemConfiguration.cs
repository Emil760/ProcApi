using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.HasOne(ii => ii.Invoice)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ii => ii.PurchaseRequestItem)
            .WithMany()
            .HasForeignKey(ii => ii.PurchaseRequestItemId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(ii => ii.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(ii => ii.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}