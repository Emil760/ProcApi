using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class ReservedItemConfiguration : IEntityTypeConfiguration<ReservedItem>
{
    public void Configure(EntityTypeBuilder<ReservedItem> builder)
    {
        builder.HasOne(rt => rt.GoodReceiptNoteItem)
            .WithOne(gin => gin.ReservedItem)
            .HasForeignKey<ReservedItem>(rt => rt.GoodReceiptNoteItemId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rt => rt.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(rt => rt.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(rt => rt.Quantity)
            .HasColumnType("decimal")
            .IsRequired();

        builder.Property(rt => rt.IsActive)
            .HasColumnType("bool")
            .HasDefaultValue(true)
            .IsRequired();
    }
}