using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodReceiptNoteItemConfiguration : IEntityTypeConfiguration<GoodReceiptNoteItem>
{
    public void Configure(EntityTypeBuilder<GoodReceiptNoteItem> builder)
    {
        builder.HasOne(grni => grni.GoodReceiptNote)
            .WithMany(grn => grn.Items)
            .HasForeignKey(grni => grni.GoodReceiptNoteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(grni => grni.Material)
            .WithMany()
            .HasForeignKey(grni => grni.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(grni => grni.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(grni => grni.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(grni => grni.UsedQuantity)
            .HasColumnType("decimal")
            .IsRequired()
            .HasDefaultValue(0);
    }
}